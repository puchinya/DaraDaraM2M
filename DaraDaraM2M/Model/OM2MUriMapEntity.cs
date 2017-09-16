using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DaraDaraM2M.Data;

namespace DaraDaraM2M.Model
{
	[Table("urimap")]
	public class OM2MUriMapEntity
	{
		[Key]
		[Column("uri")]
		[Required]
		[MaxLength(512)]
		public string Uri
		{
			get;
			set;
		}

		[Column("ri")]
		[Required]
		[MaxLength(128)]
		public string ResourceId
		{
			get;
			set;
		}
	}
}
