using System;

namespace Block4Task9
{
	class LogItemRenamed : LogItem
	{
		public string OldPath { get; set; }

		public string NewPath { get; set; }

		public LogItemRenamed(string oldPath, string newPath)
		{
			OldPath = oldPath;
			NewPath = newPath;
		}

		public override string ToString()
		{
			return $"{nameof(LogItemRenamed)}{Environment.NewLine}" +
				$"Log time: {LogTime.ToString()}{Environment.NewLine}" +
				$"Old path: {OldPath}{Environment.NewLine}" +
				$"New path: {NewPath}{Environment.NewLine}";
		}
	}
}
