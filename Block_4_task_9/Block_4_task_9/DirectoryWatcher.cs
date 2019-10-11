using System;
using System.IO;

namespace Block4Task9
{
	class DirectoryWatcher
	{
		public FileSystemWatcher Watcher { get; private set; }

		private readonly string workFolderPath = @"C:\Users\User\Desktop\Learning\xt_2016\Task_4.9\WorkFolder";
		private readonly string backupFolderPath = @"C:\Users\User\Desktop\Learning\xt_2016\Task_4.9\Backup";
		private readonly string logPath = @"C:\Users\User\Desktop\Learning\xt_2016\Task_4.9\log.txt";
		private readonly string DateTimeNow = DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss");

		private readonly Func<string, string> LastWriteTime = filePath => File.GetLastWriteTime(filePath).ToString();
		private readonly Func<FileSystemEventArgs, string> FolderName = e => e.Name.Replace(".txt", "");

		public DirectoryWatcher()
		{
			Watcher = new FileSystemWatcher(workFolderPath, "*.txt");
			Watcher.IncludeSubdirectories = true;
			Watcher.NotifyFilter = NotifyFilters.CreationTime
											| NotifyFilters.LastWrite
											| NotifyFilters.FileName
											| NotifyFilters.DirectoryName;

			Watcher.Created += OnCreated;
			Watcher.Deleted += OnDeleted;
			Watcher.Changed += OnChanged;
			Watcher.Renamed += OnRenamed;
		}

		private void OnCreated(object sender, FileSystemEventArgs e)
		{
			string log = File.GetCreationTime(e.FullPath) + " File created at " + e.FullPath;
			CreateLog(log);
		}

		private void OnDeleted(object sender, FileSystemEventArgs e)
		{
			string log = string.Format("{0} : File deleted at {1}", DateTimeNow, e.FullPath);
			CreateLog(log);
		}

		private void OnChanged(object sender, FileSystemEventArgs e)
		{
			string log = LastWriteTime(e.FullPath) + " File changed at " + e.FullPath;
			SaveBackup(e);
			CreateLog(log);
		}

		private void OnRenamed(object sender, RenamedEventArgs e)
		{
			string log = LastWriteTime(e.FullPath) + $" File at {e.OldFullPath} renamed to {e.Name}";
			SaveBackup(e);
			CreateLog(log);
		}

		private void SaveBackup(FileSystemEventArgs e)
		{
			string fileName = string.Concat(FolderName(e),
				string.Format("({0})", Directory.GetFiles(backupFolderPath, FolderName(e)).Length.ToString()), ".txt");
			if (!Directory.Exists(Path.Combine(backupFolderPath, FolderName(e))))
			{
				Directory.CreateDirectory(Path.Combine(backupFolderPath, FolderName(e)));
			}
			if (!File.Exists(Path.Combine(backupFolderPath, FolderName(e), fileName)))
			{
				File.Copy(e.FullPath, Path.Combine(backupFolderPath, FolderName(e), fileName));
			}
		}

		private void CreateLog(string log)
		{
			using (StreamWriter sw = File.AppendText(logPath))
			{
				sw.WriteLine(log);
			}
		}
	}
}
