using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyString
{
	class MyString
	{
		public char[] String { get; set; }

		public static MyString operator +(MyString str1, MyString str2)
		{
			char[] result = { str1.String[str1.String.Length], str2.String[str2.String.Length] };
			return new MyString(result);
		}

		public static bool operator ==(MyString str1, MyString str2)
		{
			if (str1.String.Length == str2.String.Length)
			{
				for (int i = 0; i < str1.String.Length; i++)
				{
					for (int j = 0; j < str2.String.Length; j++)
					{
						if (str1.String[i] == str2.String[j])
						{
							return true;
						}
					}
				}
				return true;
			}
			else
			{
				return false;
			}
		}

		public static bool operator !=(MyString str1, MyString str2)
		{
			return str1 != str2;
		}

		public static bool operator >(MyString str1, MyString str2)
		{
			return str1.String.Length > str2.String.Length;
		}

		public static bool operator <(MyString str1, MyString str2)
		{
			return !(str1 > str2);
		}

		public static bool operator >=(MyString str1, MyString str2)
		{
			return str1.String.Length >= str2.String.Length;
		}

		public static bool operator <=(MyString str1, MyString str2)
		{
			return !(str1 >= str2);
		}

		public MyString(char[] str)
		{
			String = str;
		}
	}
}
