using System;
using System.IO;

namespace Block4Task9
{
	class Watcher
	{
		private readonly string workFolderPath = @"C:\Users\User\Desktop\Learning\xt_2016\Task_4.9\WorkFolder";
		private readonly string backupFolderPath = @"C:\Users\User\Desktop\Learning\xt_2016\Task_4.9\Backup";
		private readonly string logPath = @"C:\Users\User\Desktop\Learning\xt_2016\Task_4.9\log.txt";
		private readonly string DateTimeNow = DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss");

		Func<string, string> lastWriteTime = delegate (string filePath)
		{
			return File.GetLastWriteTime(filePath).ToString();
		};

		public bool EnableObservation { get; set; }

		public void WatchDirectory()
		{
			using (FileSystemWatcher watcher = new FileSystemWatcher(workFolderPath, "*.txt"))
			{
				watcher.NotifyFilter = NotifyFilters.CreationTime
										| NotifyFilters.LastWrite
										| NotifyFilters.FileName
										| NotifyFilters.DirectoryName;

				watcher.Created += OnCreated;
				watcher.Deleted += OnDeleted;
				watcher.Changed += OnChanged;
				watcher.Renamed += OnRenamed;

				watcher.EnableRaisingEvents = EnableObservation;
			}
		}

		private void OnCreated(object sender, FileSystemEventArgs e)
		{
			string log = File.GetCreationTime(e.FullPath) + " File created at " + e.FullPath;
			CreateLog(log, e);
		}

		private void OnDeleted(object sender, FileSystemEventArgs e)
		{
			string log = string.Format("{0} : File deleted at {1}", DateTimeNow, e.FullPath);
			CreateLog(log, e);
		}

		private void OnChanged(object sender, FileSystemEventArgs e)
		{
			string log = lastWriteTime(e.FullPath) + " File changed at " + e.FullPath;
			SaveBackup(e);
			CreateLog(log, e);
		}

		private void OnRenamed(object sender, RenamedEventArgs e)
		{
			string log = lastWriteTime(e.FullPath) + $" File at {e.OldFullPath} renamed to {e.Name}";
			CreateLog(log, e);
		}

		private void SaveBackup(FileSystemEventArgs e)
		{
			if (!Directory.Exists(Path.Combine(backupFolderPath, e.Name)))
			{
				Directory.CreateDirectory(Path.Combine(backupFolderPath, e.Name));
			}
			if (!File.Exists(Path.Combine(backupFolderPath, e.Name, string.Concat(DateTimeNow, ".txt"))))
			{
				File.Copy(e.FullPath, Path.Combine(backupFolderPath, e.Name, string.Concat(DateTimeNow, ".txt")));
			}
		}

		private void CreateLog(string log, FileSystemEventArgs e)
		{
			using (StreamWriter sw = File.AppendText(logPath))
			{
				sw.WriteLine(log);
			}
			Console.WriteLine(log);
		}
	}
}
