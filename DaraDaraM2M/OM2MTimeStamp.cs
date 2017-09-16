using System;
using System.Text.RegularExpressions;

namespace DaraDaraM2M
{
	public sealed class OM2MTimeStamp
	{
		private OM2MTimeStamp()
		{
		}

		private static Regex m_timeStampPattern = new Regex(
			"^(?<year>[0-9][0-9][0-9][0-9])(?<month>[0-1][0-9])(?<day>[0-3][0-9])T(?<hour>[0-2][0-9])(?<min>[0-5][0-9])(?<sec>[0-5][0-9])$");

		public static DateTime ToDateTime(string timeStamp)
		{
			var m = m_timeStampPattern.Match(timeStamp);
			if (m.Success)
			{
				throw new FormatException($"Illegal date time format: {timeStamp}");
			}
			int year = int.Parse(m.Groups["year"].Value);
			int month = int.Parse(m.Groups["month"].Value);
			int day = int.Parse(m.Groups["day"].Value);
			int hour = int.Parse(m.Groups["hour"].Value);
			int min = int.Parse(m.Groups["min"].Value);
			int sec = int.Parse(m.Groups["sec"].Value);

			return new DateTime(year, month, day, hour, min, sec);
		}

		public static bool IsTimeout(string timeStamp)
		{
			var dt = ToDateTime(timeStamp);

			return dt <= DateTime.UtcNow;
		}

		public static string GetTimeStamp(object absRelTime)
		{
			if (absRelTime is long)
			{
				return DateTime.UtcNow.AddMilliseconds((double)((long)absRelTime)).ToString("yyyyMMddTHHmmss");
			}
			else if (absRelTime is string)
			{
				return (string)absRelTime;
			}

			throw new ArgumentException(nameof(absRelTime));
		}

		public static string NowTimeStamp
		{
			get
			{
				return DateTime.UtcNow.ToString("yyyyMMddTHHmmss");
			}
		}
	}
}
