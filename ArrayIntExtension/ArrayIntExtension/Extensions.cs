using System.Text.RegularExpressions;

namespace ArrayExtension
{
	public static class Extensions
	{
		public static int SumArrayElements(this int[] array)
		{
			int sum = 0;
			foreach (var item in array)
			{
				sum += item;
			}
			return sum;
		}

		public static bool IsPositiveInteger(this string text)
		{
			Regex positiveInteger = new Regex(@"^\+?[0-9]+$");
			return positiveInteger.IsMatch(text);
		}
	}
}
