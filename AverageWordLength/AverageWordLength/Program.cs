using System;

namespace AverageWordLength
{
	class Program
	{
		static void Main()
		{
			string text = Console.ReadLine();
			Console.WriteLine(WordLengthCounter.GetAverageWordLength(text).ToString());
			Console.ReadKey();
		}
	}
}
