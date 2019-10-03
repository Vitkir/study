using System;
using System.Linq;

namespace AverageWordLength
{
	class WordLengthCounter
	{
		public static double GetAverageWordLength(string text)
		{
			char[] letter = text.ToCharArray();
			string formatString = "";

			for (int i = 0; i < letter.Length; i++)
			{
				if (char.IsLetter(letter[i]) || char.IsSeparator(' '))
				{
					formatString = string.Concat(formatString, letter[i]);
				}
			}

			string[] words = formatString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			int averageWordLength = (int)words.Average(word => word.Length);
			return averageWordLength;
		}
	}
}
