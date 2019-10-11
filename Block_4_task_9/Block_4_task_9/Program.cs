using System;
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
			}
			Console.WriteLine("Press <Escape> to exit.");
			while (Console.ReadKey().Key != ConsoleKey.Escape) ;
		}
	}
}
