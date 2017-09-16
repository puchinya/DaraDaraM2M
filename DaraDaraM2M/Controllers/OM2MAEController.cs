using System;
using System.Collections.Generic;
using System.Linq;
using DaraDaraM2M.Data;
using DaraDaraM2M.Model;
using Microsoft.EntityFrameworkCore;

namespace DaraDaraM2M.Controllers
{
	public class OM2MAEController : OM2MController
	{
		public OM2MAEController(OM2MCseServiceImpl cseService)
			: base(cseService)
		{
		}

		public override OM2MResponsePrimitive DoCreate(OM2MRequestPrimitive request)
		{
			using (var db = CreateDbContext())
			{
				var parentEntity = db.Resources.Find(request.TargetId);
				if (parentEntity == null)
				{
					throw new OM2MNotFoundException($"Cannot find parent resource: {request.TargetId}.");
				}

				List<string> acpIds = null;

				if (parentEntity is OM2MCseBaseEntity)
				{
					var ee = parentEntity as OM2MCseBaseEntity;
					acpIds = ee.AccessControlPolicyIds;
				}
				else if (parentEntity is OM2MRemoteCseEntity)
				{
					var ee = parentEntity as OM2MContainerEntity;
					acpIds = ee.AccessControlPolicyIds;
				}

				if (request.From != null)
				{
				}

				var acpList = new List<OM2MAccessControlPolicyEntity>();

				if (acpIds != null)
				{
					foreach (var i in acpIds)
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
				}

				CheckACP(acpList, request.From, OM2MOperation.Create);

				if (request.Content == null)
				{
					throw new OM2MBadRequestException("A content is required for creation.");
				}

				var resource = request.Content as OM2MAE;

				if (resource == null)
				{
					throw new OM2MBadRequestException("Incorrect resource representation in content.");
				}

				/*
				 * appName				O
				 * App-ID				M
				 * AE-ID				NP
				 * pointOfAccess		O
				 * ontologyRef			O
				 * nodeLink				O
				 * requestReachability	M
				 * contentSerialization	O
				 * e2eSecInfo			O
				 */
				var entity = new OM2MAEEntity();

				// Check NP attributes
				if (resource.AEID != null)
				{
					throw new OM2MBadRequestException("AE-ID is not permitted.");
				}

				// Assign M attributes
				if (resource.AppID == null)
				{
					throw new OM2MBadRequestException("App-ID is mandatory.");
				}
				/*
				if (aeResource.RequestReachability == null)
				{
					throw new OM2MBadRequestException("requestReachability is mandatory.");
				}*/

				entity.AppId = resource.AppID;

				// Assign M/O attributes
				if (resource.AppName != null)
				{
					entity.AppName = resource.AppName;
				}

				if (resource.PointOfAccess != null)
				{
					entity.PointOfAccess.AddRange(resource.PointOfAccess);
				}

				if (resource.OntologyRef != null)
				{
					entity.OntologyRef = resource.OntologyRef;
				}

				if (resource.RequestReachability == null)
				{
					entity.RequestReachability = true;
				}
				else
				{
					entity.RequestReachability = resource.RequestReachability.Value;
				}

				if (resource.NodeLink != null)
				{
					entity.NodeLink = resource.NodeLink;
				}

				var id = db.GenerateId();

				entity.ResourceId = $"/{CseConfig.CseBaseId}/CAE{id}";
				entity.CreationTime = OM2MTimeStamp.NowTimeStamp;
				entity.LastModifiedTime = entity.CreationTime;
				entity.ParentId = parentEntity.ResourceId;
				entity.ResourceType = (int)OM2MResourceType.AE;
				entity.AEId = $"CAE{id}";

				if (resource.ResourceName != null)
				{
					// ToDo: need to check resource name
					entity.ResourceName = resource.ResourceName;
				}
				else
				{
					entity.ResourceName = $"ae_{id}";
				}

				entity.HierarchicalUri = parentEntity.HierarchicalUri + "/" + entity.ResourceName;

				{
					var acpId = db.GenerateId();

					var acpEntity = new OM2MAccessControlPolicyEntity();
					acpEntity.CreationTime = OM2MTimeStamp.NowTimeStamp;
					acpEntity.LastModifiedTime = acpEntity.CreationTime;
					acpEntity.ParentId = $"/{CseConfig.CseBaseId}";
					acpEntity.ResourceId = $"/{CseConfig.CseBaseId}/acp-{acpId}";
					acpEntity.ResourceName = $"acpae_{acpId}";

					var ruleEntity = new OM2MAccessControlRuleEntity();
					ruleEntity.AccessControlOperations = 63;
					ruleEntity.AccessControlOriginators.Add(CseConfig.AdminOriginator);
					acpEntity.SelfPrivileges.Add(ruleEntity);

					ruleEntity = new OM2MAccessControlRuleEntity();
					ruleEntity.AccessControlOperations = 63;
					ruleEntity.AccessControlOriginators.Add(entity.AEId);
					ruleEntity.AccessControlOriginators.Add(CseConfig.AdminOriginator);
					acpEntity.Privileges.Add(ruleEntity);
					acpEntity.HierarchicalUri = $"/{CseConfig.CseBaseId}/{CseConfig.CseBaseName}/{acpEntity.ResourceName}";

					entity.AccessControlPolicyIds.Add(acpEntity.ResourceId);
					//parentEntity.Resources.Add(acpEntity);
					db.Resources.Add(acpEntity);

					var uriMapEntity2 = new OM2MUriMapEntity();
					uriMapEntity2.Uri = acpEntity.HierarchicalUri;
					uriMapEntity2.ResourceId = acpEntity.ResourceId;
					db.UriMaps.Add(uriMapEntity2);
				}

				//parentEntity.Resources.Add(entity);
				db.Resources.Add(entity);

				var uriMapEntity = new OM2MUriMapEntity();
				uriMapEntity.Uri = entity.HierarchicalUri;
				uriMapEntity.ResourceId = entity.ResourceId;
				db.UriMaps.Add(uriMapEntity);

				db.SaveChanges();

				var subs = db.Resources
				             .OfType<OM2MSubscriptionEntity>()
				             .Where(x => x.ParentId == parentEntity.ResourceId).ToList();
				
				CseService.Notify(subs, entity, OM2MResourceStatus.ChildCreated);

				var response = new OM2MResponsePrimitive(CseConfig, request);
				response.ResponseStatusCode = OM2MResponseStatusCode.Created;
				response.Content = entity.ToResource(OM2MResultContent.Attributes);

				return response;
			}
		}

		public override OM2MResponsePrimitive DoRetrieve(OM2MRequestPrimitive request)
		{
			using (var db = CreateDbContext())
			{
				var entity = db.Resources.Find(request.TargetId) as OM2MAEEntity;

				if (entity == null)
				{
					throw new OM2MNotFoundException("Resource not found.");
				}

				var acpList = new List<OM2MAccessControlPolicyEntity>();
				foreach (var i in entity.AccessControlPolicyIds)
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

				CheckACP(acpList, request.From, OM2MOperation.Retrieve);

				var resource = entity.ToResource(request.ResultContent ?? OM2MResultContent.Attributes);

				var response = new OM2MResponsePrimitive(CseConfig, request);
				response.Content = resource;

				return response;
			}
		}

		public override OM2MResponsePrimitive DoUpdate(OM2MRequestPrimitive request)
		{
			using (var db = CreateDbContext())
			{
				var entity = db.Resources.Find(request.TargetId) as OM2MAEEntity;

				if (entity == null)
				{
					throw new OM2MNotFoundException("Resource not found.");
				}

				var acpList = new List<OM2MAccessControlPolicyEntity>();
				foreach (var i in entity.AccessControlPolicyIds)
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

				CheckACP(acpList, request.From, OM2MOperation.Update);

				if (request.Content == null)
				{
					throw new OM2MBadRequestException("A content is required for creation.");
				}

				var resource = request.Content as OM2MAE;

				if (resource == null)
				{
					throw new OM2MBadRequestException("Incorrect resource in primitive content.");
				}

				if (resource.AppID != null)
				{
					throw new OM2MBadRequestException("AppID is not permitted.");
				}

				if (resource.AEID != null)
				{
					throw new OM2MBadRequestException("AE-ID is not permitted.");
				}

				if (resource.NodeLink != null)
				{
					throw new OM2MBadRequestException("NodeLink is not permitted.");
				}

				var modifiedAttrs = new OM2MAE();

				if (resource.AccessControlPolicyIDs != null &&
				   resource.AccessControlPolicyIDs.Count > 0)
				{
					foreach(var acp in acpList)
					{
						CheckSelfACP(acp, request.From, OM2MOperation.Update);
					}

					entity.AccessControlPolicyIds.Clear();
					entity.AccessControlPolicyIds.AddRange(resource.AccessControlPolicyIDs);
					modifiedAttrs.AccessControlPolicyIDs = resource.AccessControlPolicyIDs;
				}

				if (resource.Labels != null)
				{
					entity.Labels.Clear();
					entity.Labels.AddRange(resource.Labels);
					modifiedAttrs.Labels = resource.Labels;
				}

				if (resource.ExpirationTime != null)
				{
					entity.ExpirationTime = resource.ExpirationTime;
					modifiedAttrs.ExpirationTime = resource.ExpirationTime;
				}

				if (resource.AnnounceTo != null)
				{
					entity.AnnounceTo.Clear();
					entity.AnnounceTo.AddRange(resource.AnnounceTo);
					modifiedAttrs.AnnounceTo = resource.AnnounceTo;
				}

				if (resource.AnnouncedAttribute != null)
				{
					entity.AnnouncedAttribute.Clear();
					entity.AnnouncedAttribute.AddRange(resource.AnnouncedAttribute);
					modifiedAttrs.AnnouncedAttribute = resource.AnnouncedAttribute;
				}

				if (resource.AppName != null)
				{
					entity.AppName = resource.AppName;
					modifiedAttrs.AppName = resource.AppName;
				}

				if (resource.PointOfAccess != null)
				{
					entity.PointOfAccess.Clear();
					entity.PointOfAccess.AddRange(resource.PointOfAccess);
					modifiedAttrs.PointOfAccess = resource.PointOfAccess;
				}

				if (resource.OntologyRef != null)
				{
					entity.OntologyRef = resource.OntologyRef;
					modifiedAttrs.OntologyRef = resource.OntologyRef;
				}

				if (resource.RequestReachability != null)
				{
					entity.RequestReachability = resource.RequestReachability.Value;
					modifiedAttrs.RequestReachability = resource.RequestReachability;
				}

				entity.LastModifiedTime = OM2MTimeStamp.NowTimeStamp;
				modifiedAttrs.LastModifiedTime = entity.LastModifiedTime;

				db.SaveChanges();

				db.Entry(entity).Collection(x => x.Resources).Load();
				var subs = entity.Resources.OfType<OM2MSubscriptionEntity>().ToList();
				CseService.Notify(subs, entity, OM2MResourceStatus.Updated);

				var response = new OM2MResponsePrimitive(CseConfig, request);
				response.Content = modifiedAttrs;
				response.ResponseStatusCode = OM2MResponseStatusCode.Updated;

				return response;
			}
		}

		public override OM2MResponsePrimitive DoDelete(OM2MRequestPrimitive request)
		{
			using (var db = CreateDbContext())
			{
				var entity = db.Resources.Find(request.TargetId) as OM2MAEEntity;

				if (entity == null)
				{
					throw new OM2MNotFoundException("Resource not found.");
				}

				var acpList = new List<OM2MAccessControlPolicyEntity>();
				foreach (var i in entity.AccessControlPolicyIds)
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

				CheckACP(acpList, request.From, OM2MOperation.Delete);

				db.Entry(entity).Collection(x => x.Resources).Load();
				var subs = entity.Resources.OfType<OM2MSubscriptionEntity>().ToList();
				CseService.NotifyDeletion(subs, entity);

				db.Resources.Remove(entity);

				var uriMapEntity = db.UriMaps.Find(entity.HierarchicalUri);
				db.UriMaps.Remove(uriMapEntity);

				db.SaveChanges();

				var response = new OM2MResponsePrimitive(CseConfig, request);

				response.ResponseStatusCode = OM2MResponseStatusCode.Deleted;

				return response;
			}
		}
	}
}
