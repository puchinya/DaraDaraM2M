using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using DaraDaraM2M.Data;
using DaraDaraM2M.Model;
using DaraDaraM2M.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DaraDaraM2M
{
	public class OM2MCseServiceImpl : IOM2MCseService
	{
		private static readonly string IdPattern = "(?:[a-zA-Z0-9-¥¥._¥¥~]+)";
		
		public OM2MCseServiceImpl(OM2MCseConfig cseConfig)
		{
			CseConfig = cseConfig;

			m_cseBasePattern = new Regex($"^/{Regex.Escape(CseConfig.CseBaseId)}$");
			m_acpPattern = new Regex($"^/{Regex.Escape(CseConfig.CseBaseId)}/acp-{IdPattern}$");
			m_aePattern = new Regex($"^(?:/{Regex.Escape(CseConfig.CseBaseId)}/C{IdPattern})|(?:/S{IdPattern})$");
			m_cntPattern = new Regex($"^/{Regex.Escape(CseConfig.CseBaseId)}/cnt-{IdPattern}$");
		}


		private void InitACP()
		{
			using (var db = new OM2MDbContext())
			{
				var cseConfig = CseConfig;

				var acpId = db.GenerateId();

				var acpEntity = new OM2MAccessControlPolicyEntity();
				acpEntity.ParentId = $"/{cseConfig.CseBaseId}";
				acpEntity.CreationTime = OM2MTimeStamp.NowTimeStamp;
				acpEntity.LastModifiedTime = acpEntity.CreationTime;
				acpEntity.ResourceId = $"/{cseConfig.CseBaseId}/acp-{acpId}";
				acpEntity.ResourceName = CseConfig.AdminAcpName;
				acpEntity.ResourceType = (int)OM2MResourceType.AccessControlPolicy;
				acpEntity.HierarchicalUri = $"/{cseConfig.CseBaseId}/{cseConfig.CseBaseName}/{acpEntity.ResourceName}";

				var ruleEntity = new OM2MAccessControlRuleEntity();
				ruleEntity.AccessControlOriginators.Add(CseConfig.AdminOriginator);
				ruleEntity.AccessControlOperations = 63;
				acpEntity.SelfPrivileges.Add(ruleEntity);

				ruleEntity = new OM2MAccessControlRuleEntity();
				ruleEntity.AccessControlOriginators.Add(CseConfig.AdminOriginator);
				ruleEntity.AccessControlOriginators.Add($"/{cseConfig.CseBaseId}");
				ruleEntity.AccessControlOperations = 63;

				acpEntity.Privileges.Add(ruleEntity);

				db.Resources.Add(acpEntity);

				var uriMapEntity = new OM2MUriMapEntity();
				uriMapEntity.Uri = acpEntity.HierarchicalUri;
				uriMapEntity.ResourceId = acpEntity.ResourceId;
				db.UriMaps.Add(uriMapEntity);

				db.SaveChanges();
			}
		}

		private void InitCseBase()
		{
			var cseConfig = CseConfig;

			using (var db = new OM2MDbContext())
			{
				var cseBaseEntity = new OM2MCseBaseEntity();

				var query = db.Resources.OfType<OM2MAccessControlPolicyEntity>();

				var acpEntity = query.First();

				cseBaseEntity.AccessControlPolicyIds.Add(acpEntity.ResourceId);
				cseBaseEntity.Resources.Add(acpEntity);
				cseBaseEntity.CreationTime = OM2MTimeStamp.NowTimeStamp;
				cseBaseEntity.LastModifiedTime = cseBaseEntity.CreationTime;
				cseBaseEntity.CseId = cseConfig.CseBaseId;
				cseBaseEntity.CseType = (int)cseConfig.CseType;
				cseBaseEntity.ResourceName = cseConfig.CseBaseName;
				cseBaseEntity.ResourceId = $"/{cseConfig.CseBaseId}";
				cseBaseEntity.ResourceType = (int)OM2MResourceType.CSEBase;
				cseBaseEntity.HierarchicalUri = $"/{cseConfig.CseBaseId}/{cseConfig.CseBaseName}";
				cseBaseEntity.SupportedResourceType.AddRange(new OM2MResourceType[] {
					OM2MResourceType.AccessControlPolicy,
					OM2MResourceType.AE,
					OM2MResourceType.Container,
					OM2MResourceType.ContentInstance,
					OM2MResourceType.CSEBase,
					OM2MResourceType.Group,
					OM2MResourceType.Node,
					OM2MResourceType.PollingChannel,
					OM2MResourceType.RemoteCSE,
					OM2MResourceType.Request,
					OM2MResourceType.Subscription
				});

				cseBaseEntity.PointOfAccess.Add("http://localhost:5000/");

				db.Resources.Add(cseBaseEntity);

				var uriMapEntity = new OM2MUriMapEntity();
				uriMapEntity.Uri = cseBaseEntity.HierarchicalUri;
				uriMapEntity.ResourceId = cseBaseEntity.ResourceId;
				db.UriMaps.Add(uriMapEntity);

				db.SaveChanges();
			}
		}

		private async Task ConnectCse()
		{
			var remoteWSPoa = $"ws://{CseConfig.RemoteCseHost}:{CseConfig.RemoteCsePort}";

			var client = new Protocols.OM2MWSClient(remoteWSPoa);

			await client.ConnectAsync();

			var remoteCse = new OM2MRemoteCSE();

			remoteCse.CseType = CseConfig.CseType;
			remoteCse.CSEID = $"/{CseConfig.CseBaseId}";
			remoteCse.CSEBase = $"//{CseConfig.ServieProviderId}{remoteCse.CSEID}";
			remoteCse.RequestReachability = true;
			remoteCse.ResourceName = CseConfig.CseBaseId;

			var request = new OM2MRequestPrimitive();
			request.From = CseConfig.AdminOriginator;

			request.To = remoteWSPoa;
			request.Content = remoteCse;
			request.Operation = OM2MOperation.Create;
			request.ResourceType = OM2MResourceType.RemoteCSE;
			request.RequestIdentifier = "001";

			var response = await client.SendBlockingRequestAsync(request);

			if (!response.ResponseStatusCode.Value.IsSuccess())
			{
				// Fatal error
				throw new Exception("fatal error failed to create remoteCSE on remote server.");
			}

			await client.CloseAsync();
		}

		public void Initialize()
		{
			InitACP();

			InitCseBase();

			if (CseConfig.CseType != OM2MCseTypeID.InCSE)
			{
				// Connect CSE to another CSE using WebSocket
				Task.WaitAny(ConnectCse());
			}

			IsInitalized = true;
		}

		private OM2MController GetControllerFromResouceType(OM2MResourceType resourceType)
		{
			switch (resourceType)
			{
				case OM2MResourceType.CSEBase:
					return new OM2MCseBaseController(this);
				case OM2MResourceType.AccessControlPolicy:
					return new OM2MAccessControlPolicyController(this);
				case OM2MResourceType.AE:
					return new OM2MAEController(this);
				default:
					throw new OM2MBadRequestException($"Resouce type: {resourceType} is not implemented.");
			}
		}

		private Regex m_cseBasePattern;
		private Regex m_acpPattern;
		private Regex m_aePattern;
		private Regex m_cntPattern;

		private OM2MController GetControllerFromUri(string uri)
		{
			if (m_cseBasePattern.IsMatch(uri))
			{
				return new OM2MCseBaseController(this);
			}
			if (m_acpPattern.IsMatch(uri))
			{
				return new OM2MAccessControlPolicyController(this);
			}
			if (m_aePattern.IsMatch(uri))
			{
				return new OM2MAEController(this);
			}

			return null;
		}

		// 7.3.2.1 Check the validity of received request primitive
		// ToDo:
		private void ValidateRequest(OM2MRequestPrimitive request)
		{
			// Relative timestamp to absoule
			if (request.RequestExpirationTimestamp != null)
			{
				try
				{
					request.RequestExpirationTimestamp = OM2MTimeStamp.GetTimeStamp(request.RequestExpirationTimestamp);
				}
				catch (Exception ex)
				{
					Console.Error.WriteLine(ex);
					throw new OM2MBadRequestException($"Request expiration timestamp is illegal format: {request.RequestExpirationTimestamp}");
				}
			}
			if (request.ResultExpirationTimestamp != null)
			{
				try
				{
					request.ResultExpirationTimestamp = OM2MTimeStamp.GetTimeStamp(request.ResultExpirationTimestamp);
				}
				catch (Exception ex)
				{
					Console.Error.WriteLine(ex);
					throw new OM2MBadRequestException($"Result expiration timestamp is illegal format: {request.ResultExpirationTimestamp}");
				}
			}

			if (request.RequestExpirationTimestamp != null)
			{
				bool isTimeOut;

				try
				{
					isTimeOut = OM2MTimeStamp.IsTimeout((string)request.RequestExpirationTimestamp);
				}
				catch (FormatException ex)
				{
					Console.Error.WriteLine(ex);
					throw new OM2MBadRequestException($"Request expiration timestamp is illegal format: {request.RequestExpirationTimestamp}");
				}

				if (isTimeOut)
				{
					throw new OM2MRequestTimeoutException();
				}
			}
		}

		private OM2MResponsePrimitive HandleOM2MException(OM2MException ex, OM2MRequestPrimitive request)
		{
			var response = new OM2MResponsePrimitive(CseConfig, request);
			response.ResponseStatusCode = ex.ResponseStatusCode;

			return response;
		}

		private OM2MResponsePrimitive HandleOtherException(Exception ex, OM2MRequestPrimitive request)
		{
			var response = new OM2MResponsePrimitive(CseConfig, request);
			response.ResponseStatusCode = OM2MResponseStatusCode.InternalServerError;

			return response;
		}

		public void DoRequest(OM2MRequestPrimitive request, IOM2MOriginator originator)
		{
			if (!IsInitalized)
			{
				throw new InvalidOperationException("CseService is not initialized.");
			}
			
			try
			{
				ValidateRequest(request);
			}
			catch (OM2MException ex)
			{
				var response = HandleOM2MException(ex, request);
				originator.SendResponse(response);
				return;
			}
			catch (Exception ex)
			{
				var response = HandleOtherException(ex, request);
				originator.SendResponse(response);
				return;
			}

			var responseType = OM2MResponseType.BlockingRequest;

			if (request.ResponseType != null && request.ResponseType.ResponseTypeValue != null)
			{
				responseType = request.ResponseType.ResponseTypeValue.Value;
			}

			if (responseType == OM2MResponseType.NonBlockingRequestAsynch ||
			    responseType == OM2MResponseType.NonBlockingRequestSynch)
			{
				// ToDo:
				// Recv-3.0: Create <request> resource locally
				OM2MRequest req = new OM2MRequest();

				req.ResourceType = OM2MResourceType.Request;
				req.ExpirationTime = OM2MTimeStamp.GetTimeStamp(request.RequestExpirationTimestamp);
				req.CreationTime = OM2MTimeStamp.NowTimeStamp;
				req.LastModifiedTime = req.CreationTime;
				// ToDo:request.AccessControlPolicyIDs
				// ToDo:req.Labels
				req.StateTag = 0;

				req.Operation = request.Operation;
				req.Target = request.To;
				req.Originator = request.From;
				req.RequestID = request.RequestIdentifier;
				// ToDo:request.MetaInformation = 
				req.PrimitiveContent = request.PrimitiveContent;
				req.RequestStatus = OM2MRequestStatus.Pending;
				req.OperationResult = null;

				// Recv-4.0: Create a success Response
				var response = new OM2MResponsePrimitive(CseConfig, request);
				response.ResponseStatusCode = OM2MResponseStatusCode.Accepted;
				response.OriginatingTimestamp = OM2MTimeStamp.NowTimeStamp;

				// Recv-5.0: Send Response primitive
				originator.SendResponse(response);

				// Recv-6.0: Resource handling procedures
				response = DoBlockingRequest(request);

				// Recv-7.0: “Update <request> resource”
				req.LastModifiedTime = OM2MTimeStamp.NowTimeStamp;
				req.StateTag++;
				req.RequestStatus = OM2MRequestStatus.Forwarded;

				if (responseType == OM2MResponseType.NonBlockingRequestAsynch)
				{
					// Recv-8.0: “Send Notification”
					var notify = new OM2MRequestPrimitive();
					notify.RequestIdentifier = Guid.NewGuid().ToString();
					notify.Operation = OM2MOperation.Notify;
					notify.From = request.TargetId;
					notify.To = request.From;
					notify.PrimitiveContent = new OM2MPrimitiveContent();
					notify.Content = response.Content;

					var notifyResponse = originator.SendRequest(notify);

					// Recv-9.0: “Wait for Response primitive”
				}
			}
			else
			{
				var response = DoRequestCore(request);
				originator.SendResponse(response);
			}
		}

		public OM2MResponsePrimitive DoBlockingRequest(OM2MRequestPrimitive request)
		{
			try
			{
				ValidateRequest(request);
			}
			catch (OM2MException ex)
			{
				var response = HandleOM2MException(ex, request);
				return response;
			}
			catch (Exception ex)
			{
				var response = HandleOtherException(ex, request);
				return response;
			}
			
			return DoRequestCore(request);
		}

		public string GetCseId(string uri)
		{
			if (Regex.IsMatch(uri, $"^/S{IdPattern}$"))
			{
				return CseConfig.CseBaseId;
			}

			var m = Regex.Match(uri, $"^/(?<cse>{IdPattern})(?:/.*)?$");

			if (!m.Success)
			{
				throw new FormatException(@"Illegal ID format: {uri}");
			}

			return m.Groups["cse"].Value;
		}

		public bool IsHostingCseResouce(string uri)
		{
			return GetCseId(uri) == CseConfig.CseBaseId;
		}

		private OM2MResponsePrimitive DoRequestCore(OM2MRequestPrimitive request)
		{
			var response = new OM2MResponsePrimitive(CseConfig, request);
			
			try
			{
				OM2MController controller = null;

				if (request.TargetId == null && request.To == null)
				{
					throw new OM2MBadRequestException("To parameter is missing.");
				}

				if (request.TargetId == null)
				{
					request.TargetId = request.To;
				}

				// Remove last "/"
				if (request.TargetId.EndsWith("/", StringComparison.Ordinal))
				{
					request.TargetId = request.TargetId.Substring(0, request.TargetId.Length - 1);
				}

				// Uri -> ResourceId
				using (var db = new OM2MDbContext())
				{
					var uriMapEntity = db.UriMaps.Find(request.TargetId);
					if (uriMapEntity != null)
					{
						request.TargetId = uriMapEntity.ResourceId;
					}
				}

				// Recv-6.0.1: Receiver is Registrar CSE & Originator is AE & operation is create
				if (m_cseBasePattern.IsMatch(request.TargetId) &&
				    (request.From == null || m_aePattern.IsMatch(request.From)) &&
				    request.Operation == OM2MOperation.Create)
				{
					// Recv-6.0.2: “Check Service Subscription Profile”
					// ToDo:
				}

				if (request.Content == null)
				{
					if (request.PrimitiveContent != null && request.PrimitiveContent.Any != null
					   && request.PrimitiveContent.Any.Count > 0)
					{
						request.Content = request.PrimitiveContent.Any[0];
					}
				}

				// Recv-6.1: Hosting CSE of the targeted resource?
				if (IsHostingCseResouce(request.TargetId))
				{
					if (request.Operation == OM2MOperation.Create)
					{
						if (request.ResourceType == null)
						{
							throw new OM2MBadRequestException($"Resouce type is missing for creation request.");
						}
						controller = GetControllerFromResouceType(request.ResourceType.Value);
					}
					else
					{
						controller = GetControllerFromUri(request.TargetId);
					}

					if (controller == null)
					{
						throw new OM2MBadRequestException($"Invalid request.");

					}

					response = controller.DoRequest(request);

					if (request.ResultContent != null &&
					   request.ResultContent == OM2MResultContent.Nothing)
					{
						response.Content = null;
					}
				}
				else
				{
					// ToDo:Recv-6.9: CMDH processing supported?
					// Now Not supported

					// Recv-6.11: “Forwarding”
					response = Fowarding(request);
				}
			}
			catch (OM2MException ex)
			{
				response.ResponseStatusCode = ex.ResponseStatusCode;
			}
			catch (Exception ex)
			{
				response.ResponseStatusCode = OM2MResponseStatusCode.InternalServerError;
			}

			return response;
		}

		// Recv-6.11: “Forwarding”
		private OM2MResponsePrimitive Fowarding(OM2MRequestPrimitive request)
		{
			// Check timeout
			if (OM2MTimeStamp.IsTimeout((string)request.RequestExpirationTimestamp))
			{
				throw new OM2MRequestTimeoutException();
			}

			if (OM2MTimeStamp.IsTimeout((string)request.ResultExpirationTimestamp))
			{
				throw new OM2MRequestTimeoutException();
			}

			if (OM2MTimeStamp.IsTimeout((string)request.OperationExecutionTime))
			{
				throw new OM2MRequestTimeoutException();
			}

			// Get remote CSE Id
			string remoteCseId;

			var parts = request.TargetId.Split('/');
			if (parts.Length < 2)
			{
				throw new OM2MNotFoundException("Remote CSE not found");
			}

			remoteCseId = parts[1];

			// ToDo:...

			return null;
		}

		private OM2MResponsePrimitive Notify(OM2MRequestPrimitive request,
		                                    string target)
		{
			if (Regex.IsMatch(target, ".*://.*"))
			{
				throw new NotImplementedException();
			}
			else
			{
				request.To = target;
				request.TargetId = target;

				return DoBlockingRequest(request);
			}
		}

		public void Notify(IList<OM2MSubscriptionEntity> list,
							OM2MResourceEntity resource,
							OM2MResourceStatus resourceStatus)
		{
		}

		public void NotifyDeletion(IList<OM2MSubscriptionEntity> list,
							OM2MResourceEntity deletedResouce)
		{
			
		}

		public OM2MCseConfig CseConfig
		{
			get;
			private set;
		}

		public bool IsInitalized
		{
			get;
			private set;
		}
	}

	public enum OM2MResourceStatus
	{
		ChildCreated,
		Updated,
		Deleted,
	}
}
