using System;
using System.Text.RegularExpressions;

namespace Block_4_Regex
{
	class Program
	{
		static void Main()
		{
			string text = Console.ReadLine();
			PrintNumberToConsole(text, StringSearch.IsNumber);
			Console.ReadKey();
		}

		private static void PrintCollection(MatchCollection emails)
		{
			foreach (var item in emails)
			{
				Console.WriteLine(item.ToString());
			}
		}

		private static void PrintNumberToConsole(string text, Func<string, bool> isNumber)
		{
			if (isNumber(text))
			{
				Console.WriteLine(text + " is number");
			}
		}
	}
}
