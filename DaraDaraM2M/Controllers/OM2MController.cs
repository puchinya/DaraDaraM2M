using System;
using System.Collections.Generic;
using System.Linq;
using DaraDaraM2M.Data;
using DaraDaraM2M.Model;

namespace DaraDaraM2M.Controllers
{
	public abstract class OM2MController
	{
	    protected OM2MController(OM2MCseServiceImpl cseService)
		{
			CseService = cseService;
		}

		public OM2MCseServiceImpl CseService
		{
			get;
		}

		public OM2MCseConfig CseConfig => CseService.CseConfig;

	    protected OM2MDbContext CreateDbContext()
		{
			return new OM2MDbContext();
		}

		protected void CheckACP(List<OM2MAccessControlPolicyEntity> acpList, string originator, OM2MOperation operation)
		{
			if (acpList != null && originator != null)
			{
				foreach (var acp in acpList)
				{
					foreach (var rule in acp.Privileges)
					{
						if (CheckRule(rule, originator, operation))
						{
							return;
						}
					}
				}
			}

			throw new OM2MException(OM2MResponseStatusCode.Forbidden);
		}

		protected void CheckSelfACP(OM2MAccessControlPolicyEntity acp, string originator, OM2MOperation operation)
		{
			if (acp != null && originator != null)
			{
				foreach (var rule in acp.SelfPrivileges)
				{
					if (CheckRule(rule, originator, operation))
					{
						return;
					}
				}
			}

			throw new OM2MException(OM2MResponseStatusCode.Forbidden);
		}

		private bool CheckRule(OM2MAccessControlRuleEntity rule, string originator, OM2MOperation operation)
		{
			if (FindOriginator(rule.AccessControlOriginators, originator))
			{
				if (operation == OM2MOperation.Create &&
				    (rule.AccessControlOperations & (int)OM2MAccessControlOperations.Create) != 0)
				{
					return true;
				}
				if (operation == OM2MOperation.Retrieve &&
					(rule.AccessControlOperations & (int)OM2MAccessControlOperations.Retrieve) != 0)
				{
					return true;
				}
				if (operation == OM2MOperation.Update &&
					(rule.AccessControlOperations & (int)OM2MAccessControlOperations.Update) != 0)
				{
					return true;
				}
				if (operation == OM2MOperation.Delete &&
					(rule.AccessControlOperations & (int)OM2MAccessControlOperations.Delete) != 0)
				{
					return true;
				}
				if (operation == OM2MOperation.Notify &&
					(rule.AccessControlOperations & (int)OM2MAccessControlOperations.Notify) != 0)
				{
					return true;
				}
			}

			return false;
		}

		private static bool FindOriginator(IEnumerable<string> originators, string originator)
		{
		    return originators.Any(o => originator == o);
		}

		public OM2MResponsePrimitive DoRequest(OM2MRequestPrimitive request)
		{
			OM2MResponsePrimitive response;

			try
			{
			    switch (request.Operation)
			    {
			        case OM2MOperation.Create:
			            response = DoCreate(request);
			            break;
			        case OM2MOperation.Retrieve:
			            response = DoRetrieve(request);
			            break;
			        case OM2MOperation.Update:
			            response = DoUpdate(request);
			            break;
			        case OM2MOperation.Delete:
			            response = DoDelete(request);
			            break;
			        default:
			            throw new OM2MBadRequestException($"Invalid operation value: {request.Operation}");
			    }
			}
			catch (OM2MBadRequestException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine($"Controller internal error: {ex}");
				throw ex;
			}

			return response;
		}

		public abstract OM2MResponsePrimitive DoCreate(OM2MRequestPrimitive request);
		public abstract OM2MResponsePrimitive DoRetrieve(OM2MRequestPrimitive request);
		public abstract OM2MResponsePrimitive DoUpdate(OM2MRequestPrimitive request);
		public abstract OM2MResponsePrimitive DoDelete(OM2MRequestPrimitive request);
	}
}
