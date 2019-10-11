using System;

namespace Block4Task9
{
	class Program
	{
		static void Main(string[] args)
		{
			Watcher manager = new Watcher();
			if (args[0] == "y")
			{
				manager.EnableObservation = true;
			}
			manager.WatchDirectory();
			Console.WriteLine("Press <Escape> to exit.");
			while (Console.ReadKey().Key != ConsoleKey.Escape) ;
		}
	}
}
