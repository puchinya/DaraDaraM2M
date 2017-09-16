using System;
using System.Linq;
using System.Collections.Generic;
using DaraDaraM2M.Data;
using DaraDaraM2M.Model;
using Microsoft.EntityFrameworkCore;

namespace DaraDaraM2M.Controllers
{
	public class OM2MCseBaseController : OM2MController
	{
		public OM2MCseBaseController(OM2MCseServiceImpl cseService)
			: base(cseService)
		{
		}

		public override OM2MResponsePrimitive DoCreate(OM2MRequestPrimitive request)
		{
			throw new OM2MOperationNotAllowedException("Create of CSEBase is not allowed.");
		}

		public override OM2MResponsePrimitive DoRetrieve(OM2MRequestPrimitive request)
		{
			using (var db = CreateDbContext())
			{
				// Check existence of the resource
				var cseBaseEntity = db.Resources.Find(request.TargetId) as OM2MCseBaseEntity;
				if (cseBaseEntity == null)
				{
					throw new OM2MNotFoundException($"Resouce {request.TargetId} not found.");
				}

				// Check authorization
				var acpList = new List<OM2MAccessControlPolicyEntity>();
				foreach (var i in cseBaseEntity.AccessControlPolicyIds)
				{
					var queryAcp = db.Resources.Where(x => x.ResourceId == i)
										 .OfType<OM2MAccessControlPolicyEntity>()
										 .Include(x => x.PrivilegesCore);

					if (queryAcp.Count() == 0)
					{
						// Damaged
						continue;
					}

					acpList.Add(queryAcp.First());
				}

				CheckACP(acpList, request.From, request.Operation.Value);

				OM2MResultContent resultContent = request.ResultContent ?? OM2MResultContent.Attributes;

				if (resultContent.HasChildResourceReferences())
				{
					db.Entry(cseBaseEntity).Collection(x => x.Resources)
					  .Load();
				}

				OM2MCSEBase cseBaseResource = cseBaseEntity.ToResource(resultContent);

				var response = new OM2MResponsePrimitive(CseConfig, request);
				response.ResponseStatusCode = OM2MResponseStatusCode.Ok;
				response.Content = cseBaseResource;

				return response;
			}
		}

		public override OM2MResponsePrimitive DoUpdate(OM2MRequestPrimitive request)
		{
			throw new OM2MOperationNotAllowedException("Update of CSEBase is not allowed.");
		}

		public override OM2MResponsePrimitive DoDelete(OM2MRequestPrimitive request)
		{
			throw new OM2MOperationNotAllowedException("Delete of CSEBase is not allowed.");
		}
	}
}
