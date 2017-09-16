using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DaraDaraM2M.Data;

namespace DaraDaraM2M.Model
{
	public class OM2MContentInstanceEntity : OM2MAnnounceableSubordinateResourceEntity
	{
		[Column("st")]
		public int StateTag
		{
			get;
			set;
		}

		[Column("cr")]
		public string Creator
		{
			get;
			set;
		}

		[Column("cnf")]
		public string ContentInfo
		{
			get;
			set;
		}

		[Column("cs")]
		public int? ContentSize
		{
			get;
			set;
		}

		private OM2MContentRef m_contentRef;

		[Column("conr")]
		public string ContentRefCore
		{
			get
			{
				if (m_contentRef == null) return null;
				return OM2MJsonSerializer.Serialize(m_contentRef);
			}

			set
			{
				if (value == null)
				{
					m_contentRef = null;
				}
				else
				{
					m_contentRef = OM2MJsonSerializer.Deserialize<OM2MContentRef>(value);
				}
			}
		}

		[NotMapped]
		public OM2MContentRef ContentRef
		{
			get
			{
				return m_contentRef;
			}
			set
			{
				m_contentRef = value;
			}
		}

		[Column("or")]
		public string OntologyRef
		{
			get;
			set;
		}

		[Column("con")]
		public string Content
		{
			get;
			set;
		}
	}
}
