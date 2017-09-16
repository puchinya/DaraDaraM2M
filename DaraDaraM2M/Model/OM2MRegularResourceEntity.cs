using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DaraDaraM2M.Data;

namespace DaraDaraM2M.Model
{
	public class OM2MRegularResourceEntity : OM2MResourceEntity, IOM2MHasAccessControlPolicyIdsEntity
	{
		private List<string> m_accessControlPolicyIds;

		[Column("acpi")]
		[Required]
		public string AccessControlPolicyIdsCore
		{
			get
			{
				return Util.StringListToString(AccessControlPolicyIds);
			}
			set
			{
				m_accessControlPolicyIds = Util.StringToStringList(value);
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

		[Column("et")]
		[Required]
		public string ExpirationTime
		{
			get;
			set;
		}
	}
}
