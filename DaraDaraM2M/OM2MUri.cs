using System;
using System.Text.RegularExpressions;

namespace DaraDaraM2M
{
	public sealed class OM2MUri
	{
		static Regex m_reg = new Regex("^(?<host>//[a-zA-Z0-9-¥¥._¥¥~]+)?(?<path>(?<seg>/[a-zA-Z0-9-¥¥._¥¥~]+)*)(?:#(?<fragment>.+))?$");
		
		public OM2MUri(string address)
		{
			if (address == null)
			{
				throw new ArgumentNullException(address);
			}
			
			Match m = m_reg.Match(address);
			if (!m.Success)
			{
				throw new OM2MUriFromatException();
			}

			OriginalString = address;
			IsAbsoluteUri = m.Groups["host"].Success;
			if (m.Groups["host"].Success)
			{
				Host = m.Groups["host"].Value;
			}
			if (m.Groups["path"].Success)
			{
				LocalPath = m.Groups["path"].Value;
			}
			if (m.Groups["seg"].Success)
			{
				string[] segs = new string[m.Groups["seg"].Captures.Count];
				for (int i = 0; i < segs.Length; i++)
				{
					segs[i] = m.Groups["seg"].Captures[i].Value;
				}
				Segments = segs;
			}
			if (m.Groups["fragment"].Success)
			{
				Fragment = m.Groups["fragment"].Value;
			}
		}

		public string OriginalString
		{
			get;
			private set;
		}

		public bool IsAbsoluteUri
		{
			get;
			private set;
		}

		public string Host
		{
			get;
			private set;
		}

		public string LocalPath
		{
			get;
			private set;
		}

		public string[] Segments
		{
			get;
			private set;
		}

		public string Fragment
		{
			get;
			private set;
		}

		public override string ToString()
		{
			return OriginalString;
		}

		public override bool Equals(object obj)
		{
			return OriginalString.Equals((obj as OM2MUri).OriginalString);
		}

		public override int GetHashCode()
		{
			return OriginalString.GetHashCode();
		}
	}

	public class OM2MUriFromatException : FormatException
	{
	}
}
