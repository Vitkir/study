using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Block4Task9
{
	internal class DirectoryWatcher
	{
		public FileSystemWatcher Watcher { get; private set; }

		//todo datetime
		private static readonly string dateTimeFormate = "dd.MM.yyyy HH:mm:ss";
		private static readonly string pathRootWorkDirectory = @"C:\Users\User\Desktop\Learning\xt_2016\Task_4.9\WorkFolder";
		private static readonly string pathRootBackupDirectory = @"C:\Users\User\Desktop\Learning\xt_2016\Task_4.9\Backup";
		private static readonly string DateTimeNow = DateTime.Now.ToString(dateTimeFormate);

		DirectoryInfo rootWorkDirectory;
		DirectoryInfo rootBackupDirectory;
		DirectoryInfo currentBackupDirectory;

		FileInfo currentLog;

		private Func<string, string> LastWriteTime = filePath => File.GetLastWriteTime(filePath).ToString();
		private Func<FileSystemEventArgs, string> fileDirectoryPath = e => e.Name.Replace(".txt", "");

		public void RestoreFile(DateTime recoveryTime, string relativeFilePath)
		{

		}

		public DirectoryWatcher()
		{
			Watcher = new FileSystemWatcher(pathRootWorkDirectory, "*.txt");
			Watcher.IncludeSubdirectories = true;
			Watcher.NotifyFilter = NotifyFilters.CreationTime
											| NotifyFilters.LastWrite
											| NotifyFilters.FileName
											| NotifyFilters.DirectoryName;

			Watcher.Created += OnCreated;
			Watcher.Deleted += OnDeleted;
			Watcher.Changed += OnChanged;
			Watcher.Renamed += OnRenamed;

			rootWorkDirectory = new DirectoryInfo(pathRootWorkDirectory);
			rootBackupDirectory = new DirectoryInfo(pathRootBackupDirectory);
			CreateCheckpoint();
		}

		private void CreateCheckpoint()
		{
			currentBackupDirectory = new DirectoryInfo(Path.Combine(pathRootBackupDirectory, rootBackupDirectory.GetDirectories().Length.ToString()));
			currentBackupDirectory.Create();
			currentLog = new FileInfo(Path.Combine(currentBackupDirectory.FullName, "Log.txt"));
			using (currentLog.Create())
				CopyDirectory(rootWorkDirectory.FullName, Path.Combine(currentBackupDirectory.FullName, rootWorkDirectory.Name));
			LogItem log = new LogItem(DateTime.Now, rootWorkDirectory.FullName, currentBackupDirectory.FullName);
			CreateFileEntry(log);
		}

		private void CopyDirectory(string sourceDirectory, string destinationDirectory)
		{
			DirectoryInfo currentDirectory = new DirectoryInfo(sourceDirectory);

			if (!currentDirectory.Exists)
			{
				throw new DirectoryNotFoundException(
					"Source directory does not exist or could not be found: "
					+ sourceDirectory);
			}

			DirectoryInfo[] dirs = currentDirectory.GetDirectories();
			if (!Directory.Exists(destinationDirectory))
			{
				Directory.CreateDirectory(destinationDirectory);
			}

			FileInfo[] files = currentDirectory.GetFiles();
			foreach (FileInfo file in files)
			{
				string temppath = Path.Combine(destinationDirectory, file.Name);
				file.CopyTo(temppath, false);
			}

			foreach (DirectoryInfo subdir in dirs)
			{
				string temppath = Path.Combine(destinationDirectory, subdir.Name);
				CopyDirectory(subdir.FullName, temppath);
			}

		}

		private void CreateFileEntry(LogItem log)
		{
			using (StreamWriter sw = new StreamWriter(currentLog.FullName))
			{
				sw.Write(log);
			}
		}

		private void OnCreated(object sender, FileSystemEventArgs e)
		{
			SaveBackup(e);
		}

		private void OnDeleted(object sender, FileSystemEventArgs e)
		{
		}

		private void OnChanged(object sender, FileSystemEventArgs e)
		{
			SaveBackup(e);
		}

		private void OnRenamed(object sender, RenamedEventArgs e)
		{
			SaveBackup(e);
		}

		private void SaveBackup(FileSystemEventArgs e)
		{

		}
	}
}
