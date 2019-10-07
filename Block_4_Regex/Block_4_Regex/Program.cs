using System;
using System.Text.RegularExpressions;

namespace Block_4_Regex
{
	class Program
	{
		static void Main()
		{
			string text = Console.ReadLine();
			var emails = StringSearch.GetEmail(text);
			PrintCollection(emails);
			Console.ReadKey();
		}

		private static void PrintCollection(MatchCollection emails)
		{
			foreach (var item in emails)
			{
				Console.WriteLine(item.ToString());
			}
		}
	}
}
