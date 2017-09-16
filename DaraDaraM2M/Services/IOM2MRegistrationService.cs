using System;
using DaraDaraM2M.Data;

namespace DaraDaraM2M.Services
{
	public interface IOM2MRegistrationService
	{
		/// <summary>
		/// Registers the ae.
		/// </summary>
		/// <returns>The ae.</returns>
		/// <param name="pointOfAccess">The point of Access of the registered AE.</param>
		/// <param name="applicationId">The Application Identifier (App-ID).</param>
		/// <param name="credentialId">Application Credential-ID used to identify the Application Entity for the Application. It is used to retrieve the corresponding M2M Service Subscription.</param>
		/// <param name="exprirationTime">The expiration time of the registration as requested by the Originator.</param>
		/// <param name="reachabilitySchedule">The contact reachability schedule information of the AE associated with the device node. The absence of this parameter implies the AE associated with the device node is always contact reachable.</param>
		/// <param name="aeId">Ae identifier.</param>
		/// credentialId is optional. (can set null)
		/// reachabilitySchedule is optional. (can set null)
		OM2MResponseStatusCode RegisterAE(string pointOfAccess,
						string applicationId,
						string credentialId,
						DateTime exprirationTime,
						OM2MSchedule reachabilitySchedule,
						ref string aeId);

		OM2MResponseStatusCode RefreshAERegistration(string aeId,
											   string pointOfAccess,
											   DateTime expirationTime,
											   OM2MSchedule reachabilitySchedule);
		OM2MResponseStatusCode DeregisterAE(string aeId);
	}
}
