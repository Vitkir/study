using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Block4Task9
{
	class DirectoryWatcher
	{
		public FileSystemWatcher Watcher { get; private set; }

		private readonly string pathRootWorkDirectory;
		private readonly string pathRootBackupDirectory;

		private const string filesExtension = ".txt";
		private const string logName = "Log.txt";

		DirectoryInfo rootWorkDirectory;
		DirectoryInfo rootBackupDirectory;
		DirectoryInfo currentBackupDirectory;

		FileInfo currentLogFile;

		private enum LogEntriesType
		{
			LogItemChanged,
			LogItemDeleted,
			LogItemRenamed
		}

		public DirectoryWatcher(string workDirectory, string backupDirectory)
		{
			pathRootWorkDirectory = workDirectory;
			pathRootBackupDirectory = backupDirectory;
			rootWorkDirectory = new DirectoryInfo(pathRootWorkDirectory);
			rootBackupDirectory = new DirectoryInfo(pathRootBackupDirectory);
			if (!rootWorkDirectory.Exists)
			{
				rootWorkDirectory.Create();
			}
			if (!rootBackupDirectory.Exists)
			{
				rootBackupDirectory.Create();
			}
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
		}

		public void RestoreDirectory(DateTime recoveryTime)
		{
			try
			{
				rootWorkDirectory.Delete(true);
			}
			catch (UnauthorizedAccessException e)
			{
				throw new UnauthorizedAccessException(e.Message, e);
			}
			DirectoryInfo[] directories = rootBackupDirectory.GetDirectories();

			var checkpoints = from directory in directories
							  where directory.CreationTime <= recoveryTime
							  orderby directory.CreationTime
							  select directory.FullName;
			string lastCheckpointPath = checkpoints.Last();

			var logItems = ReadLog(Path.Combine(lastCheckpointPath, logName), recoveryTime);

			foreach (var logItem in logItems)
			{
				switch (logItem)
				{
					case LogItemChanged logItemChanged:
						Copy(logItemChanged.BackupPath, logItemChanged.SourcePath);
						break;
					case LogItemDeleted logItemDeleted:
						File.Delete(logItemDeleted.Path);
						break;
					case LogItemRenamed logItemRenamed:
						if (IsDirectory(logItemRenamed.OldPath))
						{
							Directory.Move(logItemRenamed.OldPath, logItemRenamed.NewPath);
						}
						else
						{
							File.Move(logItemRenamed.OldPath, logItemRenamed.NewPath);
						}
						break;
				}
			}
		}

		public void CreateCheckpoint()
		{
			currentBackupDirectory = new DirectoryInfo(Path.Combine(pathRootBackupDirectory, rootBackupDirectory.GetDirectories().Length.ToString()));
			currentBackupDirectory.Create();
			currentLogFile = new FileInfo(Path.Combine(currentBackupDirectory.FullName, logName));
			currentLogFile.Create().Close();
			CopyDirectory(rootWorkDirectory.FullName, Path.Combine(currentBackupDirectory.FullName, rootWorkDirectory.Name));
			WriteLogEntry(new LogItemChanged(rootWorkDirectory.FullName, Path.Combine(currentBackupDirectory.FullName, rootWorkDirectory.Name)));
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

		private void Copy(string sourcePath, string destPath)
		{
			if (IsDirectory(sourcePath))
			{
				CopyDirectory(sourcePath, destPath);
			}
			else
			{
				File.Copy(sourcePath, destPath, true);
			}
		}

		private void WriteLogEntry(LogItem log)
		{
			using (StreamWriter newEntry = File.AppendText(currentLogFile.FullName))
			{
				newEntry.Write(log.ToString());
			}
		}

		private List<LogItem> ReadLog(string logPath, DateTime recoveryTime)
		{
			List<LogItem> logEntries = new List<LogItem>();
			string line;
			using (StreamReader log = new StreamReader(logPath))
			{
				while ((line = log.ReadLine()) != null)
				{
					LogEntriesType logEntryType;
					Enum.TryParse(line, out logEntryType);
					DateTime dateTime = DateTime.ParseExact(log.ReadLine().Replace("Log time: ", ""), "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
					if (dateTime > recoveryTime)
					{
						return logEntries;
					}
					switch (logEntryType)
					{
						case LogEntriesType.LogItemChanged:
							logEntries.Add(new LogItemChanged(log.ReadLine().Replace("Source path: ", ""),
						log.ReadLine().Replace("Backup path: ", "")));
							break;
						case LogEntriesType.LogItemDeleted:
							logEntries.Add(new LogItemDeleted(log.ReadLine().Replace("Path: ", "")));
							break;
						case LogEntriesType.LogItemRenamed:
							logEntries.Add(new LogItemRenamed(log.ReadLine().Replace("Old path: ", ""),
								log.ReadLine().Replace("New path: ", "")));
							break;
					}
				}
			}
			return logEntries;
		}

		private string CreateDestPath(FileSystemEventArgs e)
		{
			if (IsDirectory(e.FullPath))
			{
				return Path.Combine(currentBackupDirectory.FullName, currentBackupDirectory.GetDirectories().Length.ToString());
			}
			else
			{
				return Path.Combine(currentBackupDirectory.FullName, currentBackupDirectory.GetFiles().Length.ToString() + filesExtension);
			}
		}

		private static bool IsDirectory(string path)
		{
			return File.GetAttributes(path).HasFlag(FileAttributes.Directory);
		}

		private void OnCreated(object sender, FileSystemEventArgs e)
		{
			try
			{
				Watcher.EnableRaisingEvents = false;
				Copy(e.FullPath, CreateDestPath(e));
				WriteLogEntry(new LogItemChanged(e.FullPath, CreateDestPath(e)));
			}
			finally
			{
				Watcher.EnableRaisingEvents = true;
			}
		}

		private void OnDeleted(object sender, FileSystemEventArgs e)
		{
			WriteLogEntry(new LogItemDeleted(e.FullPath));
		}

		private void OnChanged(object sender, FileSystemEventArgs e)
		{
			try
			{
				Watcher.EnableRaisingEvents = false;
				Copy(e.FullPath, CreateDestPath(e));
				WriteLogEntry(new LogItemChanged(e.FullPath, CreateDestPath(e)));
			}
			finally
			{
				Watcher.EnableRaisingEvents = true;
			}
		}

		private void OnRenamed(object sender, RenamedEventArgs e)
		{
			WriteLogEntry(new LogItemRenamed(e.OldFullPath, e.FullPath));
		}
	}
}
