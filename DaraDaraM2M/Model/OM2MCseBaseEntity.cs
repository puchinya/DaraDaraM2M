using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DaraDaraM2M.Data;

namespace DaraDaraM2M.Model
{
	public class OM2MCseBaseEntity : OM2MResourceEntity, IOM2MHasAccessControlPolicyIdsEntity
	{
		private List<string> m_accessControlPolicyIds;

		[Column("acpi")]
		[Required]
		public string AccessControlPolicyIdsCore
		{
			get
			{
				return OM2MJsonSerializer.Serialize(AccessControlPolicyIds);
			}
			set
			{
				m_accessControlPolicyIds = OM2MJsonSerializer.Deserialize<List<string>>(value);
			}
		}

		[NotMapped]
		public List<string> AccessControlPolicyIds
		{
			get
			{
				if (m_accessControlPolicyIds == null)
				{
					m_accessControlPolicyIds = new List<string>();
				}

				return m_accessControlPolicyIds;
			}
		}
		
		[Column("cst")]
		[Required]
		public int CseType { get; set; }

		[Column("csi")]
		[Required]
		public string CseId { get; set; }

		private List<OM2MResourceType> m_supportedResourceType;

		[Column("srt")]
		[Required]
		public string SupportedResourceTypeCore
		{
			get
			{
				return Util.EnumListToString(SupportedResourceType);
			}

			set
			{
				m_supportedResourceType = Util.StringToEnumList<OM2MResourceType>(value);
			}
		}

		[NotMapped]
		public List<OM2MResourceType> SupportedResourceType
		{
			get
			{
				if (m_supportedResourceType == null)
				{
					m_supportedResourceType = new List<OM2MResourceType>();
				}
				return m_supportedResourceType;
			}
		}

		private List<string> m_pointOfAccess;

		[Column("poa")]
		[Required]
		public string PointOfAccessCore
		{
			get
			{
				return Util.StringListToString(PointOfAccess);
			}
			set
			{
				m_pointOfAccess = Util.StringToStringList(value);
			}
		}

		[NotMapped]
		public List<string> PointOfAccess
		{
			get
			{
				if (m_pointOfAccess == null)
				{
					m_pointOfAccess = new List<string>();
				}

				return m_pointOfAccess;
			}
		}

		[Column("nl")]
		public string NodeLink
		{
			get;
			set;
		}
	}
}
