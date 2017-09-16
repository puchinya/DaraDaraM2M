using System;
using DaraDaraM2M.Services;
using DaraDaraM2M.Components;

namespace DaraDaraM2M
{
	public class OM2MServiceSubscriptionComponentImpl : IOM2MServiceSubscriptionComponent
	{
		public OM2MServiceSubscriptionComponentImpl()
		{
			ServiceSubscription = new OM2MSSUBServiceSubscriptionImpl();
			ServiceAdministration = new OM2MSSUBServiceAdministrationServiceImpl();
		}

		public IOM2MServiceSubscriptionService ServiceSubscription
		{
			get;
			private set;
		}

		public IOM2MServiceAdministrationService ServiceAdministration
		{
			get;
			private set;
		}

		public IOM2MServiceSubscriptionAdministrationService ServiceSubscriptionAdministration
		{
			get;
			private set;
		}
	}
}
