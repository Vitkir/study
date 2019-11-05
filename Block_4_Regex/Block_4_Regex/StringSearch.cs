using System.Text.RegularExpressions;

namespace Block_4_Regex
{
	static class StringSearch
	{
		static readonly Regex validDate = new Regex("(?:0[1-9]|[1-2][0-9]|3[0,1])-(?:0[1-9]|1[1,2])-((?!0000)[0-9]{4})");
		static readonly Regex htmlTag = new Regex(@"<[^>]+>");
		static readonly Regex email = new Regex(@"[\w|0-9][\w0-9\.\-_]*@[\w0-9\-_]{2,6}.[a-z]{2,3}");
		static readonly Regex number = new Regex(@"^([+-]?[0-9]+(\.[0-9]+)?)$|^([+-]?[0-9](\.[0-9]{1,2})e([+-]?[0-9]+))$");
		static readonly Regex time = new Regex(@"(([0-1][0-9])|(2[0-4])):[0-5][0-9]");

		public static bool IsValidDate(string date)
		{
			return validDate.IsMatch(date);
		}

		public static string DeleteHTMLTags(string text)
		{
			return Regex.Replace(text, htmlTag.ToString(), "_").ToString();
		}

		public static MatchCollection GetEmail(string text)
		{
			MatchCollection emails = Regex.Matches(text, email.ToString());
			return emails;
		}

		public static bool IsNumber(string text)
		{
			return Regex.IsMatch(text, number.ToString());
		}

		public static MatchCollection GetTime(string text)
		{
			MatchCollection times = Regex.Matches(text, time.ToString());
			return times;
		}
	}
}
