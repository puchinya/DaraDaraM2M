using System;
using System.ComponentModel.DataAnnotations;

namespace DaraDaraM2M.Model
{
	public class OM2MDbServiceSubscription
	{
		public int ID { get; set; }
		[Required]
		public string ServiceSubscriptionId { get; set; }
		[Required]
		public string AEId { get; set; }
		public string CredentialId { get; set; }
		public string ApplicationId { get; set; }
	}
}
