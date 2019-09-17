using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCounter
{
	class Counter
	{
		private Regex regex;
		private Dictionary<string, int> words;

		public string String { get; set; }

		public Counter()
		{
			regex = new Regex(@"\W");
		}

		public Dictionary<string, int> ProcessString()
		{
			string[] words = String.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (var word in words)
			{
				if (this.words.ContainsKey(word))
				{
					this.words[word]++;
				}
				else
				{
					this.words.Add(word, 1);
				}
			}
			return this.words;
		}

		private void ConvertStringToLowercase() => String.ToLower();

		private void RemoveSeparators()
		{
			String = regex.Replace(String, " ");
		}
	}
}
