using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DaraDaraM2M.Data;

namespace DaraDaraM2M.Model
{
	public class OM2MAccessControlPolicyEntity : OM2MAnnounceableSubordinateResourceEntity
	{
		[Column("pv")]
		[InverseProperty("Privilege")]
		public List<OM2MAccessControlRuleEntity> PrivilegesCore
		{
			get;
			set;
		}

		[NotMapped]
		public List<OM2MAccessControlRuleEntity> Privileges
		{
			get
			{
				if (PrivilegesCore == null)
				{
					PrivilegesCore = new List<OM2MAccessControlRuleEntity>();
				}

				return PrivilegesCore;
			}
		}

		[Column("pvs")]
		[InverseProperty("SelfPrivilege")]
		public virtual List<OM2MAccessControlRuleEntity> SelfPrivilegesCore
		{
			get;
			set;
		}

		[NotMapped]
		public List<OM2MAccessControlRuleEntity> SelfPrivileges
		{
			get
			{
				if (SelfPrivilegesCore == null)
				{
					SelfPrivilegesCore = new List<OM2MAccessControlRuleEntity>();
				}

				return SelfPrivilegesCore;
			}
		}
	}

	[Table("acrs")]
	public class OM2MAccessControlRuleEntity
	{
		public int Id
		{
			get;
			set;
		}

		private List<string> m_accessControlOriginators;

		[Column("acor")]
		[Required]
		public string AccessControlOriginatorsCore
		{
			get
			{
				return Util.StringListToString(AccessControlOriginators);
			}
			set
			{
				m_accessControlOriginators = Util.StringToStringList(value);
			}
		}

		[NotMapped]
		public List<string> AccessControlOriginators
		{
			get
			{
				if (m_accessControlOriginators == null)
				{
					m_accessControlOriginators = new List<string>();
				}

				return m_accessControlOriginators;
			}
		}

		[Column("acop")]
		[Required]
		public int AccessControlOperations
		{
			get;
			set;
		}

		public bool? AccessControlAuthenticationFlag
		{
			get;
			set;
		}

		[Column("_pv_owner_id")]
		public string PrivilegeId
		{
			get;
			set;
		}

		[ForeignKey("PrivilegeId")]
		public OM2MAccessControlPolicyEntity Privilege
		{
			get;
			set;
		}

		[Column("_pvs_owner_id")]
		public string SelfPrivilegeId
		{
			get;
			set;
		}

		[ForeignKey("SelfPrivilegeId")]
		public OM2MAccessControlPolicyEntity SelfPrivilege
		{
			get;
			set;
		}
	}
}
