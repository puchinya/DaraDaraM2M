using System;
using System.Collections.Generic;
using System.Text;

namespace DaraDaraM2M
{
	class Util
	{
		public static string EncodeString(string value)
		{
			return value.Replace("¥¥", "¥¥¥¥").Replace(" ", "¥¥s");
		}

		public static string DecodeString(string value)
		{
			return value.Replace("¥¥s", " ").Replace("¥¥¥¥", "¥¥");
		}

		public static string StringListToString(List<string> list)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < list.Count; i++)
			{
				if (i > 0) sb.Append(' ');
				sb.Append(EncodeString(list[i]));
			}

			return sb.ToString();
		}

		public static List<string> StringToStringList(string text)
		{
			if (text.Length == 0)
			{
				return new List<string>();
			}
			
			var items = text.Split(' ');
			var list = new List<string>(items.Length);
			for (int i = 0; i < items.Length; i++)
			{
				list.Add(items[i]);
			}

			return list;
		}
		
		// For enum
		public static string EnumListToString<T>(List<T> enumList)
			where T : struct, IComparable, IFormattable, IConvertible
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < enumList.Count; i++)
			{
				if (i > 0) sb.Append(' ');
				sb.Append((int)(object)enumList[i]);
			}

			return sb.ToString();
		}

		// For enum
		public static List<T> StringToEnumList<T>(string text)
			where T : struct, IComparable, IFormattable, IConvertible
		{
			if (text.Length == 0)
			{
				return new List<T>();
			}
			
			var items = text.Split(' ');
			var list = new List<T>(items.Length);
			for (int i = 0; i < items.Length; i++)
			{
				list.Add((T)Enum.ToObject(typeof(T), int.Parse(items[i])));
			}

			return list;
		}
	}
}
