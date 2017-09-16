using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DaraDaraM2M.Data;

namespace DaraDaraM2M.Model
{
	public class OM2MContainerEntity : OM2MAnnounceableResourceEntity
	{
		[Column("st")]
		[Required]
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

		[Column("mni")]
		public int? MaxNrOfInstances
		{
			get;
			set;
		}

		[Column("mbs")]
		public int? MaxByteSize
		{
			get;
			set;
		}

		[Column("mia")]
		public int? MaxInstanceAge
		{
			get;
			set;
		}

		[Column("cni")]
		[Required]
		public int CurrentNrOfInstances
		{
			get;
			set;
		}

		[Column("cbs")]
		[Required]
		public int CurrentByteSize
		{
			get;
			set;
		}

		[Column("li")]
		public string LocationID
		{
			get;
			set;
		}

		[Column("or")]
		public string OntologyRef
		{
			get;
			set;
		}

		[Column("disr")]
		public bool DisableRetrieval
		{
			get;
			set;
		}
	}
}
