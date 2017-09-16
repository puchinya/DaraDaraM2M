using System;
using DaraDaraM2M.Data;
using DaraDaraM2M.Services;

namespace DaraDaraM2M.SupportingServices
{
	public interface IOM2MDataExchangeSupportingService
	{
		OM2MResponseStatusCode SubscribeRequest(string from_,
												ref string requestId,
		                                        OM2MOperation operation,
												string to,
												string publicationResource,
												OM2MDeliveryPolicy deliveryPolicy,
												OM2MDeliveryPolicy retainmentPolicy,
												out IOM2MBrokerService transportAdapter);
		
	}
}
