using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

namespace OM2MXSDCodeGen
{
	public class ShortLongNamePair
	{
		public ShortLongNamePair()
		{
		}

		public string LongName
		{
			get;
			set;
		}

		public string ShortName
		{
			get;
			set;
		}

		public static List<ShortLongNamePair> Parse(string csvFileName)
		{
			using (var reader = new CsvReader(new StreamReader(csvFileName)))
			{
				reader.Configuration.HasHeaderRecord = true;
				reader.Configuration.RegisterClassMap<ShortLongNamePairMap>();
				var records = reader.GetRecords<ShortLongNamePair>();
				return new List<ShortLongNamePair>(records);
			}
		}
	}

	class ShortLongNamePairMap : CsvClassMap<ShortLongNamePair>
	{
		public ShortLongNamePairMap()
		{
			Map(m => m.LongName).Index(0);
			Map(m => m.ShortName).Index(1);
		}
	}
}
