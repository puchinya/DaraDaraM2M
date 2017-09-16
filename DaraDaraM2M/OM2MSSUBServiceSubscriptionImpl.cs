using System;
using System.Linq;
using System.Diagnostics;
using DaraDaraM2M.Data;
using DaraDaraM2M.Services;

namespace DaraDaraM2M
{
	public class OM2MSSUBServiceSubscriptionImpl : IOM2MServiceSubscriptionService
	{
		public OM2MSSUBServiceSubscriptionImpl()
		{
		}
		
		public OM2MResponseStatusCode ValidateServiceSubscroption(string serviceSubscriptionId,
												string serviceCapId)
		{
			try
			{
				using (var db = new OM2MDbContext())
				{
					Model.OM2MDbServiceSubscription data;

					try
					{
						data = db.ServiceSubscriptions.Single(x => x.ServiceSubscriptionId == serviceSubscriptionId);
					}
					catch (InvalidOperationException ex)
					{
						Debug.WriteLine(ex.ToString());
						return OM2MResponseStatusCode.NotFound;
					}
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());

				return OM2MResponseStatusCode.InternalServerError;
			}
			return OM2MResponseStatusCode.Ok;
		}

		public OM2MResponseStatusCode GetAE(string aeId,
									 out string applicationId,
									 out string serviceSubscriptionId,
									 out string[] externalIds,
									 out OM2MSchedule reachabilitySchedule)
		{
			try
			{
				using (var db = new OM2MDbContext())
				{
					Model.OM2MDbServiceSubscription data;

					try
					{
						data = db.ServiceSubscriptions.Single(x => x.AEId == aeId);
					}
					catch (InvalidOperationException ex)
					{
						Debug.WriteLine(ex.ToString());

						applicationId = null;
						serviceSubscriptionId = null;
						externalIds = null;
						reachabilitySchedule = null;

						return OM2MResponseStatusCode.NotFound;
					}

					applicationId = data.ApplicationId;
					serviceSubscriptionId = null;
					externalIds = null;
					reachabilitySchedule = null;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());

				applicationId = null;
				serviceSubscriptionId = null;
				externalIds = null;
				reachabilitySchedule = null;

				return OM2MResponseStatusCode.InternalServerError;
			}

			return OM2MResponseStatusCode.Ok;
		}

		public OM2MResponseStatusCode GetBroker(string serviceSubscriptionId,
										 string serviceCapId,
										 string aeId,
										 string resource,
										 out IOM2MBrokerService broker)
		{
			broker = new OM2MBrokerServiceImpl(serviceSubscriptionId,
											   serviceCapId,
											   aeId,
											   resource);
			return OM2MResponseStatusCode.Ok;
		}

		public OM2MResponseStatusCode GetManagmentAdapter(string serviceSubscriptionId,
												   		  string serviceCapId,
												   		  string deviceId,
		                                                  out IOM2MManagmentAdapterService managementAdapter)
		{
			managementAdapter = null;
			return OM2MResponseStatusCode.Ok;
		}

		public OM2MResponseStatusCode GetTransportAdapter(string serviceSubscriptionId,
												   string serviceCapId,
												   string deviceId,
												   out object transportAdapter)
		{
			transportAdapter = null;
			return OM2MResponseStatusCode.Ok;
		}

		public OM2MResponseStatusCode AssociateAEWithServiceSubscription(string aeId,
																 string credentialId,
																 string applicationId,
																 out string serviceSubscriptionId)
		{
			string serviceSubscriptionId_ = Guid.NewGuid().ToString();

			try
			{

				using (var db = new OM2MDbContext())
				{
					// Check duplicate
					while (true)
					{
						var temp = db.ServiceSubscriptions.Count(x => x.ServiceSubscriptionId == serviceSubscriptionId_);
						if (temp == 0)
						{
							break;
						}
						serviceSubscriptionId_ = Guid.NewGuid().ToString();
					}

					var data = new Model.OM2MDbServiceSubscription();

					data.ServiceSubscriptionId = serviceSubscriptionId_;
					data.AEId = aeId;
					data.CredentialId = credentialId;
					data.ApplicationId = applicationId;

					db.ServiceSubscriptions.Add(data);

					db.SaveChanges();
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());

				serviceSubscriptionId = null;
				return OM2MResponseStatusCode.InternalServerError;
			}

			serviceSubscriptionId = serviceSubscriptionId_;

			return OM2MResponseStatusCode.Created;
		}

		public OM2MResponseStatusCode DisassociateAEFromServiceSubscription(string aeId,
																 			string serviceSubscriptionId)
		{
			try
			{
				using (var db = new OM2MDbContext())
				{
					Model.OM2MDbServiceSubscription data;

					try
					{
						data = db.ServiceSubscriptions.Single(x => x.AEId == aeId && x.ServiceSubscriptionId == serviceSubscriptionId);
					}
					catch (InvalidOperationException ex)
					{
						Debug.WriteLine(ex.ToString());
						return OM2MResponseStatusCode.NotFound;
					}

					db.ServiceSubscriptions.Remove(data);

					db.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());

				return OM2MResponseStatusCode.InternalServerError;
			}
			return OM2MResponseStatusCode.Deleted;
		}

		public OM2MResponseStatusCode RefreshAEAssociationWithServiceSubscription(string aeId,
																		   string serviceSubscriptionId)
		{
			try
			{
				using (var db = new OM2MDbContext())
				{
					Model.OM2MDbServiceSubscription data;

					try
					{
						data = db.ServiceSubscriptions.Single(x => x.AEId == aeId && x.ServiceSubscriptionId == serviceSubscriptionId);
					}
					catch (InvalidOperationException ex)
					{
						Debug.WriteLine(ex.ToString());
						return OM2MResponseStatusCode.NotFound;
					}

					db.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());

				return OM2MResponseStatusCode.InternalServerError;
			}
			return OM2MResponseStatusCode.Updated;
		}
	}
}
