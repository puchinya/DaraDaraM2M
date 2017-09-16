using System;
using System.Collections.Generic;
using DaraDaraM2M.Data;

namespace DaraDaraM2M.Data
{
	public interface IOM2MResource
	{
		string ResourceName { get; set; }
		OM2MResourceType? ResourceType { get; set; }
		string ResourceID { get; set; }
		string ParentID { get; set; }
		string CreationTime { get; set; }
		string LastModifiedTime { get; set; }
		List<string> Labels { get; set; }
	}

	public interface IOM2MChildResourceContainer
	{
		List<OM2MChildResourceRef> ChildResource
		{
			get;
			set;
		}
	}

	public partial class OM2MResource : IOM2MResource
	{
	}

	public partial class OM2MFlexContainerResource : IOM2MResource
	{
	}

	public partial class OM2MAnnouncedFlexContainerResource : IOM2MResource
	{
	}

	public partial class OM2MAE : IOM2MChildResourceContainer
	{
	}

	public partial class OM2MCSEBase : IOM2MChildResourceContainer
	{
	}

	public partial class OM2MContainer : IOM2MChildResourceContainer
	{
	}

	public partial class OM2MRequestPrimitive
	{
		[OM2MIgnore]
		public string TargetId
		{
			get;
			set;
		}

		[OM2MIgnore]
		public object Content
		{
			get;
			set;
		}
	}

	public partial class OM2MResponsePrimitive
	{
		public OM2MResponsePrimitive(OM2MCseConfig cseConfig)
		{
			From = "/" + cseConfig.CseBaseId;
		}

		public OM2MResponsePrimitive(OM2MCseConfig cseConfig, OM2MRequestPrimitive request)
		{
			RequestIdentifier = request.RequestIdentifier;
			From = "/" + cseConfig.CseBaseId;
			To = request.From;
		}

		[OM2MIgnore]
		public object Content
		{
			get;
			set;
		}
	}
}
