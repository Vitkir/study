using System;
using System.IO;

namespace Block4Task9
{
	internal class DirectoryWatcher
	{
		private static readonly string dateFormate = "dd-MM-yyyy HH-mm-ss";
		private static readonly string workFolderPath = @"C:\Users\User\Desktop\Learning\xt_2016\Task_4.9\WorkFolder";
		private static readonly string backupFolderPath = @"C:\Users\User\Desktop\Learning\xt_2016\Task_4.9\Backup";
		private static readonly string logPath = @"C:\Users\User\Desktop\Learning\xt_2016\Task_4.9\log.txt";
		private static readonly string DateTimeNow = DateTime.Now.ToString(dateFormate);

		public FileSystemWatcher Watcher { get; private set; }

		private readonly Func<string, string> LastWriteTime = filePath => File.GetLastWriteTime(filePath).ToString();
		private readonly Func<FileSystemEventArgs, string> FolderName = e => e.Name.Replace(".txt", "");

		public string RestoreFile(DateTime dateTime, string directoryName)
		{
			if (DirectoryExist(directoryName))
			{
				string pathToDirectory = Path.Combine(backupFolderPath, directoryName);
				DirectoryInfo directory = new DirectoryInfo(pathToDirectory);
				FileInfo[] files = directory.GetFiles();
				Array.Sort(files, delegate (FileInfo f1, FileInfo f2)
				 {
					 return f2.CreationTime.CompareTo(f1.CreationTime);
				 });
				foreach (var file in files)
				{
					if (file.CreationTime >= dateTime)
					{
					}
					file.CopyTo(Path.Combine(workFolderPath, string.Concat(directoryName, ".txt")), true);
					string log = $"File {file.Name} recovered. Last changed {File.GetLastWriteTime(file.FullName)}";
					CreateLog(log);
				}
				return "file restored";
			}
			else return "No backups";
		}

		public bool DirectoryExist(string fName)
		{
			string path = Path.Combine(workFolderPath, fName, string.Concat(fName, ".txt"));
			return Directory.Exists(path);
		}

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
			int count = Directory.GetFiles(Path.Combine(backupFolderPath, FolderName(e))).Length;
			string fileName = $"{FolderName(e)}({count.ToString()})" + ".txt";
			if (!Directory.Exists(Path.Combine(backupFolderPath, FolderName(e))))
			{
				Directory.CreateDirectory(Path.Combine(backupFolderPath, FolderName(e)));
			}
			File.Copy(e.FullPath, Path.Combine(backupFolderPath, FolderName(e), fileName));
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
