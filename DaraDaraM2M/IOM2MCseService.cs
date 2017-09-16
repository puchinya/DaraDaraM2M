using System;
using DaraDaraM2M.Data;

namespace DaraDaraM2M
{
	public interface IOM2MCseService
	{
		void DoRequest(OM2MRequestPrimitive request, IOM2MOriginator originator);
		OM2MResponsePrimitive DoBlockingRequest(OM2MRequestPrimitive request);

		OM2MCseConfig CseConfig { get; }
	}

	public interface IOM2MOriginator
	{
		void SendResponse(OM2MResponsePrimitive response);
		OM2MResponsePrimitive SendRequest(OM2MRequestPrimitive request);
	}
}
