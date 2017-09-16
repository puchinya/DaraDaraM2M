using System;
using System.Collections.Generic;
using System.Linq;
using DaraDaraM2M.Data;
using DaraDaraM2M.Model;
using Microsoft.EntityFrameworkCore;

namespace DaraDaraM2M.Controllers
{
	public class OM2MContentInstanceController : OM2MController
	{
		public OM2MContentInstanceController(OM2MCseServiceImpl cseService)
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

				if (parentEntity is OM2MContainerEntity)
				{
					var ee = parentEntity as OM2MContainerEntity;
					acpIds = ee.AccessControlPolicyIds;
				}
				// ToDo:OM2MContainerAnncEntity

				var acpList = new List<OM2MAccessControlPolicyEntity>();

				if (acpIds != null)
				{
					foreach (var i in acpIds)
					{
						var queryAcp = db.Resources.Find(i) as OM2MAccessControlPolicyEntity;
						if (queryAcp == null)
						{
							// Damaged
							continue;
						}
						acpList.Add(queryAcp);
					}
				}

				CheckACP(acpList, request.From, OM2MOperation.Create);

				if (request.Content == null)
				{
					throw new OM2MBadRequestException("A content is required for creation.");
				}

				var resource = request.Content as OM2MContentInstance;

				if (resource == null)
				{
					throw new OM2MBadRequestException("Incorrect resource representation in content.");
				}

				/*
				 * creator				O
				 * maxNrOfInstances		O
				 * maxByteSize			O
				 * maxInstanceAge		O
				 * currentNrOfInstances	NP
				 * currentByteSize		NP
				 * locationID			O
				 * ontologyRef			O
				 */
				var entity = new OM2MContentInstanceEntity();

				// Assign M/O attributes
				if (resource.Labels != null)
				{
					entity.Labels.AddRange(resource.Labels);
				}

				if (resource.ExpirationTime != null)
				{
					entity.ExpirationTime = resource.ExpirationTime;
				}

				if (resource.AnnounceTo != null)
				{
					entity.AnnounceTo.AddRange(resource.AnnounceTo);
				}

				if (resource.AnnouncedAttribute != null)
				{
					entity.AnnouncedAttribute.AddRange(resource.AnnouncedAttribute);
				}

				if (resource.Creator != null)
				{
					entity.Creator = resource.Creator;
				}

				if (resource.OntologyRef != null)
				{
					entity.OntologyRef = resource.OntologyRef;
				}

				var id = db.GenerateId();

				entity.ResourceId = $"/{CseConfig.CseBaseId}/cin-{id}";
				entity.CreationTime = OM2MTimeStamp.NowTimeStamp;
				entity.LastModifiedTime = entity.CreationTime;
				entity.ParentId = parentEntity.ResourceId;
				entity.ResourceType = (int)OM2MResourceType.Container;

				if (resource.ResourceName != null)
				{
					// ToDo: need to check resource name
					entity.ResourceName = resource.ResourceName;
				}
				else
				{
					entity.ResourceName = $"cin_{id}";
				}

				entity.HierarchicalUri = parentEntity.HierarchicalUri + "/" + entity.ResourceName;

				entity.StateTag = 0;

				parentEntity.Resources.Add(entity);

				if (parentEntity is OM2MContainerEntity)
				{
					var container = parentEntity as OM2MContainerEntity;

					container.StateTag++;
				}

				var uriMapEntity = new OM2MUriMapEntity();
				uriMapEntity.Uri = entity.HierarchicalUri;
				uriMapEntity.ResourceId = entity.ResourceId;
				db.UriMaps.Add(uriMapEntity);

				db.SaveChanges();

				var subs = parentEntity.Resources.OfType<OM2MSubscriptionEntity>().ToList();

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
				var entity = db.Resources.Find(request.TargetId) as OM2MContentInstanceEntity;

				if (entity == null)
				{
					throw new OM2MNotFoundException("Resource not found.");
				}

				var parentEntity = db.Resources.Find(entity.ParentId);
				var hasACP = parentEntity as IOM2MHasAccessControlPolicyIdsEntity;

				var acpList = new List<OM2MAccessControlPolicyEntity>();
				foreach (var i in hasACP.AccessControlPolicyIds)
				{
					var queryAcp = db.Resources.Find(i) as OM2MAccessControlPolicyEntity;
					if (queryAcp == null)
					{
						// Damaged
						continue;
					}
					acpList.Add(queryAcp);
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
				var entity = db.Resources.Find(request.TargetId) as OM2MContainerEntity;

				if (entity == null)
				{
					throw new OM2MNotFoundException("Resource not found.");
				}

				var acpList = new List<OM2MAccessControlPolicyEntity>();
				foreach (var i in entity.AccessControlPolicyIds)
				{
					var queryAcp = db.Resources.Find(i) as OM2MAccessControlPolicyEntity;
					if (queryAcp == null)
					{
						// Damaged
						continue;
					}
					acpList.Add(queryAcp);
				}

				CheckACP(acpList, request.From, OM2MOperation.Update);

				if (request.Content == null)
				{
					throw new OM2MBadRequestException("A content is required for creation.");
				}

				var resource = request.Content as OM2MContainer;

				if (resource == null)
				{
					throw new OM2MBadRequestException("Incorrect resource in primitive content.");
				}

				if (resource.CurrentNrOfInstances != null)
				{
					throw new OM2MBadRequestException("currentNrOfInstances is not permitted.");
				}

				if (resource.CurrentByteSize != null)
				{
					throw new OM2MBadRequestException("currentByteSize is not permitted.");
				}

				var modifiedAttrs = new OM2MContainer();

				if (resource.AccessControlPolicyIDs != null &&
				   resource.AccessControlPolicyIDs.Count > 0)
				{
					foreach (var acp in acpList)
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

				if (resource.MaxNrOfInstances != null)
				{
					entity.MaxNrOfInstances = resource.MaxNrOfInstances;
					modifiedAttrs.MaxNrOfInstances = resource.MaxNrOfInstances;
				}

				if (resource.MaxByteSize != null)
				{
					entity.MaxByteSize = resource.MaxByteSize;
					modifiedAttrs.MaxByteSize = resource.MaxByteSize;
				}

				if (resource.MaxInstanceAge != null)
				{
					entity.MaxInstanceAge = resource.MaxInstanceAge;
					modifiedAttrs.MaxInstanceAge = resource.MaxInstanceAge;
				}

				if (resource.LocationID != null)
				{
					entity.LocationID = resource.LocationID;
					modifiedAttrs.LocationID = resource.LocationID;
				}

				if (resource.OntologyRef != null)
				{
					entity.OntologyRef = resource.OntologyRef;
					modifiedAttrs.OntologyRef = resource.OntologyRef;
				}

				entity.StateTag = entity.StateTag + 1;
				modifiedAttrs.StateTag = entity.StateTag;

				entity.LastModifiedTime = OM2MTimeStamp.NowTimeStamp;
				modifiedAttrs.LastModifiedTime = entity.LastModifiedTime;

				db.SaveChanges();

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
				var entity = db.Resources.Find(request.TargetId) as OM2MContainerEntity;

				if (entity == null)
				{
					throw new OM2MNotFoundException("Resource not found.");
				}

				var acpList = new List<OM2MAccessControlPolicyEntity>();
				foreach (var acpId in entity.AccessControlPolicyIds)
				{
					var queryAcp = db.Resources.Find(acpId) as OM2MAccessControlPolicyEntity;
					if (queryAcp == null)
					{
						// Damaged
						continue;
					}
					acpList.Add(queryAcp);
				}

				CheckACP(acpList, request.From, OM2MOperation.Delete);

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
