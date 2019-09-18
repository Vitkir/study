using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCounter
{
	class Counter
	{
		private Regex regex;

		public Dictionary<string, int> words { get; private set; }

		public string Text { get; set; }

		public Counter()
		{
			regex = new Regex(@"\W");
			words = new Dictionary<string, int>();
		}

		public Dictionary<string, int> ProcessString()
		{
			ConvertStringToLowercase();
			RemoveSeparators();
			string[] arrayWords = Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (var word in arrayWords)
			{
				if (words.ContainsKey(word))
				{
					words[word]++;
				}
				else
				{
					words.Add(word, 1);
				}
			}
			return words;
		}

		private void ConvertStringToLowercase() => Text.ToLower();

		private void RemoveSeparators()
		{
			Text = regex.Replace(Text, " ");
		}

		//public void Print()
		//{
		//	foreach (var item in words)
		//	{
		//		Console.WriteLine(item.Key.ToString() + " - " + item.Value.ToString());
		//	}
		//}
	}
}
