using System;
using System.Linq;
using DaraDaraM2M.Data;
using DaraDaraM2M.Model;
using DaraDaraM2M.Services;
using System.Diagnostics;

namespace DaraDaraM2M
{
	class OM2MSERegistrationServiceImpl : IOM2MRegistrationService
	{
		public OM2MSERegistrationServiceImpl(IOM2MServiceSubscriptionService ssubServiceSubscription)
		{
			ServiceSubscription = ssubServiceSubscription;
		}

		private IOM2MServiceSubscriptionService ServiceSubscription
		{
			get;
			set;
		}

		public OM2MResponseStatusCode RegisterAE(string pointOfAccess,
						string applicationId,
						string credentialId,
						DateTime exprirationTime,
						OM2MSchedule reachabilitySchedule,
						ref string aeId)
		{
			if (applicationId == null)
			{
				throw new ArgumentNullException(nameof(applicationId));
			}

			if (aeId != null)
			{
				if (aeId.Length < 2 && aeId[0] != 'S')
				{
					throw new ArgumentException(nameof(aeId));
				}
			}

			string serviceSubscriptionId;
			string aeId_ = aeId;
			int dummyId = 0;

			using (var db = new OM2MDbContext())
			{
				db.Database.BeginTransaction();

				if (aeId_ == null)
				{
					var id = db.GenerateId();

					aeId_ = $"C{dummyId}";
				}

				if (ServiceSubscription.AssociateAEWithServiceSubscription(aeId_,
																	   credentialId,
																	   applicationId,
																	   out serviceSubscriptionId)
				   != OM2MResponseStatusCode.Ok)
				{
					db.Database.RollbackTransaction();
					return OM2MResponseStatusCode.InternalServerError;
				}

				try
				{
					// Check duplicate
					var query = db.Resources.Where(x => x.ResourceId == aeId_);

					if (query.Count() == 0)
					{
						var data = query.First() as OM2MAEEntity;
						data.AEId = aeId_;
						data.AppId = applicationId;
						//data.CredentialId = credentialId;
						//data.ExpirationTime = exprirationTime;
					}
					else
					{
						var data = new OM2MAEEntity();

						data.AEId = aeId_;
						data.AppId = applicationId;
						//data.CredentialId = credentialId;
						//data.ExpirationTime = exprirationTime;

						db.Resources.Add(data);
					}

					db.SaveChanges();
					db.Database.CommitTransaction();
				}
				catch (Exception ex)
				{
					db.Database.RollbackTransaction();

					Debug.WriteLine(ex.ToString());

					return OM2MResponseStatusCode.InternalServerError;
				}

				aeId = aeId_;
			}

			return OM2MResponseStatusCode.Created;
		}

		public OM2MResponseStatusCode RefreshAERegistration(string aeId,
											   string pointOfAccess,
											   DateTime expirationTime,
											   OM2MSchedule reachabilitySchedule)
		{
			try
			{
				using (var db = new OM2MDbContext())
				{
					OM2MAEEntity data;

					try
					{
						data = db.Resources.Single(x => x is OM2MAEEntity && x.ResourceId == aeId) as OM2MAEEntity;
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

		public OM2MResponseStatusCode DeregisterAE(string aeId)
		{
			try
			{
				using (var db = new OM2MDbContext())
				{
					OM2MAEEntity data;

					try
					{
						data = db.Resources.Single(x => x is OM2MAEEntity && ((OM2MAEEntity)x).AEId == aeId) as OM2MAEEntity;
					}
					catch (InvalidOperationException ex)
					{
						Debug.WriteLine(ex.ToString());
						return OM2MResponseStatusCode.NotFound;
					}

					db.Resources.Remove(data);

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
	}
}
