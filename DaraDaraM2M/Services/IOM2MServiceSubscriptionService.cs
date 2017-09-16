using System;
using DaraDaraM2M.Data;

namespace DaraDaraM2M.Services
{
	public interface IOM2MServiceSubscriptionService
	{
		OM2MResponseStatusCode ValidateServiceSubscroption(string serviceSubscriptionId,
												string serviceCapId);

		OM2MResponseStatusCode GetAE(string aeId,
									 out string applicationId,
									 out string serviceSubscriptionId,
									 out string[] externalIds,
									 out OM2MSchedule reachabilitySchedule);

		OM2MResponseStatusCode GetBroker(string serviceSubscriptionId,
										 string serviceCapId,
										 string aeId,
										 string resource,
										 out IOM2MBrokerService broker);

		OM2MResponseStatusCode GetManagmentAdapter(string serviceSubscriptionId,
												   string serviceCapId,
												   string deviceId,
												   out IOM2MManagmentAdapterService managementAdapter);

		OM2MResponseStatusCode GetTransportAdapter(string serviceSubscriptionId,
												   string serviceCapId,
												   string deviceId,
												   out object transportAdapter);
		
		OM2MResponseStatusCode AssociateAEWithServiceSubscription(string aeId,
																 string credentialId,
																 string applicationId,
																 out string serviceSubscriptionId);

		OM2MResponseStatusCode DisassociateAEFromServiceSubscription(string aeId,
																	 string serviceSubscriptionId);

		OM2MResponseStatusCode RefreshAEAssociationWithServiceSubscription(string aeId,
																		   string serviceSubscriptionId);
	}
}
