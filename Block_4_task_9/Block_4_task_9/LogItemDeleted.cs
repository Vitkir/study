using System;

namespace Block4Task9
{
	class LogItemDeleted : LogItem
	{
		public string Path { get; set; }

		public LogItemDeleted(string path)
		{
			Path = path;
		}

		public override string ToString()
		{
			return $"{nameof(LogItemDeleted)}{Environment.NewLine}" +
				$"Log time: {LogTime.ToString()}{Environment.NewLine}" +
				$"Path: {Path}{Environment.NewLine}";
		}
	}
}
