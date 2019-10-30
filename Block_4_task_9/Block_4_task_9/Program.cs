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
					manager.RestoreDirectory(DateTime.ParseExact("30.10.2019 11:54", "dd.MM.yyyy HH:mm",CultureInfo.InvariantCulture));
					Console.WriteLine("Press <Escape> to exit.");
				}
			}
		}

		private static DateTime GetDateTimeFromConsole()
		{
			DateTime userTime = default;
			try
			{
				userTime = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy HH-mm", CultureInfo.InvariantCulture);
			}
			catch (ArgumentNullException)
			{
				Console.WriteLine("ArgumentNullException");
			}
			catch (FormatException)
			{
				Console.WriteLine("FormatException");
			}
			return userTime;
		}
	}
}
