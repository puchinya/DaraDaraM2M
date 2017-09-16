using System;
using System.Collections.Generic;

namespace DaraDaraM2M
{
	public interface IOM2MHasAccessControlPolicyIdsEntity
	{
		List<string> AccessControlPolicyIds
		{
			get;
		}
	}
}
