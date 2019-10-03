using System;
using System.Linq;
using System.Text;

namespace Block_4_Task_1_and_2
{
	class WorkWithString
	{
		public static double GetAverageWordLength(string text)
		{
			var validLetter = text.ToCharArray().Where(letter => char.IsLetter(letter) || char.IsSeparator(letter)).ToArray();
			string validString = new string(validLetter);

			string[] words = validString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			int averageWordLength = (int)words.Average(word => word.Length);
			return averageWordLength;
		}

		public static StringBuilder DoublingLetter(string t1, string t2)
		{
			char[] text = t1.ToCharArray();
			char[] pattern = t2.ToCharArray();
			StringBuilder result = new StringBuilder();
			for (int i = 0; i < text.Length; i++)
			{
				if (pattern.Contains(text[i]))
					result.Append(text[i], 2);
				else result.Append(text[i]);
			}
			return result;
		}
	}
}
