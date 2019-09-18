using System;

namespace WordCounter
{
	class Program
	{
		static void Main()
		{
			var counter = GetCounter();
			counter.ProcessString();
			Print(counter);
			Console.ReadKey();
		}

		static public Counter GetCounter()
		{
			return new Counter()
			{
				Text = Console.ReadLine(),
			};
		}

		static public void Print(Counter counter)
		{
			foreach (var item in counter.Words)
			{
				Console.WriteLine(item.Key.ToString() + " - " + item.Value.ToString());
			}
		}
	}
}
