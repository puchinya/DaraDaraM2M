using System;
using System.Linq;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
	public class OM2MProtocolData
	{
		public OM2MProtocolData()
		{
		}

		public object GetValue(string name)
		{
			var query = m_values.Where(x => x.Key == name).Select(x => x.Value);
			if (query.Count() == 0)
			{
				return EmptyValue;
			}

			return query.First();
		}

		public IList<object> GetValues(string name)
		{
			var query = m_values.Where(x => x.Key == name).Select(x => x.Value);
			if (query.Count() == 0)
			{
				return null;
			}

			return query.ToList();
		}

		public bool ExistValue(string name)
		{
			var query = m_values.Where(x => x.Key == name);

			return query.Count() > 0;
		}

		public int GetValuesCount(string name)
		{
			var query = m_values.Where(x => x.Key == name);

			return query.Count();
		}

		public static object EmptyValue = new object();

		private List<KeyValuePair<string, object>> m_values =
			new List<KeyValuePair<string, object>>();
	}
}
