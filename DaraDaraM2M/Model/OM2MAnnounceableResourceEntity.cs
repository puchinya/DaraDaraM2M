using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DaraDaraM2M.Data;

namespace DaraDaraM2M.Model
{
	public class OM2MAnnounceableResourceEntity : OM2MRegularResourceEntity, IOM2MAnnounceableEntity
	{
		private List<string> m_announceTo;

		[Column("at")]
		public string AnnounceToCore
		{
			get
			{
				return OM2MJsonSerializer.Serialize(AnnounceTo);
			}
			set
			{
				m_announceTo = OM2MJsonSerializer.Deserialize<List<string>>(value);
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
				return OM2MJsonSerializer.Serialize(AnnouncedAttribute);
			}
			set
			{
				m_announcedAttribute = OM2MJsonSerializer.Deserialize<List<string>>(value);
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
