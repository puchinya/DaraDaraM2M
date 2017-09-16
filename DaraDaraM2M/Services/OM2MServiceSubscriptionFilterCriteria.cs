using System;
namespace DaraDaraM2M.Services
{
	public class OM2MServiceSubscriptionFilterCriteria
	{
		/// <summary>
		/// List of the M2M Service Subscription Identifiers (M2M-Service-Profile-ID).
		/// </summary>
		public string[] ServiceSubscriptionIds
		{
			get;
			set;
		}

		/// <summary>
		/// List of Service Role Identifiers (SRole-ID) associated with the M2M Service Subscription entity.
		/// </summary>
		public string[] serviceRoleIds
		{
			get;
			set;
		}
	}
}
