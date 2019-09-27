using System;

namespace ArrayIntExtension
{
	class Program
	{
		static void Main()
		{
			int[] vs = { 2, 5, 6, 8, 1, 3, 6 };
			int sumItem = vs.SumArrayElements();
			Console.WriteLine(sumItem.ToString());
			Console.ReadKey();
		}
	}
}
