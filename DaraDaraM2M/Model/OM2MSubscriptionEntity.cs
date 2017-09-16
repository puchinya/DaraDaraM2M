using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DaraDaraM2M.Data;

namespace DaraDaraM2M.Model
{
	public class OM2MSubscriptionEntity : OM2MRegularResourceEntity
	{
		[Column("cr")]
		public string Creator
		{
			get;
			set;
		}

		[Column("ec")]
		public int? ExpirationCounter
		{
			get;
			set;
		}
	}
}
