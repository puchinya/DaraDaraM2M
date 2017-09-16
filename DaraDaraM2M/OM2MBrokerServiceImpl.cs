using System;
using System.Linq;
using DaraDaraM2M.Data;
using DaraDaraM2M.Services;
using System.Diagnostics;

namespace DaraDaraM2M
{
	public class OM2MBrokerServiceImpl : IOM2MBrokerService
	{
		private string ServiceSubscriptionId { get; set; }
		private string ServiceCapId { get; set; }
		private string AeId { get; set; }
		private string Resource { get; set; }
		
		public OM2MBrokerServiceImpl(string serviceSubscriptionId,
										 string serviceCapId,
										 string aeId,
										 string resource)
		{
			ServiceSubscriptionId = serviceSubscriptionId;
			ServiceCapId = serviceCapId;
			AeId = aeId;
			Resource = resource;
		}

		public OM2MResponseStatusCode Subscribe(string publicationResource,
										 OM2MDeliveryPolicy deliveryPolicy,
												OM2MDeliveryPolicy retainmentPolicy)
		{
			return OM2MResponseStatusCode.Ok;
		}

		public OM2MResponseStatusCode Publish(string toResource,
									   OM2MDeliveryPolicy deliveryPolicy,
									   object payload)
		{
			return OM2MResponseStatusCode.Ok;
		}

		public OM2MResponseStatusCode Notify(object payload,
									  string fromResource,
									  OM2MDeliveryPolicy deliveryPolicy)
		{
			return OM2MResponseStatusCode.Ok;
		}

		public OM2MResponseStatusCode SendMessage(OM2MDeliveryPolicy deliveryPolicy,
										   object payload)
		{
			return OM2MResponseStatusCode.Ok;
		}
	}
}
