using System;
using DaraDaraM2M.Services;
using DaraDaraM2M.Components;

namespace DaraDaraM2M
{
	public class OM2MInfrastructureComponentImpl : IOM2MInfrastructureComponent
	{
		public OM2MInfrastructureComponentImpl()
		{
		}

		public IOM2MAuthorizationService AuthorizationService
		{
			get;
			private set;
		}

		public IOM2MRegistrationService RegistrationService
		{
			get;
			private set;
		}
	}
}
