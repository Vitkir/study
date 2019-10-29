using System;

namespace Block4Task9
{
	public abstract class LogItem
	{
		public DateTime LogTime { get; set; }

		public LogItem()
		{
			LogTime = DateTime.Now;
		}
	}
}
