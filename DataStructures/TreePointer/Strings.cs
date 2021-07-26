using System;
using System.Collections.Generic;
using System.Text;

namespace TreePointer
{
	public class Strings
	{
		public static string Repeat(string str, int count)
		{
			if (str == null) return null;

			StringBuilder builder = new StringBuilder();
			while (count-- > 0)
			{
				builder.Append(str);
			}
			return builder.ToString();
		}

		public static string Blank(int length)
		{
			if (length < 0) return null;
			if (length == 0) return "";
			StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
				sb.Append(" ");

			}
			return sb.ToString();
			//return string.Format("%" + length + "s", "");
		}
	}

}
