using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Model
{
	public interface IOM2MAnnounceableEntity
	{
		List<string> AnnounceTo
		{
			get;
		}

		List<string> AnnouncedAttribute
		{
			get;
		}
	}
}
