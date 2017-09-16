using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaraDaraM2M.Model
{
	[Table("resources")]
	public abstract class OM2MResourceEntity
	{
		[Column("rn")]
		public string ResourceName { get; set; }

		[Column("ty")]
		[Required]
		public int ResourceType { get; set; }

		[Column("ri")]
		[Key]
		public string ResourceId { get; set; }

		[Column("pi")]
		public string ParentId { get; set; }

		[ForeignKey("ParentId")]
		public OM2MResourceEntity Parent
		{
			get;
			set;
		}

		[Column("ct")]
		[Required]
		public string CreationTime { get; set; }

		[Column("lt")]
		[Required]
		public string LastModifiedTime { get; set; }

		private List<string> m_labels;

		[Column("lbl")]
		public string LabelsCore
		{
			get
			{
				return Util.StringListToString(Labels);
			}
			set
			{
				m_labels = Util.StringToStringList(value);
			}
		}

		[NotMapped]
		public List<string> Labels
		{
			get
			{
				if (m_labels == null)
				{
					m_labels = new List<string>();
				}

				return m_labels;
			}
		}

		[Column("_huri")]
		public string HierarchicalUri
		{
			get;
			set;
		}

		[InverseProperty("Parent")]
		public ICollection<OM2MResourceEntity> ResourcesCore
		{
			get;
			set;
		}

		[NotMapped]
		public ICollection<OM2MResourceEntity> Resources
		{
			get
			{
				if (ResourcesCore == null)
				{
					ResourcesCore = new List<OM2MResourceEntity>();
				}
				return ResourcesCore;
			}
		}
	}
}
