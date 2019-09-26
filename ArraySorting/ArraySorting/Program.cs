using System;

namespace ArraySorting
{
	class Program
	{
		static void Main()
		{
			Compare<string> compare = CompareString;
			string[] vs = { "There", "are", "many", "big", "and", "small", "libraries", "everywhere", "in", "our", "country" };
			Print(vs);
			vs.StoogeSort(compare);
			PrintString(vs);
			Console.ReadKey();
		}

		public static int CompareInt(int item1, int item2)
		{
			if (item1 < item2)
				return 1;
			else if (item2 < item1)
				return -1;
			else return 0;
		}

		public static int CompareString(string str1, string str2)
		{
			if (str1.Length < str2.Length)
				return 1;
			else if (str2.Length < str1.Length)
				return -1;
			else return 0;
		}
		static void Print(Array array)
		{
			foreach (var item in array)
			{
				Console.Write(item.ToString() + " ");
			}
			Console.WriteLine();
		}
		static void PrintString(Array array)
		{
			foreach (string item in array)
			{
				Console.WriteLine(item.ToString() + " - " + item.Length);
			}
			Console.WriteLine();
		}
	}
}
