using System;
namespace DaraDaraM2M.Data
{
	public class OM2MTypeConstraintsAttribute : Attribute
	{
		public OM2MTypeConstraintsAttribute(params Type[] types)
		{
			Types = types;
		}

		public Type[] Types
		{
			get;
			private set;
		}
	}

	public sealed class OM2MIgnoreAttribute : Attribute
	{
	}

	public sealed class OM2MRequiredAttribute : Attribute
	{
	}

	[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
	public sealed class OM2MElementAttribute : Attribute
	{
		public OM2MElementAttribute(string elementName)
		{
			ElementName = elementName;
		}

		public OM2MElementAttribute(string elementName, Type type)
		{
			ElementName = elementName;
			Type = type;
		}

		public string ElementName
		{
			get;
			private set;
		}

		public Type Type
		{
			get;
			private set;
		}
	}

	[AttributeUsage(AttributeTargets.Class)]
	public sealed class OM2MXmlRootAttribute : Attribute
	{
		public OM2MXmlRootAttribute(string elementName)
		{
			ElementName = elementName;
			ElementShortName = elementName;
		}

		public OM2MXmlRootAttribute(string elementName,
		                           string elementShortName)
		{
			ElementName = elementName;
			ElementShortName = elementShortName;
		}

		public string ElementName
		{
			get;
			set;
		}

		public string ElementShortName
		{
			get;
			set;
		}
	}

	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public sealed class OM2MXmlValueAttribute : Attribute
	{
	}

	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public sealed class OM2MXmlAttributeAttribute : Attribute
	{
		public OM2MXmlAttributeAttribute(string attributeName)
		{
			AttributeName = attributeName;
			AttributeShortName = attributeName;
		}

		public OM2MXmlAttributeAttribute(string attributeName,
		                                string attributeShortName)
		{
			AttributeName = attributeName;
			AttributeShortName = attributeShortName;
		}

		public string AttributeName
		{
			get;
			set;
		}

		public string AttributeShortName
		{
			get;
			set;
		}
	}

	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple=true)]
	public sealed class OM2MXmlElementAttribute : Attribute
	{
		public OM2MXmlElementAttribute(string elementName)
		{
			ElementName = elementName;
			ElementShortName = elementName;
		}

		public OM2MXmlElementAttribute(string elementName, Type type)
		{
			ElementName = elementName;
			ElementShortName = elementName;
			Type = type;
		}

		public OM2MXmlElementAttribute(string elementName,
								   string elementShortName)
		{
			ElementName = elementName;
			ElementShortName = elementShortName;
		}

		public OM2MXmlElementAttribute(string elementName,
								   string elementShortName, Type type)
		{
			ElementName = elementName;
			ElementShortName = elementShortName;
			Type = type;
		}

		public string ElementName
		{
			get;
			set;
		}

		public string ElementShortName
		{
			get;
			set;
		}

		public Type Type
		{
			get;
			set;
		}
	}

	public class OM2MMinLengthAttribute : Attribute
	{
		public OM2MMinLengthAttribute(long value)
		{
			Value = value;
		}

		public long Value
		{
			get;
			private set;
		}
	}

	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public sealed class OM2MXmlAnyElementAttribute : Attribute
	{
		public OM2MXmlAnyElementAttribute()
		{
		}
	}

	public class OM2MMaxLengthAttribute : Attribute
	{
		public OM2MMaxLengthAttribute(long value)
		{
			Value = value;
		}

		public long Value
		{
			get;
			private set;
		}
	}

	[AttributeUsage(AttributeTargets.Class)]
	public sealed class OM2MNamespaceAttribute : Attribute
	{
		public OM2MNamespaceAttribute(string value)
		{
			Value = value;
		}

		public string Value
		{
			get;
			set;
		}
	}

	[AttributeUsage(AttributeTargets.Class)]
	public class OM2MXsdSimpleTypeAttribute : Attribute
	{
		public OM2MXsdSimpleTypeAttribute(string name, Type baseType)
		{
			Name = name;
			BaseType = baseType;
		}

		public string Name
		{
			get;
			set;
		}

		public Type BaseType
		{
			get;
			set;
		}
	}

	[AttributeUsage(AttributeTargets.Class)]
	public class OM2MXsdSimpleListTypeAttribute : Attribute
	{
		public OM2MXsdSimpleListTypeAttribute(string name, Type elementType)
		{
			Name = name;
			ElementType = elementType;
		}

		public string Name
		{
			get;
			set;
		}

		public Type ElementType
		{
			get;
			set;
		}
	}

	[AttributeUsage(AttributeTargets.Class)]
	public class OM2MXsdSimpleUnionTypeAttribute : Attribute
	{
		public OM2MXsdSimpleUnionTypeAttribute(string name)
		{
			Name = name;
		}

		public string Name
		{
			get;
			set;
		}
	}

	[AttributeUsage(AttributeTargets.Class, AllowMultiple=true)]
	public class OM2MXsdSimpleUnionTypeMemberAttribute : Attribute
	{
		public OM2MXsdSimpleUnionTypeMemberAttribute(Type type)
		{
			Type = type;
		}

		public Type Type
		{
			get;
			set;
		}
	}

	[AttributeUsage(AttributeTargets.All)]
	public class OM2MRestrictionAttribute : Attribute
	{
		public OM2MRestrictionAttribute()
		{
		}

		public long? MaxLength
		{
			get;
			set;
		}

		public long? MinLength
		{
			get;
			set;
		}

		public long? Length
		{
			get;
			set;
		}

		public string[] Patterns
		{
			set;
			get;
		}

		public string Pattern
		{
			get;
			set;
		}
	}

	public class OM2MXsdSimpleTypeDescription
	{
	}

	public class OM2MXsdSimpleListTypeDescription
	{
	}

	public class OM2MXsdSimpleUnionTypeDescription
	{
	}
}
