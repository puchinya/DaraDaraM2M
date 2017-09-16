using System;
using System.Text;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using DaraDaraM2M.Data;

namespace DaraDaraM2M
{
	public class OM2MJsonSerializer
	{
		private OM2MJsonSerializer()
		{
		}

		private static string GetSerializedName(Type type)
		{
			var elementAttr = type.GetTypeInfo().GetCustomAttribute<OM2MXmlRootAttribute>();

			if (elementAttr != null)
			{
				return elementAttr.ElementShortName;
			}

			return type.Name;
		}

		private static string GetSerializedName(PropertyInfo propertyInfo)
		{
			var elementAttr = propertyInfo.GetCustomAttribute<OM2MXmlElementAttribute>();

			if (elementAttr != null)
			{
				return elementAttr.ElementShortName;
			}

			var attrAttr = propertyInfo.GetCustomAttribute<OM2MXmlAttributeAttribute>();

			if (attrAttr != null)
			{
				return attrAttr.AttributeShortName;
			}

			return propertyInfo.Name;
		}

		private static bool IsIgnore(PropertyInfo propertyInfo)
		{
			var ignoreAttr = propertyInfo.GetCustomAttribute<OM2MIgnoreAttribute>();
			return ignoreAttr != null;
		}

		private static bool IsRequired(PropertyInfo propertyInfo)
		{
			var requiredAttr = propertyInfo.GetCustomAttribute<OM2MRequiredAttribute>();
			return requiredAttr != null;
		}

		public static string Serialize(object obj)
		{
			var sb = new StringBuilder();

			sb.Append("{");
			SerializeCoreUnknown(sb, obj);
			sb.Append("}");

			return sb.ToString();
		}

		private static void SerializeCoreUnknown(StringBuilder sb, object obj)
		{
			var type = obj.GetType();

			sb.AppendFormat("\"m2m:{0}\":", GetSerializedName(type));

			SerializeCoreType(sb, obj);
		}

		private static void SerializeCoreType(StringBuilder sb, object obj)
		{
			var type = obj.GetType();

			if (obj is string || obj is Uri)
			{
				sb.AppendFormat("\"{0}\"", obj.ToString());
				return;
			}
			else if (obj is bool)
			{
				sb.Append((bool)obj ? "true" : "false");
				return;
			}
			else if (type.GetTypeInfo().IsPrimitive)
			{
				sb.Append(obj.ToString());
				return;
			}
			else if (obj is decimal)
			{
				sb.Append(obj.ToString());
				return;
			}
			else if (GetEnumType(type) != null)
			{
				sb.Append(((int)obj).ToString());
				return;
			}
			else if (IsListType(type))
			{
				var list = obj as IList;
				sb.Append("[");
				for (int i = 0; i < list.Count; i++)
				{
					if (i > 0) sb.Append(",");
					SerializeCoreType(sb, list[i]);
				}
				sb.Append("]");
				return;
			}

			sb.Append("{");

			bool needComma = false;

			try
			{

				PropertyInfo anyProperty = null;

				foreach (var property in type.GetProperties())
				{
					var anyElementAttr = property.GetCustomAttribute<OM2MXmlAnyElementAttribute>();
					if (anyElementAttr != null)
					{
						anyProperty = property;
						continue;
					}

					if (IsIgnore(property))
					{
						continue;
					}

					var val = property.GetValue(obj);
					if (val == null)
					{
						continue;
					}

					if (needComma)
					{
						sb.Append(',');
					}

					sb.AppendFormat("\"{0}\":", GetSerializedName(property));
					SerializeCoreType(sb, val);

					needComma = true;
				}

				if (anyProperty != null)
				{
					var val = anyProperty.GetValue(obj);
					if (val != null)
					{
						var list = val as IList;
						foreach (var item in list)
						{
							SerializeCoreUnknown(sb, item);
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			sb.Append("}");
		}

		public static object Deserialize(string jsonText)
		{
			return DeserializeCore(JToken.Parse(jsonText));
		}

		public static Type Deserialize<Type>(string jsonText)
			where Type : class
		{
			return DeserializeClass(JToken.Parse(jsonText) as JObject, typeof(Type)) as Type;
		}

		private static object DeserializeCore(JToken token)
		{
			if (token is JValue)
			{
				if (token.Type == JTokenType.Integer)
				{
					return Convert.ToInt32((token as JValue).Value);
				}
				else
				{
					return (token as JValue).Value;
				}
			}
			if (token is JObject)
			{
				return DeserializeUnknownClass(token as JObject);
			}

			throw new OM2MJsonDeserializeException();
		}

		private static object DeserializeCore(JToken token, Type type)
		{
			if (type.Equals(typeof(DateTime)))
			{
				return token.Value<DateTime>();
			}
			if (type.Equals(typeof(int)))
			{
				return token.Value<int>();
			}
			if (type.Equals(typeof(uint)))
			{
				return token.Value<uint>();
			}

			return null;
		}

		static object DeserializeUnknownClass(JObject obj)
		{
			if (obj.Count != 1)
			{
				throw new OM2MJsonDeserializeException();
			}

			JProperty objRoot = null;

			foreach (var p in obj.Properties())
			{
				objRoot = p;
			}

			var elem = objRoot.Name.Split(':');
			var serializedTypeName = elem[elem.Length - 1];
			Type serializedType;

			if (!m_registeredTypes.TryGetValue(serializedTypeName, out serializedType))
			{
				throw new OM2MJsonDeserializeException();
			}

			JObject objValues = objRoot.Value as JObject;
			if (objValues == null)
			{
				throw new OM2MJsonDeserializeException();
			}

			return DeserializeClass(objValues, serializedType);
		}

		static object DeserializeClass(JObject obj, Type type)
		{
			object instance = type.GetTypeInfo().Assembly.CreateInstance(type.FullName);

			PropertyInfo anyProperty = null;

			var values = new Dictionary<string, JToken>();
			foreach (var ov in obj)
			{
				values[ov.Key] = ov.Value;
			}

			foreach (var property in type.GetProperties())
			{
				if (IsIgnore(property))
				{
					continue;
				}

				JToken val = null;

				var anyElementAttr = property.GetCustomAttribute<OM2MXmlAnyElementAttribute>();
				if (anyElementAttr != null)
				{
					anyProperty = property;
					continue;
				}

				/*
				var elementAttrs = property.GetCustomAttributes<OM2MXmlElementAttribute>();
				if (elementAttrs != null)
				{
					var elementAttrsList = new List<OM2MXmlElementAttribute>(elementAttrs);
					if (elementAttrsList.Count > 1)
					{
						anyProperty = property;
						continue;
					}
				}*/

				var elementAttr = property.GetCustomAttribute<OM2MXmlElementAttribute>();
				if (elementAttr != null)
				{
					if (values.TryGetValue(elementAttr.ElementShortName, out val))
					{
						values.Remove(elementAttr.ElementShortName);
					}
				}
				else
				{
					var attributeAttr = property.GetCustomAttribute<OM2MXmlAttributeAttribute>();
					if (attributeAttr != null)
					{
						if (values.TryGetValue(attributeAttr.AttributeShortName, out val))
						{
							values.Remove(attributeAttr.AttributeShortName);
						}
					}
				}

				if (IsRequired(property) && val == null)
				{
					//	throw new OM2MJsonDeserializeException();
				}

				if (val != null)
				{
					object convertedValue;

					if (IsListType(property.PropertyType))
					{
						var list = property.PropertyType.GetTypeInfo().Assembly
										   .CreateInstance(property.PropertyType.FullName) as IList;

						JArray arrayVal = val as JArray;
						foreach (var v in arrayVal)
						{
							list.Add(DeserializeCore(v));
						}

						convertedValue = list;
					}
					else if (IsEnumType(property.PropertyType))
					{
						var deserializedValue = DeserializeCore(val);
						convertedValue = Enum.ToObject(GetEnumType(property.PropertyType), deserializedValue);
					}
					else if (property.PropertyType.IsAssignableFrom(typeof(Uri)))
					{
						var deserializedValue = DeserializeCore(val);
						convertedValue = new Uri(deserializedValue.ToString(), UriKind.RelativeOrAbsolute);
					}
					else if (property.PropertyType.IsAssignableFrom(typeof(DateTime)))
					{
						var deserializedValue = DeserializeCore(val);
						convertedValue = DateTime.Parse(deserializedValue.ToString());
					}
					else if (property.PropertyType.IsAssignableFrom(typeof(string)))
					{
						convertedValue = DeserializeCore(val);
					}
					else if (property.PropertyType.GetTypeInfo().IsClass)
					{
						convertedValue = DeserializeClass(val as JObject,
																 property.PropertyType);
					}
					else
					{
						var deserializedValue = DeserializeCore(val);
						convertedValue = deserializedValue;
					}

					property.SetValue(instance, convertedValue);
				}
			}

			if (anyProperty != null)
			{
				var propertyValue = new List<object>();
				/*
				var elementAttrs = anyProperty.GetCustomAttributes<OM2MXmlElementAttribute>();
				var elementMap = new Dictionary<string, OM2MXmlElementAttribute>();

				foreach (var ea in elementAttrs)
				{
					elementMap[ea.ElementShortName] = ea;
				}
				*/

				foreach (var pair in values)
				{
					/*
					OM2MXmlElementAttribute ea;

					if (elementAttrs != null && elementMap.TryGetValue(pair.Key, out ea))
					{
						var deserializedValue = DeserializeClass(pair.Value as JObject, ea.Type);
						propertyValue.Add(deserializedValue);
					}
					else
					*/
					{
						Type t;
						var elem = pair.Key.Split(':');

						var name = elem[elem.Length - 1];

						if (m_registeredTypes.TryGetValue(name, out t))
						{
							var deserializedValue = DeserializeClass(pair.Value as JObject, t);
							propertyValue.Add(deserializedValue);
						}
						else
						{
							propertyValue.Add(pair.Value);
						}
					}
				}

				anyProperty.SetValue(instance, propertyValue);
			}

			return instance;
		}

		private static bool IsListType(Type type)
		{
			if (typeof(IList).IsAssignableFrom(type))
				return true;

			return false;
		}

		private static bool IsEnumType(Type type)
		{
			if (type.GetTypeInfo().IsEnum)
				return true;

			if (type.GetTypeInfo().IsGenericType)
			{
				var genericDef = type.GetGenericTypeDefinition();
				if (genericDef == typeof(Nullable<>))
				{
					var genericArgs = type.GetGenericArguments();
					return genericArgs[0].GetTypeInfo().IsEnum;
				}
			}
			return false;
		}

		private static Type GetEnumType(Type type)
		{
			if (type.GetTypeInfo().IsEnum)
				return type;

			if (type.GetTypeInfo().IsGenericType)
			{
				var genericDef = type.GetGenericTypeDefinition();
				if (genericDef == typeof(Nullable<>))
				{
					var genericArgs = type.GetGenericArguments();
					return (genericArgs[0].GetTypeInfo().IsEnum) ? genericArgs[0] : null;
				}
			}
			return null;
		}

		static OM2MJsonSerializer()
		{
			m_registeredTypes = new Dictionary<string, Type>();

			RegisterRoot(typeof(OM2MRequestPrimitive));
			RegisterRoot(typeof(OM2MResponsePrimitive));
			RegisterRoot(typeof(OM2MAccessControlPolicy));
			RegisterRoot(typeof(OM2MAE));
			RegisterRoot(typeof(OM2MCSEBase));
		}

		private static void RegisterRoot(Type type)
		{
			var elemName = type.Name;
			var root = type.GetTypeInfo().GetCustomAttribute<OM2MXmlRootAttribute>();
			if (root != null)
			{
				elemName = root.ElementShortName;
			}

			m_registeredTypes.Add(elemName, type);
		}

		private static Dictionary<string, Type> m_registeredTypes;
	}

	public class OM2MJsonDeserializeException : Exception
	{
		public OM2MJsonDeserializeException()
			: base()
		{
		}
	}
}
