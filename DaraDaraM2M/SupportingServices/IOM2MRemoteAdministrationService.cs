using System;
using DaraDaraM2M.Data;

namespace DaraDaraM2M
{
	public interface IOM2MRemoteAdministrationService
	{
		void NotifyRegistrationContact(string aeId, string event_);
	}
}
