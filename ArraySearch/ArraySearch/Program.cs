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

			int[] vs = {66, 80, 11, -33, -99, -71, 25, -65, 36,
				-94, 17, 4, 10, 6, 86, 62, 65, 49, -13, 89, -34, 90,
				91, -6, 37, 18, -8, -80, -92, 29, -39, 50, 15, 3, 46,
				84, -12, 81, 95, -89, 83, -48, -85, -1, 16, 24, -56, 8,
				64, -20, -26, -51, 14, 27, 68, -37, 51, -2, 41, -77, -17,
				44, -55, -31, 40, -68, -63, 97, -100, -96, 99};
			int count = 0;
			stopwatch.Start();
			while (count < 10)
			{
				var result = from item in vs
							 where item < 0
							 select item;
				PrintToConsole(result);
				ArraySearch.GetNumbers(vs, print);
				ArraySearch.GetNumbers(vs, isEquals1, print);
				ArraySearch.GetNumbers(vs, isEquals2, print);
				ArraySearch.GetNumbers(vs, isEquals3, print);
				count++;
			}
			stopwatch.Stop();
			var time = stopwatch.ElapsedMilliseconds;
			Console.Clear();
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
