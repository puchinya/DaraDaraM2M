using System;
using System.Linq;
using DaraDaraM2M.Data;

namespace DaraDaraM2M.Model
{
	public static class OM2MResourceMapExtension
	{
		public static void CopyAttributesResource(OM2MResourceEntity entity, OM2MResource resource)
		{
			resource.ResourceType = (OM2MResourceType)entity.ResourceType;
			resource.ResourceName = entity.ResourceName;
			resource.ResourceID = entity.ResourceId;
			resource.ParentID = entity.ParentId;
			resource.CreationTime = entity.CreationTime;
			resource.LastModifiedTime = entity.LastModifiedTime;
			resource.Labels = entity.Labels;
		}

		// ToDo:
		public static void MapEntityToResourceCommonProcudure(OM2MResourceEntity entity,
															  OM2MResource resource,
															  OM2MResultContent resultContent)
		{
			if (resultContent.HasAttributes())
			{
				CopyAttributesResource(entity, resource);
			}

			if (resultContent.HasChildResourceReferences())
			{
				var container = resource as IOM2MChildResourceContainer;
				if (container != null)
				{
					MapChildResourceRef(entity, container);
				}
			}
		}

		// ToDo:
		public static OM2MCSEBase ToResource(this OM2MCseBaseEntity entity,
											OM2MResultContent resultContent)
		{
			var resource = new OM2MCSEBase();

			MapEntityToResourceCommonProcudure(entity, resource, resultContent);

			if (resultContent.HasAttributes())
			{
				resource.CseType = (OM2MCseTypeID)entity.CseType;
				resource.CSEID = entity.CseId;
				resource.NodeLink = entity.NodeLink;
				resource.SupportedResourceType = entity.SupportedResourceType;
			}

			return resource;
		}

		public static void CopyAttributesRegularResource(OM2MRegularResourceEntity entity,
										  OM2MRegularResource resource)
		{
			CopyAttributesResource(entity, resource);
			resource.AccessControlPolicyIDs = entity.AccessControlPolicyIds;
			resource.ExpirationTime = entity.ExpirationTime;
		}

		public static void CopyAttributesAE(OM2MAEEntity entity,
										  OM2MAE resource)
		{
			
			resource.AppName = entity.AppName;
			resource.AppID = entity.AppId;
			resource.AEID = entity.AEId;
			resource.PointOfAccess = entity.PointOfAccess;
			resource.OntologyRef = entity.OntologyRef;
			resource.NodeLink = entity.NodeLink;
			resource.RequestReachability = entity.RequestReachability;
		}

		// ToDo:
		public static OM2MAE ToResource(this OM2MAEEntity entity,
		                                OM2MResultContent resultContent)
		{
			var resource = new OM2MAE();

			MapEntityToResourceCommonProcudure(entity, resource, resultContent);

			if (resultContent.HasAttributes())
			{
				resource.AppName = entity.AppName;
				resource.AppID = entity.AppId;
				resource.AEID = entity.AEId;
				resource.PointOfAccess = entity.PointOfAccess;
				resource.OntologyRef = entity.OntologyRef;
				resource.NodeLink = entity.NodeLink;
				resource.RequestReachability = entity.RequestReachability;
			}

			return resource;
		}

		// ToDo:
		public static OM2MAccessControlPolicy ToResource(this OM2MAccessControlPolicyEntity entity,
		                                                 OM2MResultContent resultContent)
		{
			var resource = new OM2MAccessControlPolicy();
			CopyAttributesResource(entity, resource);

			if (resultContent.HasAttributes())
			{
				
			}

			return resource;
		}

		// ToDo:
		public static OM2MContainer ToResource(this OM2MContainerEntity entity,
														 OM2MResultContent resultContent)
		{
			var resource = new OM2MContainer();

			CopyAttributesResource(entity, resource);

			return resource;
		}

		public static OM2MContentInstance ToResource(this OM2MContentInstanceEntity entity,
														 OM2MResultContent resultContent)
		{
			var resource = new OM2MContentInstance();

			CopyAttributesResource(entity, resource);

			return resource;
		}

		public static OM2MAccessControlRuleEntity ToEntity(this OM2MAccessControlRule resource)
		{
			var entity = new OM2MAccessControlRuleEntity();

			entity.AccessControlAuthenticationFlag = resource.AccessControlAuthenticationFlag;
			entity.AccessControlOperations = (int)resource.AccessControlOperations;
			entity.AccessControlOriginators.AddRange(resource.AccessControlOriginators);

			return entity;
		}

		static void MapChildResourceRef(OM2MResourceEntity entity, IOM2MChildResourceContainer resource)
		{
			foreach (var childEntity in entity.Resources)
			{
				var childRef = new OM2MChildResourceRef();

				childRef.Name = childEntity.ResourceName;
				childRef.Type = (OM2MResourceType)childEntity.ResourceType;
				childRef.Value = childEntity.ResourceId;

				resource.ChildResource.Add(childRef);
			}
		}

		static void MapChildResources(OM2MAEEntity entity, OM2MAE resource)
		{
			
		}
	}
}
