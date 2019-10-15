using System;
using System.Globalization;
using System.IO;

namespace Block4Task9
{
	class Program
	{
		static void Main(string[] args)
		{
			DirectoryWatcher manager = new DirectoryWatcher();
			if (args[0] == "y")
			{
				manager.Watcher.EnableRaisingEvents = true;
				Console.WriteLine("Press <Escape> to exit.");
				while (Console.ReadKey().Key != ConsoleKey.Escape) ;
			}
			else if (args[0] == "n")
			{
				while (Console.ReadKey().Key != ConsoleKey.Escape)
				{
					Console.WriteLine("Enter rollback datetime");
					DateTime userTime = GetDateTimeFromConsole();
					Console.WriteLine("Enter file name");
					string fname = Console.ReadLine();
					Console.WriteLine(manager.RestoreFile(userTime, fname));
					Console.WriteLine("Press <Escape> to exit.");
				}
			}
		}

		private static DateTime GetDateTimeFromConsole()
		{
			DateTime userTime = DateTime.Now;
			try
			{
				userTime = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy HH-mm", CultureInfo.InvariantCulture);
			}
			catch (FormatException)
			{
				Console.WriteLine("");
			}
			return userTime;
		}
	}
}
