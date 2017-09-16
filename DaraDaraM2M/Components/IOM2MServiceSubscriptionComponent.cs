using System;
using DaraDaraM2M.Services;

namespace DaraDaraM2M.Components
{
	public interface IOM2MServiceSubscriptionComponent
	{
		IOM2MServiceSubscriptionService ServiceSubscription
		{
			get;
		}

		IOM2MServiceAdministrationService ServiceAdministration
		{
			get;
		}

		IOM2MServiceSubscriptionAdministrationService ServiceSubscriptionAdministration
		{
			get;
		}
	}
}
