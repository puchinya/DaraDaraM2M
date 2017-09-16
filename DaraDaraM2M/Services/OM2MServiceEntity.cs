using System;
namespace DaraDaraM2M.Services
{
	public class OM2MServiceEntity
	{
		/// <summary>
		/// The M2M Service Identifier (M2M-Serv-ID).
		/// </summary>
		/// <value>The service identifier.</value>
		public string ServiceId
		{
			get;
			set;
		}

		/// <summary>
		/// List of Service Role Identifiers (SRole-ID) associated with the Service.
		/// </summary>
		/// <value>The service role identifiers.</value>
		public string[] ServiceRoleIds
		{
			get;
			set;
		}
	}

}
