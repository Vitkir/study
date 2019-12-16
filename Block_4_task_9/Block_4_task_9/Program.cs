using System;
using System.Configuration;
using System.Globalization;

namespace Block4Task9
{
	class Program
	{
		static void Main(string[] args)
		{
			ConsoleKey escape = ConsoleKey.Escape;
			ConsoleKey enter = ConsoleKey.Enter;

			string helpEscape = $"Press <{escape.ToString()}> to exit";

			DirectoryWatcher manager = new DirectoryWatcher(ConfigurationManager.AppSettings.Get("workDirectory"), 
				ConfigurationManager.AppSettings.Get("backupDirectory"));

			if (args[0] == "y")
			{
				manager.Watcher.EnableRaisingEvents = true;
				manager.CreateCheckpoint();
				Console.WriteLine(helpEscape);
				while (Console.ReadKey().Key != escape) ;
			}
			else if (args[0] == "n")
			{
				const string datetimeFormate = "dd.MM.yyyy HH:mm";
				const string helpInput = "Enter the datetime in the format: " + datetimeFormate;
				const string notice = "Close all files and current work directory(subdirectories)";

				string warning = $"All unsaved data will be lost. Press <{enter.ToString()}> to continue";

				string input;
				DateTime dateTime = default;

				Console.WriteLine(helpEscape + " or any key to continue");

				while (Console.ReadKey().Key != escape)
				{
					Console.Clear();
					Console.WriteLine(notice);
					Console.WriteLine(warning);
					if (Console.ReadKey().Key == enter)
					{
						Console.Clear();
						Console.WriteLine(helpInput);
						input = Console.ReadLine();
						try
						{
							dateTime = DateTime.ParseExact(input, datetimeFormate, CultureInfo.InvariantCulture);
							manager.RestoreDirectory(dateTime);
							Console.WriteLine(helpEscape + " or any key to repeat");
						}
						catch (FormatException)
						{
							Console.WriteLine("Incorrect input. Press any key to continue");
							Console.WriteLine(helpEscape + " or any key to repeat");
							continue;
						}
						catch (UnauthorizedAccessException e)
						{
							Console.WriteLine(e.Message);
							Console.WriteLine(helpEscape + " or any key to repeat");
							continue;
						}
						Console.WriteLine("Directory restored at time " + dateTime.ToString());
					}
				}
			}
		}
	}
}
