using System;

namespace Block_4_Task_1_and_2
{
	class Program
	{
		static void Main()
		{
			string text = Console.ReadLine();
			string pattern = Console.ReadLine();
			Console.WriteLine(WorkWithString.DoublingLetter(text, pattern).ToString());
			Console.ReadKey();
		}
	}
}
