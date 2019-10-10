using System;
using System.IO;

namespace WorkWithFile
{
	class FileManager
	{
		readonly string workFolderPath = @"C:\Users\User\Desktop\Learning\xt_2016\Task_4.9\WorkFolder";
		readonly string backupFolderPath = @"C:\Users\User\Desktop\Learning\xt_2016\Task_4.9\Backup";
		readonly string logPath = @"C:\Users\User\Desktop\Learning\xt_2016\Task_4.9\log.txt";

		public bool ObservationMode { get; set; }

		public void WatchDirectory()
		{
			using (FileSystemWatcher watcher = new FileSystemWatcher(workFolderPath, "*.txt"))
			{
				watcher.NotifyFilter = NotifyFilters.CreationTime
										| NotifyFilters.LastWrite
										| NotifyFilters.FileName
										| NotifyFilters.DirectoryName;

				watcher.Created += Watcher_Changed;
				watcher.Deleted += Watcher_Changed;
				watcher.Changed += Watcher_Changed;
				watcher.Renamed += Watcher_Renamed;

				watcher.EnableRaisingEvents = true;
				Console.WriteLine("Press <Escape> to exit.");
				while (Console.ReadKey().Key != ConsoleKey.Escape) ;
			}
		}

		private void Watcher_Changed(object sender, FileSystemEventArgs e)
		{
			using (StreamWriter sw = File.AppendText(logPath))
			{
				sw.WriteLine("{0} : File : {1} was changed{2}", DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss"), e.FullPath, Environment.NewLine);
			}
			Console.WriteLine("{0} : File : {1} was changed", DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss"), e.FullPath);
		}

		private void Watcher_Renamed(object sender, RenamedEventArgs e)
		{
			using (StreamWriter sw = File.AppendText(logPath))
			{
				sw.WriteLine("{0} : File : {1} rename to {2}{3}", DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss"), e.OldFullPath, e.FullPath, Environment.NewLine);
			}
			Console.WriteLine("{0} : File : {1} rename to {2}", DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss"), e.OldFullPath, e.FullPath);
		}
	}
}
