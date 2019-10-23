using System;
using System.IO;

namespace Block4Task9
{
	class DirectoryWatcher
	{
		public FileSystemWatcher Watcher { get; private set; }

		private static readonly string pathRootWorkDirectory = @"C:\Users\User\Desktop\Learning\xt_2016\Task_4.9\WorkFolder";
		private static readonly string pathRootBackupDirectory = @"C:\Users\User\Desktop\Learning\xt_2016\Task_4.9\Backup";

		DirectoryInfo rootWorkDirectory;
		DirectoryInfo rootBackupDirectory;
		DirectoryInfo currentBackupDirectory;

		FileInfo currentLog;

		public void RestoreFile(DateTime recoveryTime)
		{

		}

		public DirectoryWatcher()
		{
			rootWorkDirectory = new DirectoryInfo(pathRootWorkDirectory);
			rootBackupDirectory = new DirectoryInfo(pathRootBackupDirectory);

			Watcher = new FileSystemWatcher(pathRootWorkDirectory);
			Watcher.IncludeSubdirectories = true;
			Watcher.NotifyFilter = NotifyFilters.CreationTime
											| NotifyFilters.LastWrite
											| NotifyFilters.FileName
											| NotifyFilters.DirectoryName;

			Watcher.Created += OnCreated;
			Watcher.Deleted += OnDeleted;
			Watcher.Changed += OnChanged;
			Watcher.Renamed += OnRenamed;

			CreateCheckpoint();
		}

		private void CreateCheckpoint()
		{
			currentBackupDirectory = new DirectoryInfo(Path.Combine(pathRootBackupDirectory, rootBackupDirectory.GetDirectories().Length.ToString()));
			currentBackupDirectory.Create();
			currentLog = new FileInfo(Path.Combine(currentBackupDirectory.FullName, "Log.txt"));
			using (currentLog.Create())
				CopyDirectory(rootWorkDirectory.FullName, Path.Combine(currentBackupDirectory.FullName, rootWorkDirectory.Name));
			CreateLogEntry(new LogItem(rootWorkDirectory.FullName, currentBackupDirectory.FullName));
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

			if (!Directory.Exists(destinationDirectory))
			{
				Directory.CreateDirectory(destinationDirectory);
			}

			foreach (FileInfo file in currentDirectory.GetFiles())
			{
				file.CopyTo(Path.Combine(destinationDirectory, file.Name), false);
			}

			foreach (DirectoryInfo subDirectories in currentDirectory.GetDirectories())
			{
				CopyDirectory(subDirectories.FullName, Path.Combine(destinationDirectory, subDirectories.Name));
			}
		}

		private void CopyFile(FileSystemEventArgs e)
		{
			string backupPath = string.Concat(Path.Combine(currentBackupDirectory.FullName, currentBackupDirectory.GetFiles().Length.ToString()), ".txt");

			File.Copy(e.FullPath, backupPath);
			CreateLogEntry(new LogItem(e.FullPath, backupPath));
		}

		private void CreateBackup(FileSystemEventArgs e)
		{
			//todo extract path
			if (File.GetAttributes(e.FullPath).HasFlag(FileAttributes.Directory))
			{
				string backupPath = Path.Combine(currentBackupDirectory.FullName, currentBackupDirectory.GetDirectories().Length.ToString());
				CopyDirectory(e.FullPath, backupPath);
				CreateLogEntry(new LogItem(e.FullPath, backupPath));
			}
			else
			{
				CopyFile(e);
			}
		}

		private void CreateLogEntry(LogItem log)
		{
			using (StreamWriter newEntry = File.AppendText(currentLog.FullName))
			{
				newEntry.Write(log.ToString());
			}
		}

		private void OnCreated(object sender, FileSystemEventArgs e)
		{
			CreateBackup(e);
		}

		private void OnDeleted(object sender, FileSystemEventArgs e)
		{
		}

		private void OnChanged(object sender, FileSystemEventArgs e)
		{
			try
			{
				Watcher.EnableRaisingEvents = false;
				CreateBackup(e);
			}
			finally
			{
				Watcher.EnableRaisingEvents = true;
			}
		}

		private void OnRenamed(object sender, RenamedEventArgs e)
		{
			CreateBackup(e);
		}
	}
}
