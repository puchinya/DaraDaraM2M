using System;
using DaraDaraM2M.Services;

namespace DaraDaraM2M.Components
{
	public interface IOM2MInfrastructureComponent
	{
		IOM2MAuthorizationService AuthorizationService
		{
			get;
		}
		
		IOM2MRegistrationService RegistrationService
		{
			get;
		}
	}
}
