using System;
using System.Text;

namespace Block4Task9
{
	public class LogItem
	{
		public DateTime LogTime { get; set; }

		public string Source { get; set; }

		public string Backup { get; set; }

		public LogItem(DateTime logTime, string source, string backup)
		{
			LogTime = logTime;
			Source = source;
			Backup = backup;
		}

		public override string ToString()
		{
			return $"Log time: {LogTime.ToString()}{Environment.NewLine}" +
				$"Source: {Source}{Environment.NewLine}" +
				$"Backup: {Backup}{Environment.NewLine}";
		}
	}
}
