using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DaraDaraM2M.Data;

namespace DaraDaraM2M.Model
{
	public class OM2MAEEntity : OM2MAnnounceableResourceEntity
	{
		[Column("apn")]
		public string AppName { get; set; }

		[Column("api")]
		[Required]
		public string AppId { get; set; }

		[Column("aei")]
		public string AEId { get; set; }

		private List<string> m_pointOfAccess;

		[Column("poa")]
		[Required]
		public string PointOfAccessCore
		{
			get
			{
				return OM2MJsonSerializer.Serialize(PointOfAccess);
			}
			set
			{
				m_pointOfAccess = OM2MJsonSerializer.Deserialize<List<string>>(value);
			}
		}

		[NotMapped]
		public List<string> PointOfAccess
		{
			get
			{
				if (m_pointOfAccess == null)
				{
					m_pointOfAccess = new List<string>();
				}

				return m_pointOfAccess;
			}
		}

		[Column("or")]
		public string OntologyRef
		{
			get;
			set;
		}

		[Column("nl")]
		public string NodeLink
		{
			get;
			set;
		}

		[Column("rr")]
		[Required]
		public bool RequestReachability
		{
			get;
			set;
		}
	}
}
