using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DaraDaraM2M
{
	public class OM2MDbServiceRole
	{
		public int ID { get; set; }

		[Required]
		public string ServiceRoleId { get; set; }

	}
}
