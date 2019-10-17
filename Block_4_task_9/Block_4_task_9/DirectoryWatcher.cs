﻿using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Block4Task9
{
	internal class DirectoryWatcher
	{
		private static readonly string dateTimeFormate = "dd-MM-yyyy HH-mm-ss";
		private static readonly string pathRootWorkDirectory = @"C:\Users\User\Desktop\Learning\xt_2016\Task_4.9\WorkFolder";
		private static readonly string pathRootBackupDirectory = @"C:\Users\User\Desktop\Learning\xt_2016\Task_4.9\Backup";
		private static readonly string logPath = @"C:\Users\User\Desktop\Learning\xt_2016\Task_4.9\log.txt";
		private static readonly string DateTimeNow = DateTime.Now.ToString(dateTimeFormate);

		public FileSystemWatcher Watcher { get; private set; }

		private readonly Func<string, string> LastWriteTime = filePath => File.GetLastWriteTime(filePath).ToString();
		private readonly Func<FileSystemEventArgs, string> fileDirectoryPath = e => e.Name.Replace(".txt", "");

		public void RestoreFile(DateTime recoveryTime, string directoryName)
		{
			string pathBackupDirectory = Path.Combine(pathRootBackupDirectory, directoryName);
			if (Directory.Exists(pathBackupDirectory))
			{
				DirectoryInfo directory = new DirectoryInfo(pathBackupDirectory);
				FileInfo[] files = directory.GetFiles();
				Array.Sort(files, delegate (FileInfo f1, FileInfo f2)
				 {
					 return f2.CreationTime.CompareTo(f1.CreationTime);
				 });
				foreach (var file in files)
				{
					if (file.CreationTime <= recoveryTime)
					{
						file.CopyTo(Path.Combine(pathRootWorkDirectory, string.Concat(directoryName, ".txt")), true);
						CreateLog($"File {file.Name} recovered. Last changed {File.GetLastWriteTime(file.FullName)}");
						CreateLog("file restored");
					}
				}
			}
			else CreateLog("No backups");
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
		}

		private void OnCreated(object sender, FileSystemEventArgs e)
		{
			CreateLog(File.GetCreationTime(e.FullPath) + " File created at " + e.FullPath);
			SaveBackup(e);
		}

		private void OnDeleted(object sender, FileSystemEventArgs e)
		{
			CreateLog(string.Format("{0} : File deleted at {1}", DateTimeNow, e.FullPath));
		}

		private void OnChanged(object sender, FileSystemEventArgs e)
		{
			FileInfo originalFile = new FileInfo(e.FullPath);
			DirectoryInfo backupDirectory = new DirectoryInfo(Path.Combine(pathRootBackupDirectory, fileDirectoryPath(e)));
			FileInfo[] backups = backupDirectory.GetFiles();

			var files = from file in backups
						where file.LastWriteTime == originalFile.LastWriteTime
						select file;

			if (files.Count() == 0)
			{
				CreateLog(LastWriteTime(e.FullPath) + " File changed at " + e.FullPath);
				SaveBackup(e);
			}
		}

		private void OnRenamed(object sender, RenamedEventArgs e)
		{
			CreateLog(LastWriteTime(e.FullPath) + $" File at {e.OldFullPath} renamed to {e.Name}");
			SaveBackup(e);
		}

		private void SaveBackup(FileSystemEventArgs e)
		{
			FileInfo originalFile = new FileInfo(e.FullPath);
			DirectoryInfo backupDirectory = new DirectoryInfo(Path.Combine(pathRootBackupDirectory, fileDirectoryPath(e)));
			if (!backupDirectory.Exists)
			{
				backupDirectory.Create();
			}
			int count = backupDirectory.GetFiles().Length;
			string fileName = $"({count.ToString()}){originalFile.Name}";
			originalFile.CopyTo(Path.Combine(backupDirectory.FullName, fileName));
			CreateLog("Backup saved");
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
