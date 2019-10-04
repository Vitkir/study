using System;

namespace Block_4_Regex
{
	class Program
	{
		static void Main()
		{
			string text = Console.ReadLine();
			var emails = StringSearch.GetEmail(text);
			foreach (var item in emails)
			{
				Console.WriteLine(item.ToString());
			}
			//Console.WriteLine(StringSearch.GetEmail(text));
			Console.ReadKey();
		}
	}
}
