using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter
{
	class Counter
	{
		public string String { get; set; }

		public int Count { get; private set; }

		//public string[] Words => String.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

		private void ConvertStringToLowercase() => String.ToLower();

		private void RemoveCommas() => String.Replace(',', ' ');

		public void CountWords()
		{
			Count = String.Split(new string[] { String }, StringSplitOptions.None).Count() - 1;
		}
	}
}
