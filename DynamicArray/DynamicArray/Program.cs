using System;
using System.Collections.Generic;

namespace DynamicArray
{
	class Program
	{
		static void Main()
		{
			List<int> vs1 = new List<int> { 1, 1, 1, 1 };
			DynamicArray<int> vs = new DynamicArray<int> { 2, 2, 2, 2, 2 };
			Console.WriteLine(vs.Length.ToString());
			foreach (var item in vs)
			{
				Console.WriteLine(item.ToString());
			}
			Console.WriteLine();

			vs.AddRange(vs1);

			foreach (var item in vs)
			{
				Console.WriteLine(item.ToString());
			}

			Console.ReadKey();
		}
	}
}
