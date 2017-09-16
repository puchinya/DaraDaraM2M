using System;
using DaraDaraM2M.Data;

namespace DaraDaraM2M.Services
{
	public interface IOM2MBrokerService
	{
		OM2MResponseStatusCode Subscribe(string publicationResource,
										 OM2MDeliveryPolicy deliveryPolicy,
										 OM2MDeliveryPolicy retainmentPolicy);
		OM2MResponseStatusCode Publish(string toResource,
									   OM2MDeliveryPolicy deliveryPolicy,
									   object payload);
		OM2MResponseStatusCode Notify(object payload,
									  string fromResource,
									  OM2MDeliveryPolicy deliveryPolicy);
		OM2MResponseStatusCode SendMessage(OM2MDeliveryPolicy deliveryPolicy,
										   object payload);
		                                 
	}
}
