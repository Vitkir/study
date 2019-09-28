using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ArraySearch
{
	class Program
	{
		static void Main()
		{
			Action<int> print = PrintToConsole;

			ArraySearch.IsEquals isEquals1 = IsPositive;

			ArraySearch.IsEquals isEquals2 = delegate (int item)
			{
				if (item > 0)
					return true;
				else return false;
			};

			ArraySearch.IsEquals isEquals3 = item => item > 0;

			Stopwatch stopwatch = new Stopwatch();

			int[] vs = { 2, -5, 0, 2, 6, 8, -5, -6, -9, 56, -78, 4 };

			stopwatch.Start();

			var result = from item in vs
						 where item < 0
						 select item;
			PrintToConsole(result);

			ArraySearch.GetNumbers(vs, print);
			ArraySearch.GetNumbers(vs, isEquals1, print);
			ArraySearch.GetNumbers(vs, isEquals2, print);
			ArraySearch.GetNumbers(vs, isEquals3, print);

			stopwatch.Stop();
			var time = stopwatch.ElapsedMilliseconds;
			Console.WriteLine(time.ToString());

			Console.ReadKey();
		}

		static bool IsPositive(int item)
		{
			if (item > 0)
				return true;
			else return false;
		}

		static void PrintToConsole(int item)
		{
			Console.Write(item.ToString() + " ");
		}

		static void PrintToConsole(IEnumerable<int> result)
		{
			foreach (var item in result)
			{
				Console.Write(item.ToString() + " ");
			}
		}
	}
}
