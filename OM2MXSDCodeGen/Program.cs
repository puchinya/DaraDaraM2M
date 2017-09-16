using System;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace OM2MXSDCodeGen
{
	class MainClass
	{
		public class IndentWriter
		{
			public IndentWriter(TextWriter tw)
			{
				Base = tw;
			}

			public void Indent()
			{
				IndentLevel++;
			}

			public void Unindent()
			{
				IndentLevel--;
			}

			private void WriteIndent()
			{
				for (int i = 0; i < IndentLevel * 4; i++)
				{
					Base.Write(' ');
				}
			}

			public void WriteLine(string text)
			{
				WriteIndent();
				Base.WriteLine(text);
			}

			public void WriteLine(string format, params object[] args)
			{
				WriteIndent();
				Base.WriteLine(format, args);
			}

			public TextWriter Base
			{
				get;
				private set;
			}

			public int IndentLevel
			{
				get;
				private set;
			}
		}

		private static string MakeCSIdentifier(string text)
		{
			StringBuilder sb = new StringBuilder(text);
			sb[0] = char.ToUpper(sb[0]);
			sb.Replace("-", "");
			sb.Replace(" ", "");

			return sb.ToString();
		}

		class CSTypeInfo
		{
			private CSTypeInfo()
			{
			}
			
			public static CSTypeInfo CreateAliasType(string typeName)
			{
				CSTypeInfo ti = new CSTypeInfo();

				ti.Name = typeName;
				ti.Kind = TypeKind.Alias;

				return ti;
			}

			public static CSTypeInfo CreatePrimitiveType(string typeName)
			{
				CSTypeInfo ti = new CSTypeInfo();

				ti.Name = typeName;
				ti.Kind = TypeKind.Primitive;
				ti.IsSimpleTypeBase = true;

				return ti;
			}

			public static CSTypeInfo CreateClassType(string typeName, bool isSimpleType)
			{
				CSTypeInfo ti = new CSTypeInfo();

				ti.Name = typeName;
				ti.Kind = TypeKind.Class;
				ti.Properties = new List<CSPropertyInfo>();
				ti.Types = new List<CSTypeInfo>();
				ti.IsSimpleTypeBase = isSimpleType;

				return ti;
			}

			public static CSTypeInfo CreateClassType(string typeName)
			{
				return CreateClassType(typeName, false);
			}

			public static CSTypeInfo CreateStructType(string typeName, bool isSimpleType)
			{
				CSTypeInfo ti = new CSTypeInfo();

				ti.Name = typeName;
				ti.Kind = TypeKind.Struct;
				ti.Properties = new List<CSPropertyInfo>();
				ti.IsSimpleTypeBase = isSimpleType;

				return ti;
			}

			public static CSTypeInfo CreateStructType(string typeName)
			{
				return CreateStructType(typeName, false);
			}

			public static CSTypeInfo CreateListType(CSTypeInfo elementType)
			{
				CSTypeInfo ti = new CSTypeInfo();

				ti.Kind = TypeKind.List;
				ti.ElementType = elementType;

				return ti;
			}

			public static CSTypeInfo CreateArrayType(CSTypeInfo elementType, bool isSimpleType)
			{
				CSTypeInfo ti = new CSTypeInfo();

				ti.Kind = TypeKind.Array;
				ti.ElementType = elementType;
				ti.IsSimpleTypeBase = isSimpleType;

				return ti;
			}

			public static CSTypeInfo CreateEnumType()
			{
				CSTypeInfo ti = new CSTypeInfo();

				ti.Kind = TypeKind.Enum;
				ti.EnumValues = new List<CSEnumMember>();

				return ti;
			}

			public static CSTypeInfo CreateUnionType()
			{
				CSTypeInfo ti = new CSTypeInfo();

				ti.Kind = TypeKind.Union;
				ti.UnionMembers = new List<CSTypeInfo>();
				ti.BaseType = TypeObject;

				return ti;
			}

			public static readonly CSTypeInfo TypeString = CreateClassType("string", true);
			public static readonly CSTypeInfo TypeByte = CreatePrimitiveType("byte");
			public static readonly CSTypeInfo TypeSByte = CreatePrimitiveType("sbyte");
			public static readonly CSTypeInfo TypeShort = CreatePrimitiveType("short");
			public static readonly CSTypeInfo TypeUShort = CreatePrimitiveType("ushort");
			public static readonly CSTypeInfo TypeInt = CreatePrimitiveType("int");
			public static readonly CSTypeInfo TypeUInt = CreatePrimitiveType("uint");
			public static readonly CSTypeInfo TypeLong = CreatePrimitiveType("long");
			public static readonly CSTypeInfo TypeULong = CreatePrimitiveType("ulong");
			public static readonly CSTypeInfo TypeFloat = CreatePrimitiveType("float");
			public static readonly CSTypeInfo TypeUri = CreateClassType("Uri", true);
			public static readonly CSTypeInfo TypeDateTime = CreateStructType("DateTime", true);
			public static readonly CSTypeInfo TypeBool = CreatePrimitiveType("bool");
			public static readonly CSTypeInfo TypeDecimal = CreateStructType("decimal", true);
			public static readonly CSTypeInfo TypeIPAddress = CreateClassType("IPAddress", true);
			public static readonly CSTypeInfo TypeObject = CreateClassType("object", true);
			public static readonly CSTypeInfo TypeByteArray = CreateArrayType(TypeByte, true);

			public enum TypeKind
			{
				Primitive,
				Class,
				Struct,
				Alias,
				List,
				Enum,
				Union,
				Array
			}

			public string Name
			{
				get;
				set;
			}

			public TypeKind Kind
			{
				get;
				set;
			}

			public bool IsValueType
			{
				get
				{
					if (Kind == TypeKind.Alias)
					{
						return BaseType.IsValueType;
					}
					
					return Kind == TypeKind.Primitive ||
										   Kind == TypeKind.Struct ||
						                   Kind == TypeKind.Enum;
				}
			}

			public bool IsList
			{
				get
				{
					if (Kind == TypeKind.Alias)
					{
						return BaseType.IsList;
					}

					return Kind == TypeKind.List;
				}
			}

			public bool IsUnion
			{
				get
				{
					if (Kind == TypeKind.Alias)
					{
						return BaseType.IsUnion;
					}

					return Kind == TypeKind.Union;
				}
			}

			public bool IsSimpleTypeBase = false;
			public bool IsRootElement = false;
			public CSTypeInfo BaseType = null;
			public XmlQualifiedName SerializedName;
			public XmlQualifiedName SerializedShortName;

			// choice...
			public bool HasChildren = false;
			public bool AnyChild = false;
			public List<CSPropertyInfo> Children;

			// For Class or Struct
			public List<CSPropertyInfo> Properties = null;
			public List<CSTypeInfo> Types = null;

			// For Enum
			public List<CSEnumMember> EnumValues = null;

			// For Union
			public List<CSTypeInfo> UnionMembers = null;

			// For List
			public CSTypeInfo ElementType = null;

			// Facets

			// List<T> or string
			public decimal FacetMinLength = 0;
			public decimal FacetMaxLength = decimal.MaxValue;
		}

		class CSEnumMember
		{
			public CSEnumMember(string name, int value)
			{
				Name = name;
				Value = value;
			}

			public string Name
			{
				get;
				set;
			}

			public int Value
			{
				get;
				set;
			}
		}

		class XSDTypeInfo
		{
			public XSDTypeInfo()
			{
			}

			public XSDTypeInfo(XmlQualifiedName name, CSTypeInfo csTypeInfo)
			{
				Name = name;
				CSTypeInfo = csTypeInfo;
			}

			public static readonly XSDTypeInfo TypeBase64Binary = new XSDTypeInfo(
				new XmlQualifiedName("base64Binary", XmlSchema.Namespace), CSTypeInfo.TypeObject);
			
			public static readonly XSDTypeInfo TypeAnyType = new XSDTypeInfo(
				new XmlQualifiedName("anyType", XmlSchema.Namespace), CSTypeInfo.TypeObject);
			public static readonly XSDTypeInfo TypeAnySimpleType = new XSDTypeInfo(
				new XmlQualifiedName("anySimpleType", XmlSchema.Namespace), CSTypeInfo.TypeObject);

			// String
			public static readonly XSDTypeInfo TypeString = new XSDTypeInfo(
				new XmlQualifiedName("string", XmlSchema.Namespace), CSTypeInfo.TypeString);

			public static readonly XSDTypeInfo TypeToken = new XSDTypeInfo(
				new XmlQualifiedName("token", XmlSchema.Namespace), CSTypeInfo.TypeString);

			public static readonly XSDTypeInfo TypeNCName = new XSDTypeInfo(
				new XmlQualifiedName("NCName", XmlSchema.Namespace), CSTypeInfo.TypeString);

			public static readonly XSDTypeInfo TypeLanguage = new XSDTypeInfo(
				new XmlQualifiedName("language", XmlSchema.Namespace), CSTypeInfo.TypeString);

			// Date
			public static readonly XSDTypeInfo TypeDuration = new XSDTypeInfo(
				new XmlQualifiedName("duration", XmlSchema.Namespace), CSTypeInfo.TypeDateTime);

			// Misc
			public static readonly XSDTypeInfo TypeAnyUri = new XSDTypeInfo(
				new XmlQualifiedName("anyURI", XmlSchema.Namespace), CSTypeInfo.TypeString);

			// Numeric
			public static readonly XSDTypeInfo TypeBoolean = new XSDTypeInfo(
				new XmlQualifiedName("boolean", XmlSchema.Namespace), CSTypeInfo.TypeBool);
			public static readonly XSDTypeInfo TypeInteger = new XSDTypeInfo(
				new XmlQualifiedName("integer", XmlSchema.Namespace), CSTypeInfo.TypeInt);
			public static readonly XSDTypeInfo TypePositiveInteger = new XSDTypeInfo(
				new XmlQualifiedName("positiveInteger", XmlSchema.Namespace), CSTypeInfo.TypeInt);
			public static readonly XSDTypeInfo TypeNegativeInteger = new XSDTypeInfo(
				new XmlQualifiedName("negativeInteger", XmlSchema.Namespace), CSTypeInfo.TypeInt);
			public static readonly XSDTypeInfo TypeNonNegativeInteger = new XSDTypeInfo(
				new XmlQualifiedName("nonNegativeInteger", XmlSchema.Namespace), CSTypeInfo.TypeInt);
			public static readonly XSDTypeInfo TypeInt = new XSDTypeInfo(
				new XmlQualifiedName("int", XmlSchema.Namespace), CSTypeInfo.TypeInt);
			public static readonly XSDTypeInfo TypeUnsignedInt = new XSDTypeInfo(
				new XmlQualifiedName("unsignedInt", XmlSchema.Namespace), CSTypeInfo.TypeUInt);
			public static readonly XSDTypeInfo TypeLong = new XSDTypeInfo(
				new XmlQualifiedName("long", XmlSchema.Namespace), CSTypeInfo.TypeLong);
			public static readonly XSDTypeInfo TypeUnsignedLong = new XSDTypeInfo(
				new XmlQualifiedName("unsignedLong", XmlSchema.Namespace), CSTypeInfo.TypeULong);

			public static readonly XSDTypeInfo TypeFloat = new XSDTypeInfo(
				new XmlQualifiedName("float", XmlSchema.Namespace), CSTypeInfo.TypeFloat);
			
			public CSTypeInfo CSTypeInfo;
			public XmlQualifiedName Name;
			public XmlSchemaObject Node;
		}

		class CSPropertyInfo
		{
			public CSTypeInfo Type;
			public string Name;
			public string SerializedName;
			public string SerializedShortName;
			public bool IsRequired;
			public bool IsXmlAttribute = false;
			public string DefaultValueText;
		}

		static Dictionary<XmlQualifiedName, XSDTypeInfo> typesTable = new Dictionary<XmlQualifiedName, XSDTypeInfo>();
		static Dictionary<XmlQualifiedName, XSDTypeInfo> elementTable = new Dictionary<XmlQualifiedName, XSDTypeInfo>();
		delegate void PostProcessHandler();
		static List<PostProcessHandler> postProcessAffterElementParsing = new List<PostProcessHandler>();

		static void ParseFacets(CSTypeInfo typeInfo, XmlSchemaObjectCollection facets)
		{
			foreach (var facet in facets)
			{
				if (facet is XmlSchemaLengthFacet)
				{
					var lengthFacet = facet as XmlSchemaLengthFacet;

					typeInfo.FacetMinLength = typeInfo.FacetMaxLength
						= decimal.Parse(lengthFacet.Value);
				}
				else if (facet is XmlSchemaMinLengthFacet)
				{
					var lengthFacet = facet as XmlSchemaMinLengthFacet;

					typeInfo.FacetMinLength = decimal.Parse(lengthFacet.Value);
				}
				else if (facet is XmlSchemaMaxLengthFacet)
				{
					var lengthFacet = facet as XmlSchemaMaxLengthFacet;

					typeInfo.FacetMaxLength = decimal.Parse(lengthFacet.Value);
				}
			}
		}

		/// <summary>
		/// Parses the type of the simple.
		/// </summary>
		/// <returns>The simple type.</returns>
		/// <param name="schema">if the element is top level element,then set schema,otherwise set null</param>
		/// <param name="simpleType">Simple type.</param>
		/// 
		/// simpleType
		/// - list
		/// - union
		/// - restirction(simpleType)
		/// - #all
		static CSTypeInfo ParseSimpleType(XmlSchema schema, XmlSchemaSimpleType simpleType)
		{
			// special process
			/*
			if (simpleType.Name != null)
			{
				if (simpleType.Name == "ipv4")
				{
					var typeInfo = CSTypeInfo.CreateAliasType("ipv4");
					typeInfo.BaseType = CSTypeInfo.TypeIPAddress;
					typeInfo.SerializedName = new XmlQualifiedName(simpleType.Name, schema.TargetNamespace);
					return typeInfo;
				}
				else if (simpleType.Name == "ipv6")
				{
					var typeInfo = CSTypeInfo.CreateAliasType("ipv6");
					typeInfo.BaseType = CSTypeInfo.TypeIPAddress;
					typeInfo.SerializedName = new XmlQualifiedName(simpleType.Name, schema.TargetNamespace);
					return typeInfo;
				}
			}*/

			{
				CSTypeInfo typeInfo = null;

				var content = simpleType.Content;

				// list
				if (content is XmlSchemaSimpleTypeList)
				{
					typeInfo = ParseSimpleTypeList(content as XmlSchemaSimpleTypeList);
				}
				// restirction(simpleType)
				else if (content is XmlSchemaSimpleTypeRestriction)
				{
					var restriction = content as XmlSchemaSimpleTypeRestriction;

					if (!restriction.BaseTypeName.IsEmpty)
					{
						// has base attribute
						
						// Check enum
						// if a type of all members is enumeraton,
						// generare enum type.
						bool allMembersEnum = false;
						if (restriction.Facets.Count > 0)
						{
							allMembersEnum = true;
							foreach (var facet in restriction.Facets)
							{
								if (facet is XmlSchemaEnumerationFacet)
								{
								}
								else
								{
									allMembersEnum = false;
									break;
								}
							}
						}

						if (simpleType.Name != null && allMembersEnum && restriction.BaseTypeName.Name == "integer")
						{
							typeInfo = CSTypeInfo.CreateEnumType();
							/* Cannot get comment
							foreach (var facet in restriction.Facets)
							{
								var enumFacet = facet as XmlSchemaEnumerationFacet;
							}
							*/
						}
						else
						{
							typeInfo = CSTypeInfo.CreateAliasType(null);

							XSDTypeInfo baseTypeInfo;

							ParseFacets(typeInfo, restriction.Facets);

							if (typesTable.TryGetValue(restriction.BaseTypeName, out baseTypeInfo))
							{
								typeInfo.BaseType = baseTypeInfo.CSTypeInfo;
							}
							else
							{
								postProcessAffterElementParsing.Add(delegate
								{
									typeInfo.BaseType = typesTable[restriction.BaseTypeName].CSTypeInfo;;
								});
							}
						}
					}
					else
					{
						// doesn't have base attribute
						
						var baseTypeContet = restriction.BaseType.Content;

						if (baseTypeContet is XmlSchemaSimpleTypeList)
						{
							typeInfo = ParseSimpleTypeList(baseTypeContet as XmlSchemaSimpleTypeList);
							ParseFacets(typeInfo, restriction.Facets);
						}
						else
						{
							// Not reachable
							throw new Exception();
						}
					}
				}
				// union
				else if (content is XmlSchemaSimpleTypeUnion)
				{
					var union = content as XmlSchemaSimpleTypeUnion;

					typeInfo = CSTypeInfo.CreateUnionType();

					// ToDo:
					foreach (var member in union.BaseTypes)
					{
						var simpleTypeMember = member as XmlSchemaSimpleType;
						var memberTypeInfo = ParseSimpleType(null, simpleTypeMember);
						typeInfo.UnionMembers.Add(memberTypeInfo);
					}
				}
				else
				{
					// not reachable
					throw new Exception();
				}

				if (simpleType.Name != null)
				{
					typeInfo.Name = MakeCSIdentifier(simpleType.Name);
					typeInfo.SerializedName = new XmlQualifiedName(simpleType.Name, schema.TargetNamespace);
				}

				return typeInfo;
			}
		}

		static CSTypeInfo ParseSimpleTypeList(XmlSchemaSimpleTypeList simpleTypeList)
		{
			if (!simpleTypeList.ItemTypeName.IsEmpty)
			{
				XSDTypeInfo xsdTypeInfo;
				if (typesTable.TryGetValue(simpleTypeList.ItemTypeName, out xsdTypeInfo)) {
					return CSTypeInfo.CreateListType(xsdTypeInfo.CSTypeInfo);
				}
				else
				{
					var typeInfo = CSTypeInfo.CreateListType(null);

					postProcessAffterElementParsing.Add(delegate {
						typeInfo.ElementType = typesTable[simpleTypeList.ItemTypeName].CSTypeInfo;
					});

					return typeInfo;
				}
			}

			throw new Exception();
		}

		static CSTypeInfo ParseComplexType(XmlSchema schema, string defaultTypeName, XmlSchemaComplexType complexType)
		{
			var typeInfo = CSTypeInfo.CreateClassType(null);

			if (complexType.Name != null)
			{
				typeInfo.Name = MakeCSIdentifier(complexType.Name);
				typeInfo.SerializedName = new XmlQualifiedName(complexType.Name, schema.TargetNamespace);
			}
			else
			{
				typeInfo.Name = MakeCSIdentifier(defaultTypeName);
				typeInfo.SerializedName = new XmlQualifiedName(defaultTypeName, schema != null ? schema.TargetNamespace : null);
			}

			ParseComplexTypeMembers(typeInfo, complexType);

			return typeInfo;
		}

		static void ParseMemberElement(CSTypeInfo typeInfo, XmlSchemaElement memberElement, bool addToChildren)
		{
			var pi = new CSPropertyInfo();

			if (!memberElement.RefName.IsEmpty)
			{
				// has "ref" attribute
				XSDTypeInfo baseTypeInfo;
				var refName = memberElement.RefName;

				if (elementTable.TryGetValue(refName, out baseTypeInfo))
				{
					pi.Name = MakeCSIdentifier(refName.Name);

					if (memberElement.MaxOccurs > 1 && !addToChildren)
					{
						var pit = CSTypeInfo.CreateListType(baseTypeInfo.CSTypeInfo);
						pit.FacetMinLength = memberElement.MinOccurs;
						pit.FacetMaxLength = memberElement.MaxOccurs;

						pi.Type = pit;
					}
					else
					{
						if (memberElement.MinOccurs >= 1)
						{
							pi.IsRequired = true;
						}
						pi.Type = baseTypeInfo.CSTypeInfo;
					}
					pi.SerializedName = refName.Name;
				}
				else
				{
					postProcessAffterElementParsing.Add(delegate() {

						baseTypeInfo = elementTable[refName];

						pi.Name = MakeCSIdentifier(refName.Name);

						if (memberElement.MaxOccurs > 1 && !addToChildren)
						{
							var pit = CSTypeInfo.CreateListType(baseTypeInfo.CSTypeInfo);
							pit.FacetMinLength = memberElement.MinOccurs;
							pit.FacetMaxLength = memberElement.MaxOccurs;

							pi.Type = pit;
						}
						else
						{
							if (memberElement.MinOccurs == 1)
							{
								pi.IsRequired = true;
							}
							pi.Type = baseTypeInfo.CSTypeInfo;
						}
						pi.SerializedName = refName.Name;
					});
				}
			}
			else
			{
				// doen't have "ref" attribute
				
				pi.Name = MakeCSIdentifier(memberElement.Name);
				pi.SerializedName = memberElement.Name;

				if (memberElement.MaxOccurs > 1 && !addToChildren)
				{
					if (!memberElement.SchemaTypeName.IsEmpty)
					{
						postProcessAffterElementParsing.Add(delegate
						{
							var elementType = typesTable[memberElement.SchemaTypeName].CSTypeInfo;
							var listType = CSTypeInfo.CreateListType(elementType);
							listType.FacetMinLength = memberElement.MinOccurs;
							listType.FacetMaxLength = memberElement.MaxOccurs;
							pi.Type = listType;
						});
					}
					else
					{
						CSTypeInfo elementType;

						if (memberElement.SchemaType is XmlSchemaSimpleType)
						{
							elementType = ParseSimpleType(null,
													   memberElement.SchemaType as XmlSchemaSimpleType);
						}
						else if (memberElement.SchemaType is XmlSchemaComplexType)
						{
							elementType = ParseComplexType(null, pi.SerializedName,
													   memberElement.SchemaType as XmlSchemaComplexType);
						}
						else
						{
							// Not reachable
							throw new Exception();
						}

						elementType.Name = pi.Name;
						typeInfo.Types.Add(elementType);

						var listType = CSTypeInfo.CreateListType(elementType);
						listType.FacetMinLength = memberElement.MinOccurs;
						listType.FacetMaxLength = memberElement.MaxOccurs;

						pi.Type = listType;
					}
				}
				else
				{
					pi.IsRequired = memberElement.MinOccurs != 0;

					if (!memberElement.SchemaTypeName.IsEmpty)
					{
						XSDTypeInfo baseTypeInfo;
						if (typesTable.TryGetValue(memberElement.SchemaTypeName, out baseTypeInfo))
						{
							pi.Type = baseTypeInfo.CSTypeInfo;
						}
						else
						{
							postProcessAffterElementParsing.Add(delegate {
								pi.Type = typesTable[memberElement.SchemaTypeName].CSTypeInfo;
							});
						}
					}
					else
					{
						if (memberElement.SchemaType is XmlSchemaSimpleType)
						{
							pi.Type = ParseSimpleType(null,
													   memberElement.SchemaType as XmlSchemaSimpleType);
							pi.Type.Name = pi.Name;
							typeInfo.Types.Add(pi.Type);
						}
						else if (memberElement.SchemaType is XmlSchemaComplexType)
						{
							pi.Type = ParseComplexType(null, pi.SerializedName,
													   memberElement.SchemaType as XmlSchemaComplexType);
							typeInfo.Types.Add(pi.Type);
						}
						else
						{
							// Not reachable
							throw new Exception();
						}
					}
				}
			}

			if (addToChildren)
			{
				if (typeInfo.Children == null)
				{
					typeInfo.Children = new List<CSPropertyInfo>();
					typeInfo.HasChildren = true;
				}
				typeInfo.Children.Add(pi);
			}
			else
			{
				typeInfo.Properties.Add(pi);
			}
		}

		static void ParseSequence(CSTypeInfo typeInfo, XmlSchemaSequence sequence, bool addToChildren)
		{
			foreach (var item in sequence.Items)
			{
				if (item is XmlSchemaElement)
				{
					ParseMemberElement(typeInfo, item as XmlSchemaElement, addToChildren);
				}
				else if (item is XmlSchemaSequence)
				{
					ParseSequence(typeInfo, item as XmlSchemaSequence, addToChildren);
				}
				else if (item is XmlSchemaChoice)
				{
					ParseChoice(typeInfo, item as XmlSchemaChoice);
				}
				else if (item is XmlSchemaAll)
				{
					ParseAll(typeInfo, item as XmlSchemaAll, addToChildren);
				}
				else
				{
					// Not reachable
					throw new Exception();
				}
			}
		}

		static void ParseChoice(CSTypeInfo typeInfo, XmlSchemaChoice choice)
		{
			foreach (var item in choice.Items)
			{
				if (item is XmlSchemaElement)
				{
					ParseMemberElement(typeInfo, item as XmlSchemaElement, true);
				}
				else if (item is XmlSchemaSequence)
				{
					ParseSequence(typeInfo, item as XmlSchemaSequence, true);
				}
				else if (item is XmlSchemaChoice)
				{
					ParseChoice(typeInfo, item as XmlSchemaChoice);
				}
				else if (item is XmlSchemaAll)
				{
					ParseAll(typeInfo, item as XmlSchemaAll, true);
				}
				else if (item is XmlSchemaAny)
				{
					typeInfo.HasChildren = true;
					typeInfo.AnyChild = true;
				}
				else
				{
					// Not reachable
					throw new Exception();
				}
			}
		}

		static void ParseAll(CSTypeInfo typeInfo, XmlSchemaAll all, bool addToChildren)
		{
			foreach (var item in all.Items)
			{
				if (item is XmlSchemaElement)
				{
					ParseMemberElement(typeInfo, item as XmlSchemaElement, addToChildren);
				}
				else if (item is XmlSchemaSequence)
				{
					ParseSequence(typeInfo, item as XmlSchemaSequence, addToChildren);
				}
				else if (item is XmlSchemaChoice)
				{
					ParseChoice(typeInfo, item as XmlSchemaChoice);
				}
				else if (item is XmlSchemaAll)
				{
					ParseAll(typeInfo, item as XmlSchemaAll, addToChildren);
				}
				else if (item is XmlSchemaAny)
				{
					typeInfo.HasChildren = true;
					typeInfo.AnyChild = true;
				}
				else
				{
					// Not reachable
					throw new Exception();
				}
			}
		}

		static CSPropertyInfo ParseAttribute(XmlSchemaAttribute attr)
		{
			var pi = new CSPropertyInfo();

			pi.Name = MakeCSIdentifier(attr.Name);
			pi.SerializedName = attr.Name;
			pi.IsRequired = attr.Use == XmlSchemaUse.Required;
			pi.DefaultValueText = attr.DefaultValue;
			pi.IsXmlAttribute = true;

			if (!attr.SchemaTypeName.IsEmpty)
			{
				XSDTypeInfo baseTypeInfo;
				if (typesTable.TryGetValue(attr.SchemaTypeName, out baseTypeInfo))
				{
					pi.Type = baseTypeInfo.CSTypeInfo;
				}
				else
				{
					postProcessAffterElementParsing.Add(delegate {
						pi.Type = typesTable[attr.SchemaTypeName].CSTypeInfo;	
					});
				}
			}
			else
			{
				pi.Type = ParseSimpleType(null, attr.SchemaType as XmlSchemaSimpleType);
			}

			return pi;
		}

		static void ParseAttributes(CSTypeInfo typeInfo, XmlSchemaObjectCollection attributes)
		{
			foreach (var o in attributes)
			{
				var attr = o as XmlSchemaAttribute;
				typeInfo.Properties.Add(ParseAttribute(attr));
			}
		}

		static void ParseParticle(CSTypeInfo typeInfo, XmlSchemaParticle particle)
		{
			if (particle is XmlSchemaSequence)
			{
				ParseSequence(typeInfo, particle as XmlSchemaSequence, false);
			}
			else if (particle is XmlSchemaChoice)
			{
				ParseChoice(typeInfo, particle as XmlSchemaChoice);
			}
			else if (particle is XmlSchemaAll)
			{
				ParseAll(typeInfo, particle as XmlSchemaAll, false);
			}
			else if (particle is XmlSchemaAny)
			{
				typeInfo.HasChildren = true;
			}
			else
			{
				// Not reachable
				throw new Exception();
			}
		}

		static void ParseComplexTypeMembers(CSTypeInfo typeInfo, XmlSchemaComplexType complexType)
		{
			if (complexType.ContentModel != null)
			{
				if (complexType.ContentModel.Content is XmlSchemaComplexContentExtension)
				{
					var extenstion = complexType.ContentModel.Content as XmlSchemaComplexContentExtension;

					if (!extenstion.BaseTypeName.IsEmpty)
					{

						XSDTypeInfo baseTypeInfo;
						if (typesTable.TryGetValue(extenstion.BaseTypeName, out baseTypeInfo))
						{
							typeInfo.BaseType = baseTypeInfo.CSTypeInfo;
						}
						else
						{
							postProcessAffterElementParsing.Add(delegate
							{
								typeInfo.BaseType = typesTable[extenstion.BaseTypeName].CSTypeInfo;
							});
						}

						ParseAttributes(typeInfo, extenstion.Attributes);
						ParseParticle(typeInfo, extenstion.Particle);
					}
					else
					{
						throw new Exception();
					}
				}
				else if(complexType.ContentModel.Content is XmlSchemaSimpleContentExtension)
				{
					var extenstion = complexType.ContentModel.Content as XmlSchemaSimpleContentExtension;

					XSDTypeInfo baseTypeInfo;

					if (!extenstion.BaseTypeName.IsEmpty)
					{

						if (typesTable.TryGetValue(extenstion.BaseTypeName, out baseTypeInfo))
						{
							typeInfo.BaseType = baseTypeInfo.CSTypeInfo;
						}
						else
						{
							postProcessAffterElementParsing.Add(delegate {
								typeInfo.BaseType = typesTable[extenstion.BaseTypeName].CSTypeInfo;
							});
						}
					}
					else
					{
						// Not reachable
						throw new Exception();
					}

					ParseAttributes(typeInfo, extenstion.Attributes);
				}
				else
				{
					// Not reachable
					throw new Exception();
				}
			}
			else
			{
				ParseAttributes(typeInfo, complexType.Attributes);
				ParseParticle(typeInfo, complexType.Particle);
			}
		}

		static Dictionary<string, List<XSDTypeInfo>> typesTableEachSchema = new Dictionary<string, List<XSDTypeInfo>>();

		static void AddTypeInfo(string name, XSDTypeInfo typeInfo)
		{
			List<XSDTypeInfo> list;

			if (!typesTableEachSchema.TryGetValue(name, out list))
			{
				list = new List<XSDTypeInfo>();
				typesTableEachSchema.Add(name, list);
			}
			list.Add(typeInfo);
		}

		public static void Main(string[] args)
		{
			var dir = args[0];
			var outputDir = ".";

			var xsdFiles = Directory.GetFiles(dir, "*.xsd");
			var schemas = new List<XmlSchema>();

			var iname = typeof(string[]).Name;

			foreach (var xsdFile in xsdFiles)
			{
				using (var tr = new StreamReader(xsdFile, Encoding.UTF8))
				{
					var schema = XmlSchema.Read(tr, (object sender, ValidationEventArgs e) =>
					{
						 Console.WriteLine(e.Message);
					});
					schema.SourceUri = Path.GetFileNameWithoutExtension(xsdFile);
					schemas.Add(schema);
				}
			}

			typesTable.Add(XSDTypeInfo.TypeBase64Binary.Name, XSDTypeInfo.TypeBase64Binary);
			typesTable.Add(XSDTypeInfo.TypeAnyType.Name, XSDTypeInfo.TypeAnyType);
			typesTable.Add(XSDTypeInfo.TypeAnySimpleType.Name, XSDTypeInfo.TypeAnySimpleType);

			typesTable.Add(XSDTypeInfo.TypeString.Name, XSDTypeInfo.TypeString);
			typesTable.Add(XSDTypeInfo.TypeToken.Name, XSDTypeInfo.TypeToken);
			typesTable.Add(XSDTypeInfo.TypeNCName.Name, XSDTypeInfo.TypeNCName);
			typesTable.Add(XSDTypeInfo.TypeLanguage.Name, XSDTypeInfo.TypeLanguage);

			typesTable.Add(XSDTypeInfo.TypeAnyUri.Name, XSDTypeInfo.TypeAnyUri);
			typesTable.Add(XSDTypeInfo.TypeBoolean.Name, XSDTypeInfo.TypeBoolean);
			typesTable.Add(XSDTypeInfo.TypeInteger.Name, XSDTypeInfo.TypeInteger);
			typesTable.Add(XSDTypeInfo.TypePositiveInteger.Name, XSDTypeInfo.TypePositiveInteger);
			typesTable.Add(XSDTypeInfo.TypeNegativeInteger.Name, XSDTypeInfo.TypeNegativeInteger);
			typesTable.Add(XSDTypeInfo.TypeNonNegativeInteger.Name, XSDTypeInfo.TypeNonNegativeInteger);
			typesTable.Add(XSDTypeInfo.TypeInt.Name, XSDTypeInfo.TypeInt);
			typesTable.Add(XSDTypeInfo.TypeUnsignedInt.Name, XSDTypeInfo.TypeUnsignedInt);
			typesTable.Add(XSDTypeInfo.TypeLong.Name, XSDTypeInfo.TypeLong);
			typesTable.Add(XSDTypeInfo.TypeUnsignedLong.Name, XSDTypeInfo.TypeUnsignedLong);
			typesTable.Add(XSDTypeInfo.TypeFloat.Name, XSDTypeInfo.TypeFloat);
			typesTable.Add(XSDTypeInfo.TypeDuration.Name, XSDTypeInfo.TypeDuration);

			// Process types
			foreach (var schema in schemas)
			{
				foreach (var node in schema.Items)
				{
					if (node is XmlSchemaSimpleType)
					{
						var simpleType = node as XmlSchemaSimpleType;

						var xsdTypeInfo = new XSDTypeInfo();

						xsdTypeInfo.Name = new XmlQualifiedName(simpleType.Name,
						                                        schema.TargetNamespace);
						xsdTypeInfo.Node = node;
						xsdTypeInfo.CSTypeInfo = ParseSimpleType(schema, simpleType);

						typesTable.Add(xsdTypeInfo.Name, xsdTypeInfo);
						AddTypeInfo(schema.SourceUri, xsdTypeInfo);

					}
					else if (node is XmlSchemaComplexType)
					{
						var complexType = node as XmlSchemaComplexType;

						var xsdTypeInfo = new XSDTypeInfo();

						xsdTypeInfo.Name = new XmlQualifiedName(complexType.Name,
						                                        schema.TargetNamespace);
						xsdTypeInfo.Node = node;
						xsdTypeInfo.CSTypeInfo = ParseComplexType(schema, null, complexType);

						typesTable.Add(xsdTypeInfo.Name, xsdTypeInfo);
						AddTypeInfo(schema.SourceUri, xsdTypeInfo);
					}
				}
			}

			// Process elements
			foreach (var schema in schemas)
			{
				foreach (var node in schema.Items)
				{
					if (node is XmlSchemaElement)
					{
						var element = node as XmlSchemaElement;

						if (!element.SchemaTypeName.IsEmpty)
						{
							var typeInfo = typesTable[element.SchemaTypeName];
							typeInfo.CSTypeInfo.IsRootElement = true;
							// Nothing
							elementTable.Add(new XmlQualifiedName(element.Name, schema.TargetNamespace),
							                 typesTable[element.SchemaTypeName]);
						}
						else
						{
							if (element.SchemaType is XmlSchemaComplexType)
							{
								var complexType = element.SchemaType as XmlSchemaComplexType;

								var typeInfo = new XSDTypeInfo();

								typeInfo.Name = new XmlQualifiedName(element.Name, schema.TargetNamespace);
								typeInfo.Node = node;
								typeInfo.CSTypeInfo = ParseComplexType(schema, element.Name, complexType);
								typeInfo.CSTypeInfo.IsRootElement = true;

								typesTable.Add(typeInfo.Name, typeInfo);
								AddTypeInfo(schema.SourceUri, typeInfo);
								elementTable.Add(typeInfo.Name, typeInfo);
							}
							else
							{
								throw new Exception();
							}
						}
					}
				}
			}

			// Post process
			do
			{
				var clone = new List<PostProcessHandler>(postProcessAffterElementParsing);
				postProcessAffterElementParsing.Clear();
				// post process
				foreach (var p in clone)
				{
					p();
				}
			} while (postProcessAffterElementParsing.Count > 0);

			var shortLongNamePairs = ShortLongNamePair.Parse("NameConversionTable.csv");
			foreach (var pair in shortLongNamePairs)
			{
				shortLongNameConversionTable[pair.LongName] = pair.ShortName;
			}

            addtionalAttributes = AddtionalAttributes.Parse(File.ReadAllText("AddtionalAttributes.json"));
			
            foreach (var pair in typesTableEachSchema)
			{
				using (var tw = new StreamWriter(Path.Combine(outputDir, pair.Key + ".cs"), false, Encoding.UTF8))
				{
					IndentWriter iw = new IndentWriter(tw);
					iw.WriteLine("using System;");
					iw.WriteLine("using System.Collections.Generic;");
					iw.WriteLine("");
					iw.WriteLine("namespace daradaraM2M.Data");
					iw.WriteLine("{");

					iw.Indent();

					foreach (var item in pair.Value)
					{
						var typeInfo = item.CSTypeInfo;

						GenCode(iw, typeInfo);
					}
					iw.Unindent();
					iw.WriteLine("}");
				}
			}
		}

        static AddtionalAttributes addtionalAttributes;
		static Dictionary<string, string> shortLongNameConversionTable = new Dictionary<string, string>();

		static string GetSimpleTypeClassName(CSTypeInfo typeInfo)
		{
			if (typeInfo.Kind == CSTypeInfo.TypeKind.Alias ||
			   typeInfo.Kind == CSTypeInfo.TypeKind.List ||
			   typeInfo.Kind == CSTypeInfo.TypeKind.Union)
			{
				return $"OM2M{MakeCSIdentifier(typeInfo.Name)}Description";
			}
			else if (typeInfo.Kind == CSTypeInfo.TypeKind.Enum)
			{
				return $"OM2M{MakeCSIdentifier(typeInfo.Name)}";
			}
			else if (typeInfo.Kind == CSTypeInfo.TypeKind.Class && !typeInfo.IsSimpleTypeBase)
			{
				return $"OM2M{MakeCSIdentifier(typeInfo.Name)}";
			}
			else
			{
				return typeInfo.Name;
			}
		}

		static string ModifiedTypeName(CSTypeInfo typeInfo)
		{
			if (typeInfo.SerializedName == null)
			{
				return typeInfo.Name;
			}
			else
			{
				return "OM2M" + typeInfo.Name;
			}
		}

		static void GenCode(IndentWriter iw, CSTypeInfo typeInfo)
		{
			if (typeInfo.Kind == CSTypeInfo.TypeKind.Class)
			{
				GenClassCode(iw, typeInfo);
			}
			else if (typeInfo.Kind == CSTypeInfo.TypeKind.Alias)
			{
				GenAliasCode(iw, typeInfo);
			}
			else if (typeInfo.Kind == CSTypeInfo.TypeKind.List)
			{
				GenListCode(iw, typeInfo);
			}
			else if (typeInfo.Kind == CSTypeInfo.TypeKind.Union)
			{
				GenUnionCode(iw, typeInfo);
			}
		}

		static void GenListCode(IndentWriter iw, CSTypeInfo typeInfo)
		{
			if (typeInfo.ElementType.Name == null)
			{
				typeInfo.ElementType.Name = typeInfo.Name + "_ElementType";

				GenCode(iw, typeInfo.ElementType);
			}

			string elementTypeName = GetSimpleTypeClassName(typeInfo.ElementType);

			if (typeInfo.SerializedName == null) {
				iw.WriteLine($"[OM2MXsdSimpleListType(null, typeof({elementTypeName}))]");
			}
			else
			{
				iw.WriteLine($"[OM2MXsdSimpleListType(\"{typeInfo.SerializedName.Name}\", typeof({elementTypeName}))]");
			}
			iw.WriteLine($"public class OM2M{MakeCSIdentifier(typeInfo.Name)}Description : OM2MXsdSimpleListTypeDescription");
			iw.WriteLine("{");
			iw.Indent();

			iw.Unindent();
			iw.WriteLine("}");
		}

		static void GenAliasCode(IndentWriter iw, CSTypeInfo typeInfo)
		{
			if (typeInfo.BaseType.Name == null)
			{
				typeInfo.BaseType.Name = typeInfo.Name + "_BaseType";

				GenCode(iw, typeInfo.BaseType);
			}

			string baseTypeName = GetSimpleTypeClassName(typeInfo.BaseType);

			if (typeInfo.SerializedName == null)
			{
				iw.WriteLine($"[OM2MXsdSimpleType(null, typeof({baseTypeName}))]");
			}
			else
			{
				iw.WriteLine($"[OM2MXsdSimpleType(\"{typeInfo.SerializedName.Name}\", typeof({baseTypeName}))]");
			}
			iw.WriteLine($"public class OM2M{MakeCSIdentifier(typeInfo.Name)}Description : OM2MXsdSimpleTypeDescription");
			iw.WriteLine("{");
			iw.Indent();

			iw.Unindent();
			iw.WriteLine("}");
		}

		static void GenUnionCode(IndentWriter iw, CSTypeInfo typeInfo)
		{
			int index = 0;
			foreach (var um in typeInfo.UnionMembers)
			{
				if (um.Name == null)
				{
					um.Name = typeInfo.Name + $"_Member{index++}";

					GenCode(iw, um);
				}
			}

			if (typeInfo.SerializedName == null)
			{
				iw.WriteLine($"[OM2MXsdSimpleUnionType(null)]");
			}
			else
			{
				iw.WriteLine($"[OM2MXsdSimpleUnionType(\"{typeInfo.SerializedName.Name}\")]");
			}

			foreach (var um in typeInfo.UnionMembers)
			{
				iw.WriteLine($"[OM2MXsdSimpleUnionTypeMember(typeof({GetSimpleTypeClassName(um.BaseType)}))]");
			}
			iw.WriteLine($"public class OM2M{MakeCSIdentifier(typeInfo.Name)}Description : OM2MXsdSimpleUnionTypeDescription");
			iw.WriteLine("{");
			iw.Indent();

			iw.Unindent();
			iw.WriteLine("}");
		}

		static void GenClassCode(IndentWriter iw, CSTypeInfo typeInfo)
		{
			string shortName;

            var aaa = addtionalAttributes.Types.Where(n => n.Name == typeInfo.Name).Select(n => n);
            var aa = aaa.Count() > 0 ? aaa.First() : null;

			if (typeInfo.IsRootElement)
			{
				if (shortLongNameConversionTable.TryGetValue(typeInfo.SerializedName.Name, out shortName))
				{
					iw.WriteLine($"[OM2MXmlRoot(\"{typeInfo.SerializedName.Name}\",\"{shortName}\")]");
				}
				else
				{
					iw.WriteLine($"[OM2MXmlRoot(\"{typeInfo.SerializedName.Name}\")]");
				}
			}

			if (typeInfo.BaseType != null && !typeInfo.BaseType.IsSimpleTypeBase)
			{
				iw.WriteLine("public partial class {0} : {1}",
				             ModifiedTypeName(typeInfo),
				             ModifiedTypeName(typeInfo.BaseType));
			}
			else
			{
				iw.WriteLine("public partial class {0}",
				             ModifiedTypeName(typeInfo));
			}
			iw.WriteLine("{");
			iw.Indent();


			int index = 0;
			foreach (var pi in typeInfo.Properties)
			{
				if (pi.Type.Name == null)
				{
					pi.Type.Name = typeInfo.Name + $"_Property{index++}";

					GenCode(iw, pi.Type);
				}
			}

			foreach (var pi in typeInfo.Properties)
			{
				StringBuilder sb = new StringBuilder();

                var attribute = aa.Attributes.Where(n => n.Name == pi.Name).Select(n => n);

                if(attribute.Count() > 0)
                {
                    var a = attribute.First();

                    sb.Append($"[OM2MRequestOptionalityAttribute({ConvertRequestOptionalityText(a.Create)},{ConvertRequestOptionalityText(a.Update)})]");
                }

				if (pi.IsXmlAttribute)
				{
                    string columnName;
					if (shortLongNameConversionTable.TryGetValue(pi.SerializedName, out shortName))
					{
						sb.Append($"[OM2MXmlAttribute(\"{pi.SerializedName}\", \"{shortName}\"");
                        columnName = shortName;
					}
					else
					{
						sb.Append($"[OM2MXmlAttribute(\"{pi.SerializedName}\"");
                        columnName = pi.SerializedName;
					}
                    if (pi.Type.Kind == CSTypeInfo.TypeKind.Primitive ||
                       pi.Type == CSTypeInfo.TypeString)
                    {
                        // プリミティブまたはstring
                        sb.Append($"[Column(\"{columnName}\")]");
                    }
				}
				else
				{
					if (shortLongNameConversionTable.TryGetValue(pi.SerializedName, out shortName))
					{
						sb.Append($"[OM2MXmlElement(\"{pi.SerializedName}\", \"{shortName}\"");
					}
					else
					{
						sb.Append($"[OM2MXmlElement(\"{pi.SerializedName}\"");
					}
				}

				if (pi.Type.Kind == CSTypeInfo.TypeKind.Alias ||
				   pi.Type.Kind == CSTypeInfo.TypeKind.List ||
				   pi.Type.Kind == CSTypeInfo.TypeKind.Union)
				{
					sb.Append($", typeof(OM2M{MakeCSIdentifier(pi.Type.Name)}Description)");
				}

				sb.Append(")]");
				iw.WriteLine(sb.ToString());

				if (pi.IsRequired)
				{
					//iw.WriteLine("[OM2MRequired]");
				}

				if (pi.Type.IsList)
				{
					string typeName = GetNonAliasName(pi.Type.ElementType);

					if (/*!pi.IsRequired && */pi.Type.IsValueType)
					{
						typeName = typeName + "?";
					}

					/*
					if (pi.Type.FacetMinLength != 0)
					{
						iw.WriteLine("[OM2MMinLength({0})]", pi.Type.FacetMinLength);
					}

					if (pi.Type.FacetMaxLength != decimal.MaxValue)
					{
						iw.WriteLine("[OM2MMaxLength({0})]", pi.Type.FacetMaxLength);
					}
					*/

					iw.WriteLine($"public List<{typeName}> {pi.Name}");
				}
				else if (pi.Type.IsUnion)
				{
					iw.WriteLine($"public {GetUninTypeName(pi.Type)} {pi.Name}");
				}
				else
				{
					string typeName = GetNonAliasName(pi.Type);

					bool isString = typeName == "string";

					if (isString)
					{
						/*
						if (pi.Type.FacetMinLength != 0)
						{
							iw.WriteLine("[OM2MMinLength({0})]", pi.Type.FacetMinLength);
						}
						if (pi.Type.FacetMaxLength != decimal.MaxValue)
						{
							iw.WriteLine("[OM2MMaxLength({0})]", pi.Type.FacetMaxLength);
						}*/
					}

					if (/*!pi.IsRequired && */pi.Type.IsValueType)
					{
						typeName = typeName + "?";
					}

					iw.WriteLine($"public {typeName} {pi.Name}");
				}
				iw.WriteLine("{");
				iw.Indent();
				iw.WriteLine("get;");
				iw.WriteLine("set;");
				iw.Unindent();
				iw.WriteLine("}");

			}

			if (typeInfo.BaseType != null && typeInfo.BaseType.IsSimpleTypeBase)
			{
				iw.WriteLine("[OM2MXmlValue]");
				iw.WriteLine("public {0} Value", GetNonAliasName(typeInfo.BaseType));
				iw.WriteLine("{");
				iw.Indent();
				iw.WriteLine("get;");
				iw.WriteLine("set;");
				iw.Unindent();
				iw.WriteLine("}");
			}

			if (typeInfo.HasChildren)
			{
				if (!typeInfo.AnyChild)
				{
					/*
					foreach (var childInfo in typeInfo.Children)
					{
						iw.WriteLine("public readonly string Key{0}=\"{1}\";",
									 childInfo.Name,
									 childInfo.SerializedName);
					}
					iw.WriteLine("");
					*/
					foreach (var childInfo in typeInfo.Children)
					{
						if (shortLongNameConversionTable.TryGetValue(childInfo.SerializedName, out shortName))
						{
							iw.WriteLine($"[OM2MXmlElement(\"{childInfo.SerializedName}\", \"{shortName}\", typeof({GetNonAliasName(childInfo.Type)}))]");
						}
						else
						{
							iw.WriteLine("[OM2MXmlElement(\"{0}\", typeof({1}))]",
										 childInfo.SerializedName, GetNonAliasName(childInfo.Type));
						}

						iw.WriteLine($"public List<{GetNonAliasName(childInfo.Type)}> {childInfo.Name}");
						iw.WriteLine("{");
						iw.Indent();
						iw.WriteLine("get;");
						iw.WriteLine("set;");
						iw.Unindent();
						iw.WriteLine("}");
					}
				}
				else
				{
					iw.WriteLine("[OM2MXmlAnyElement]");
					iw.WriteLine("public List<object> Any");
					iw.WriteLine("{");
					iw.Indent();
					iw.WriteLine("get;");
					iw.WriteLine("set;");
					iw.Unindent();
					iw.WriteLine("}");
				}
			}

			foreach (var t in typeInfo.Types)
			{
				GenCode(iw, t);
			}

			iw.Unindent();
			iw.WriteLine("}");
		}

		static string GetNonAliasName(CSTypeInfo typeInfo)
		{
			if (typeInfo.Kind == CSTypeInfo.TypeKind.Alias)
				return GetNonAliasName(typeInfo.BaseType);
			if (typeInfo.Kind == CSTypeInfo.TypeKind.List)
			{
				return string.Format("List<{0}>", GetNonAliasName(typeInfo.ElementType));
			}

			if (typeInfo.Kind == CSTypeInfo.TypeKind.Union)
			{
				return GetUninTypeName(typeInfo);
			}

			return ModifiedTypeName(typeInfo);
		}

		static string GetUninTypeName(CSTypeInfo typeInfo)
		{
			string n = null;
			foreach (var um in typeInfo.UnionMembers)
			{
				var nn = GetNonAliasName(um);
				if (n == null)
				{
					n = nn;
				}
				else
				{
					if (n != nn)
					{
						return "object";
					}
				}
			}
			return n;
		}



		static string ConvertRequestOptionalityText(Optionality o)
		{
			switch (o)
			{
				case Optionality.M:
					return "OM2MRequestOptionalityAttribute.Mandatory";

				case Optionality.O:
					return "OM2MRequestOptionalityAttribute.Optional";

				case Optionality.NP:
					return "OM2MRequestOptionalityAttribute.NotPresent";
				default:
					throw new ArgumentException();
			}
		}
	}
}
