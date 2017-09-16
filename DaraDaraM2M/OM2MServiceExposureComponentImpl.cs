using System;
using System.Linq;
using System.Diagnostics;
using DaraDaraM2M.Data;
using DaraDaraM2M.Services;
using DaraDaraM2M.Components;

namespace DaraDaraM2M
{
	public class OM2MServiceExposureComponentImpl : IOM2MServiceExposureComponent
	{
		public OM2MServiceExposureComponentImpl(IOM2MServiceSubscriptionComponent ssub)
		{
			SSUB = ssub;

			Registration = new OM2MSERegistrationServiceImpl(ssub.ServiceSubscription);
		}

		public IOM2MDataExchangeService DataExchange
		{
			get;
			private set;
		}

		public IOM2MServiceSubscriptionAdministrationService ServiceSubscriptionAdministration
		{
			get;
			private set;
		}

		public IOM2MRegistrationService Registration
		{
			get;
			private set;
		}

		private IOM2MServiceSubscriptionComponent SSUB
		{
			get;
			set;
		}
	}
}
