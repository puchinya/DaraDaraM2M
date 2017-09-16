using System;
namespace DaraDaraM2M.Services
{
	public class OM2MServiceSubscriptionNodeEntitiy
	{
		/// <summary>
		/// The M2M Service Subscription Identifier (M2M-Service-Profile-ID) for the Device.
		/// </summary>
		public string ServiceSubscriptionId
		{
			get;
			set;
		}

		/// <summary>
		/// The unique M2M Node identifier in the context of the M2M Service Subscription.
		/// </summary>
		/// <value>The node identifier.</value>
		public string NodeId
		{
			get;
			set;
		}

		/// <summary>
		/// List of URNs that represent the external identifiers associated with this M2M Node.
		/// </summary>
		/// <value>The external identifiers.</value>
		public string[] ExternalIds
		{
			get;
			set;
		}

		/// <summary>
		/// List of Application Rules Identifiers associated with the M2M Node.
		/// </summary>
		/// <value>The application rule identifiers.</value>
		public string[] ApplicationRuleIds
		{
			get;
			set;
		}
	}
}
