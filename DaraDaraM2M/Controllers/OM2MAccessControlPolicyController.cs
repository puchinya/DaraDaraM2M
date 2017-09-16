using System;
using System.Collections.Generic;
using System.Linq;
using DaraDaraM2M.Data;
using DaraDaraM2M.Model;
using Microsoft.EntityFrameworkCore;

namespace DaraDaraM2M.Controllers
{
	public class OM2MAccessControlPolicyController : OM2MController
	{
		public OM2MAccessControlPolicyController(OM2MCseServiceImpl cseService)
			: base(cseService)
		{
		}

		// ToDo:
		public override OM2MResponsePrimitive DoCreate(OM2MRequestPrimitive request)
		{
			using (var db = CreateDbContext())
			{
				var query = db.Resources.Where(x => x.ResourceId == request.TargetId);
				
				if (query.Count() == 0)
				{
					throw new OM2MNotFoundException("Can not find parent resource.");
				}

				var parentEntity = query.First();

				var acpList = db.GetAcpList(parentEntity);

				CheckACP(acpList, request.From, OM2MOperation.Create);

				if (request.Content == null)
				{
					throw new OM2MBadRequestException("A content is required for creation.");
				}

				var entity = new OM2MAccessControlPolicyEntity();

				var resource = request.Content as OM2MAccessControlPolicy;

				if (resource == null)
				{
					throw new OM2MBadRequestException("Incorrect resource representation in content.");
				}

				if (resource.Privileges == null)
				{
					throw new OM2MBadRequestException("Privileges is mandatory.");
				}
				if (resource.SelfPrivileges == null)
				{
					throw new OM2MBadRequestException("SelfPrivileges is mandatory.");
				}

				entity.CreationTime = OM2MTimeStamp.NowTimeStamp;
				entity.LastModifiedTime = entity.CreationTime;
				entity.ParentId = parentEntity.ResourceId;
				entity.ResourceType = (int)OM2MResourceType.AccessControlPolicy;

				if (resource.ExpirationTime != null)
				{
					entity.ExpirationTime = resource.ExpirationTime;
				}

				if (resource.Labels != null)
				{
					entity.Labels.Clear();
					entity.Labels.AddRange(resource.Labels);
				}

				if (resource.AnnounceTo != null)
				{
					entity.AnnounceTo.AddRange(resource.AnnounceTo);
				}

				if (resource.AnnouncedAttribute != null)
				{
					entity.AnnouncedAttribute.AddRange(resource.AnnouncedAttribute);
				}

				foreach (var rule in resource.Privileges.AccessControlRule)
				{
					entity.Privileges.Add(rule.ToEntity());
				}

				foreach (var rule in resource.SelfPrivileges.AccessControlRule)
				{
					entity.SelfPrivileges.Add(rule.ToEntity());
				}

				db.Resources.Add(entity);

				db.SaveChanges();

				var subs = db.Resources.OfType<OM2MSubscriptionEntity>().Where(x => x.ParentId == parentEntity.ResourceId).ToList();
				CseService.Notify(subs, parentEntity, OM2MResourceStatus.ChildCreated);

				var response = new OM2MResponsePrimitive(CseConfig, request);

				response.Content = entity.ToResource(OM2MResultContent.Attributes);
				response.ResponseStatusCode = OM2MResponseStatusCode.Created;

				return response;
			}
		}

		public override OM2MResponsePrimitive DoRetrieve(OM2MRequestPrimitive request)
		{
			using (var db = CreateDbContext())
			{
				var query = db.Resources.OfType<OM2MAccessControlPolicyEntity>()
				              .Where(x => x.ResourceId == request.TargetId)
				              .Include(x => x.Privileges)
				              .Include(x => x.SelfPrivileges);

				if (query.Count() == 0)
				{
					throw new OM2MNotFoundException("Resource not found.");
				}

				var entity = query.First();

				CheckSelfACP(entity, request.From, OM2MOperation.Retrieve);

				var response = new OM2MResponsePrimitive(CseConfig, request);

				var resource = entity.ToResource(request.ResultContent ?? OM2MResultContent.Attributes);

				response.Content = resource;
				response.ResponseStatusCode = OM2MResponseStatusCode.Ok;

				return response;
			}
		}

		public override OM2MResponsePrimitive DoUpdate(OM2MRequestPrimitive request)
		{
			using (var db = CreateDbContext())
			{
				var query = db.Resources.OfType<OM2MAccessControlPolicyEntity>()
				              .Where(x => x.ResourceId == request.TargetId)
				              .Include(x => x.Privileges)
				              .Include(x => x.SelfPrivileges);

				if (query.Count() == 0)
				{
					throw new OM2MNotFoundException("Resource not found.");
				}

				var entity = query.First();

				CheckSelfACP(entity, request.From, OM2MOperation.Update);

				if (request.Content == null)
				{
					throw new OM2MBadRequestException("A content is required for creation.");
				}

				var resource = request.Content as OM2MAccessControlPolicy;

				if (resource == null)
				{
					throw new OM2MBadRequestException("Incorrect resource representation in content.");
				}

				var modifiedAttributes = new OM2MAccessControlPolicy();

				if (resource.ExpirationTime != null)
				{
					entity.ExpirationTime = resource.ExpirationTime;
					modifiedAttributes.ExpirationTime = resource.ExpirationTime;
				}

				if (resource.Labels != null)
				{
					entity.Labels.Clear();
					entity.Labels.AddRange(resource.Labels);
					modifiedAttributes.Labels = resource.Labels;
				}

				if (resource.AnnounceTo != null)
				{
					entity.AnnounceTo.Clear();
					entity.AnnounceTo.AddRange(resource.AnnounceTo);
					modifiedAttributes.AnnounceTo = resource.AnnounceTo;
				}

				if (resource.AnnouncedAttribute != null)
				{
					entity.AnnouncedAttribute.Clear();
					entity.AnnouncedAttribute.AddRange(resource.AnnouncedAttribute);
					modifiedAttributes.AnnouncedAttribute = resource.AnnouncedAttribute;
				}

				if (resource.Privileges != null)
				{
					entity.Privileges.Clear();
					foreach (var rule in resource.Privileges.AccessControlRule)
					{
						entity.Privileges.Add(rule.ToEntity());
					}
					modifiedAttributes.Privileges = resource.Privileges;
				}

				if (resource.SelfPrivileges != null)
				{
					entity.SelfPrivileges.Clear();
					foreach (var rule in resource.SelfPrivileges.AccessControlRule)
					{
						entity.SelfPrivileges.Add(rule.ToEntity());
					}
					modifiedAttributes.SelfPrivileges = resource.SelfPrivileges;
				}

				entity.LastModifiedTime = OM2MTimeStamp.NowTimeStamp;
				modifiedAttributes.LastModifiedTime = entity.LastModifiedTime;

				db.SaveChanges();

				var subs = db.Resources.OfType<OM2MSubscriptionEntity>().Where(x => x.ParentId == entity.ResourceId).ToList();
				CseService.Notify(subs, entity, OM2MResourceStatus.Updated);
				
				var response = new OM2MResponsePrimitive(CseConfig, request);

				response.Content = modifiedAttributes;
				response.ResponseStatusCode = OM2MResponseStatusCode.Updated;

				return response;
			}
		}

		public override OM2MResponsePrimitive DoDelete(OM2MRequestPrimitive request)
		{
			using (var db = CreateDbContext())
			{
				var query = db.Resources.OfType<OM2MAccessControlPolicyEntity>()
							  .Where(x => x.ResourceId == request.TargetId)
							  .Include(x => x.SelfPrivileges);

				if (query.Count() == 0)
				{
					throw new OM2MNotFoundException("Resource not found.");
				}

				var entity = query.First();

				CheckSelfACP(entity, request.From, OM2MOperation.Delete);

				var subs = db.Resources.OfType<OM2MSubscriptionEntity>()
				             .Where(x => x.ParentId == entity.ResourceId).ToList();
				
				CseService.NotifyDeletion(subs, entity);

				db.Resources.Remove(entity);
				db.SaveChanges();

				var response = new OM2MResponsePrimitive(CseConfig, request);

				response.ResponseStatusCode = OM2MResponseStatusCode.Deleted;

				return response;
			}
		}
	}
}
