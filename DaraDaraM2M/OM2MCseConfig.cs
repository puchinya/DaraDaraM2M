using System;
using DaraDaraM2M.Data;

namespace DaraDaraM2M
{
	public class OM2MCseConfig
	{
		public OM2MCseConfig()
		{
			CseType = OM2MCseTypeID.InCSE;
			CseBaseAddress = "127.0.0.1";
			CseBaseContext = "/";
			CseBaseId = "in-cse";
			CseBaseName = "in-cse";
			AdminAcpName = "acp_admin";
			AdminOriginator = "admin:admin";
		}

		public OM2MCseTypeID CseType
		{
			get;
			set;
		}

		public string ServieProviderId
		{
			get;
			set;
		}

		public string RemoteCseHost
		{
			get;
			set;
		}

		public int RemoteCsePort
		{
			get;
			set;
		}

		public string RemoteCseContext
		{
			get;
			set;
		}

		public string CseBaseAddress
		{
			get;
			set;
		}

		public string CseBaseContext
		{
			get;
			set;
		}

		public string CseBaseId
		{
			get;
			set;
		}

		public string CseBaseName
		{
			get;
			set;
		}

		public string AdminAcpName
		{
			get;
			set;
		}

		public string AdminOriginator
		{
			get;
			set;
		}
	}
}
