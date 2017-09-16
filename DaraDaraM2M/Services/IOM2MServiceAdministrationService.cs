using System;
using DaraDaraM2M.Data;

namespace DaraDaraM2M.Services
{
	public interface IOM2MServiceAdministrationService
	{
		OM2MResponseStatusCode CreateM2MService(string name, string description, out string serviceId);
		OM2MResponseStatusCode DeleteM2MService(string serviceId);
		OM2MResponseStatusCode AddRoleToM2MService(string serviceId,
								 string[] serviceRoleIds);
		OM2MResponseStatusCode DeleteRoleFromM2MService(string serviceId,
									  string[] serviceRoleIds);
		OM2MResponseStatusCode GetM2MService(OM2MServiceSubscriptionFilterCriteria filterCriteria,
						   out OM2MServiceEntity[] services);
		OM2MResponseStatusCode AddServiceCapabilityToRole(string serviceCapId,
									   string[] serviceRoleIds);
		OM2MResponseStatusCode DeleteServiceCapabilityToRole(string serviceCapId,
									   string[] serviceRoleIds);
		OM2MResponseStatusCode GetServiceCapability(OM2MOperation operation,
								  out string serviceCapId,
								  out string[] serviceRoleIds);
	}
}
