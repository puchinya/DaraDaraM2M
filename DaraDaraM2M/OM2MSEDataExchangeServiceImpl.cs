using System;
using DaraDaraM2M.Data;
using DaraDaraM2M.Services;

namespace DaraDaraM2M
{
	public class OM2MSEDataExchangeServiceImpl : IOM2MDataExchangeService
	{
		public OM2MSEDataExchangeServiceImpl(IOM2MServiceSubscriptionService ssubServiceSubscription)
		{
			ServiceSubscription = ssubServiceSubscription;
		}

		private IOM2MServiceSubscriptionService ServiceSubscription
		{
			get;
			set;
		}

		public OM2MResponseStatusCode Subscribe(string publicationResource,
										 OM2MDeliveryPolicy deliveryPolicy,
										 OM2MDeliveryPolicy retainmentPolicy)
		{
			throw new NotImplementedException();
		}

		public OM2MResponseStatusCode Publish(string toResource,
									   OM2MDeliveryPolicy deliveryPolicy,
									   object payload)
		{
			throw new NotImplementedException();
		}

		public OM2MResponseStatusCode Notify(object payload,
									  string fromResource,
									  OM2MDeliveryPolicy deliveryPolicy)
		{
			throw new NotImplementedException();
		}

		public OM2MResponseStatusCode SendMessage(OM2MDeliveryPolicy deliveryPolicy,
										   object payload)
		{
			throw new NotImplementedException();
		}
	}
}
