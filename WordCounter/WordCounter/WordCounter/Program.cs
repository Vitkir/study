using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter
{
	class Program
	{
		static void Main()
		{
			
		}

		public Counter GetCounter()
		{
			return new Counter()
			{
				Text = Console.ReadLine(),
			};
		}
		public void Print(Counter counter)
		{
			foreach (var item in counter.words)
			{
				Console.WriteLine(item.Key.ToString() + " - " + item.Value.ToString());
			}
		}
	}
}
