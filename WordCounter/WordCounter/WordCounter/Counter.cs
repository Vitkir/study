using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCounter
{
	public class Counter
	{
		private Regex regex;

		public Dictionary<string, int> Words { get; private set; }

		public string Text { get; set; }

		public Counter()
		{
			regex = new Regex(@"[^a-z\s\.]");
			Words = new Dictionary<string, int>();
		}

		public Dictionary<string, int> ProcessString()
		{
			ConvertStringToLowercase();
			RemoveSeparators();
			string[] arrayWords = Text.Split(new[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (var word in arrayWords)
			{
				if (Words.ContainsKey(word))
				{
					Words[word]++;
				}
				else
				{
					Words.Add(word, 1);
				}
			}
			return Words;
		}

		private void ConvertStringToLowercase()
		{
			Text = Text.ToLower();
		}

		private void RemoveSeparators()
		{
			Text = regex.Replace(Text, "");
		}
	}
}
