using System;
using System.Linq;
using DaraDaraM2M.Data;
using DaraDaraM2M.Services;
using System.Diagnostics;

namespace DaraDaraM2M
{
	public class OM2MSSUBServiceAdministrationServiceImpl : IOM2MServiceAdministrationService
	{
		public OM2MSSUBServiceAdministrationServiceImpl()
		{
		}

		public OM2MResponseStatusCode CreateM2MService(string name,
		                                               string description,
		                                              out string serviceId)
		{
			if (name == null)
			{
				throw new ArgumentNullException(nameof(name));
			}

			string serviceId_;

			serviceId = null;

			serviceId_ = Guid.NewGuid().ToString();

			try
			{
				using (var db = new OM2MDbContext())
				{
					var temp = db.Services.Count(x => x.Name == name);
					if (temp != 0)
					{
						return OM2MResponseStatusCode.AlreadyExists;
					}

					var data = new Model.OM2MServiceEntity();

					data.Name = name;
					data.Description = description;
					data.ServiceId = serviceId_;

					db.Services.Add(data);

					db.SaveChanges();
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());

				return OM2MResponseStatusCode.InternalServerError;
			}

			serviceId = serviceId_;

			return OM2MResponseStatusCode.Created;
		}

		public OM2MResponseStatusCode DeleteM2MService(string serviceId)
		{
			if (serviceId == null)
			{
				throw new ArgumentNullException(nameof(serviceId));
			}

			try
			{
				using (var db = new OM2MDbContext())
				{
					Model.OM2MServiceEntity data;

					try
					{
						data = db.Services.Single(x => x.ServiceId == serviceId);
					}
					catch (InvalidOperationException ex)
					{
						Debug.WriteLine(ex.ToString());
						return OM2MResponseStatusCode.NotFound;
					}

					db.Services.Remove(data);

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

		public OM2MResponseStatusCode AddRoleToM2MService(string serviceId,
								 string[] serviceRoleIds)
		{
			if (serviceId == null)
			{
				throw new ArgumentNullException(nameof(serviceId));
			}
			if (serviceRoleIds == null)
			{
				throw new ArgumentNullException(nameof(serviceRoleIds));
			}

			try
			{
				using (var db = new OM2MDbContext())
				{
					Model.OM2MServiceEntity data;

					try
					{
						data = db.Services.Single(x => x.ServiceId == serviceId);
					}
					catch (InvalidOperationException ex)
					{
						Debug.WriteLine(ex.ToString());
						return OM2MResponseStatusCode.NotFound;
					}

					foreach (var roleId in serviceRoleIds)
					{
						if (!data.ServiceRoleIds.Contains(roleId))
						{
							data.ServiceRoleIds.Add(roleId);
						}
					}

					db.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());

				return OM2MResponseStatusCode.InternalServerError;
			}

			return OM2MResponseStatusCode.Ok;
		}

		public OM2MResponseStatusCode DeleteRoleFromM2MService(string serviceId,
									  string[] serviceRoleIds)
		{
			if (serviceId == null)
			{
				throw new ArgumentNullException(nameof(serviceId));
			}
			if (serviceRoleIds == null)
			{
				throw new ArgumentNullException(nameof(serviceRoleIds));
			}

			try
			{
				using (var db = new OM2MDbContext())
				{
					Model.OM2MServiceEntity data;

					// Get service
					try
					{
						data = db.Services.Single(x => x.ServiceId == serviceId);
					}
					catch (InvalidOperationException ex)
					{
						Debug.WriteLine(ex.ToString());
						return OM2MResponseStatusCode.NotFound;
					}

					// Check roleId existing
					foreach (var roleId in serviceRoleIds)
					{
						if (!data.ServiceRoleIds.Contains(roleId))
						{
							return OM2MResponseStatusCode.NoMembers;
						}
					}

					// Remove roleIds
					foreach (var roleId in serviceRoleIds)
					{
						data.ServiceRoleIds.Remove(roleId);
					}

					db.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());

				return OM2MResponseStatusCode.InternalServerError;
			}

			return OM2MResponseStatusCode.Ok;
		}

		public OM2MResponseStatusCode GetM2MService(OM2MServiceSubscriptionFilterCriteria filterCriteria,
						   out OM2MServiceEntity[] services)
		{
			if (filterCriteria == null)
			{
				throw new ArgumentNullException(nameof(filterCriteria));
			}

			if (filterCriteria.serviceRoleIds == null)
			{
				throw new ArgumentNullException(nameof(filterCriteria));
			}

			throw new NotImplementedException();
		}

		public OM2MResponseStatusCode AddServiceCapabilityToRole(string serviceCapId,
									   string[] serviceRoleIds)
		{
			throw new NotImplementedException();
		}

		public OM2MResponseStatusCode DeleteServiceCapabilityToRole(string serviceCapId,
									   string[] serviceRoleIds)
		{
			throw new NotImplementedException();
		}

		public OM2MResponseStatusCode GetServiceCapability(OM2MOperation operation,
								  out string serviceCapId,
								  out string[] serviceRoleIds)
		{
			throw new NotImplementedException();
		}
	}
}
