using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Block4Task9
{
	class DirectoryWatcher
	{
		public FileSystemWatcher Watcher { get; private set; }

		private const string filesExtension = ".txt";
		private const string logName = "Log.txt";

		private static readonly string pathRootWorkDirectory = @"C:\Users\User\Desktop\Learning\xt_2016\Task_4.9\WorkFolder";
		private static readonly string pathRootBackupDirectory = @"C:\Users\User\Desktop\Learning\xt_2016\Task_4.9\Backup";

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

		public void RestoreDirectory(DateTime recoveryTime)
		{
			//todo try catch
			rootWorkDirectory.Delete(true);
			DirectoryInfo[] directories = rootBackupDirectory.GetDirectories();

			var checkpoints = from directory in directories
							  where directory.CreationTime <= recoveryTime
							  orderby directory.CreationTime
							  select directory.FullName;
			string lastCheckpointPath = checkpoints.Last();

			var logEntries = ReadLog(currentLogFile.FullName, recoveryTime);

			foreach (var entry in logEntries)
			{
				LogEntriesType logEntryType;
				Enum.TryParse(entry.GetType().ToString(), out logEntryType);
				switch (logEntryType)
				{
					case LogEntriesType.LogItemChanged:
						//todo name
						var obj = (LogItemChanged)entry;
						break;
					case LogEntriesType.LogItemDeleted:
						break;
					case LogEntriesType.LogItemRenamed:
						break;
					default:
						break;
				}
			}
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
			currentLogFile = new FileInfo(Path.Combine(currentBackupDirectory.FullName, logName));
			currentLogFile.Create().Close();
			CopyDirectory(rootWorkDirectory.FullName, Path.Combine(currentBackupDirectory.FullName, rootWorkDirectory.Name));
			WriteLogEntry(new LogItemChanged(rootWorkDirectory.FullName, currentBackupDirectory.FullName));
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

		private void Copy(string path)
		{
			if (File.GetAttributes(path).HasFlag(FileAttributes.Directory))
			{
				string destDirectoryPath = Path.Combine(currentBackupDirectory.FullName, currentBackupDirectory.GetDirectories().Length.ToString());

				CopyDirectory(path, destDirectoryPath);
				WriteLogEntry(new LogItemChanged(path, destDirectoryPath));
			}
			else
			{
				string destFilePath = Path.Combine(currentBackupDirectory.FullName, currentBackupDirectory.GetFiles().Length.ToString() + filesExtension);

				File.Copy(path, destFilePath);
				WriteLogEntry(new LogItemChanged(path, destFilePath));
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
					DateTime dateTime = DateTime.Parse(line);
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

		private void OnCreated(object sender, FileSystemEventArgs e)
		{
			try
			{
				Watcher.EnableRaisingEvents = false;
				Copy(e.FullPath);
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
				Copy(e.FullPath);
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
