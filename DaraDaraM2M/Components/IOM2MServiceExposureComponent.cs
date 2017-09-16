using System;
using DaraDaraM2M.Services;

namespace DaraDaraM2M.Components
{
	public interface IOM2MServiceExposureComponent
	{
		IOM2MDataExchangeService DataExchange
		{
			get;
		}
		
		IOM2MServiceSubscriptionAdministrationService ServiceSubscriptionAdministration
		{
			get;
		}

		IOM2MRegistrationService Registration
		{
			get;
		}
	}
}
