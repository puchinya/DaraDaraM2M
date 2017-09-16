using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaraDaraM2M.Model
{
	public class OM2MServiceEntity
	{
		public int ID { get; set; }

		[Required]
		public string ServiceId { get; set; }

		[Required]
		public string Name { get; set; }

		public string Description { get; set; }

		public string ServiceRoleIdsCore
		{
			get
			{
				if (ServiceRoleIds == null)
				{
					return null;
				}
				return string.Join(" ", ServiceRoleIds.ToArray());
			}

			set
			{
				if (value == null)
				{
					ServiceRoleIds = null;
				}
				else
				{
					ServiceRoleIds = new List<string>(value.Split(' '));
				}
			}
		}

		[NotMapped]
		public List<string> ServiceRoleIds { get; set; }
	}
}
