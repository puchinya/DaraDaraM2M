using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DaraDaraM2M.Data;

namespace DaraDaraM2M.Model
{
	public abstract class OM2MAnnounceableSubordinateResourceEntity : OM2MResourceEntity, IOM2MAnnounceableEntity
	{
		[Column("et")]
		[Required]
		public string ExpirationTime
		{
			get;
			set;
		}

		private List<string> m_announceTo;

		[Column("at")]
		public string AnnounceToCore
		{
			get
			{
				return Util.StringListToString(AnnounceTo);
			}
			set
			{
				m_announceTo = Util.StringToStringList(value);
			}
		}

		[NotMapped]
		public List<string> AnnounceTo
		{
			get
			{
				if (m_announceTo == null)
				{
					m_announceTo = new List<string>();
				}

				return m_announceTo;
			}
		}

		private List<string> m_announcedAttribute;

		[Column("aa")]
		public string AnnouncedAttributeCore
		{
			get
			{
				return Util.StringListToString(AnnouncedAttribute);
			}
			set
			{
				m_announcedAttribute = Util.StringToStringList(value);
			}
		}

		[NotMapped]
		public List<string> AnnouncedAttribute
		{
			get
			{
				if (m_announcedAttribute == null)
				{
					m_announcedAttribute = new List<string>();
				}

				return m_announcedAttribute;
			}
		}
	}
}
