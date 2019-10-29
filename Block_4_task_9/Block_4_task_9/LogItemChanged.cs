using System;

namespace Block4Task9
{
	public class LogItemChanged : LogItem
	{
		public string SourcePath { get; set; }

		public string BackupPath { get; set; }

		public LogItemChanged(string sourcePath, string backupPath)
		{
			SourcePath = sourcePath;
			BackupPath = backupPath;
		}

		public override string ToString()
		{
			return $"{nameof(LogItemChanged)}{Environment.NewLine}" +
				$"Log time: {LogTime.ToString()}{Environment.NewLine}" +
				$"Source path: {SourcePath}{Environment.NewLine}" +
				$"Backup path: {BackupPath}{Environment.NewLine}";
		}
	}
}
