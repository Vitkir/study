using System;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace Block_4_Regex
{
	class Program
	{
		static void Main()
		{
			string text = Console.ReadLine();
			PrintCollection(StringSearch.GetTime(text));
		}

		private static void PrintCollection(MatchCollection collection)
		{
			foreach (var item in collection)
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
