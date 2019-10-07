using System.Text.RegularExpressions;

namespace Block_4_Regex
{
	static class StringSearch
	{
		static Regex validDate = new Regex("(0[1-9]|[1-2][0-9]|3[0,1])-(0[1-9]|1[1,2])-(000[1-9]|[0-9])");
		static Regex htmlTag = new Regex(@"<[^>]+>");
		static Regex email = new Regex(@"(\s[^\D\W][\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)");
		static Regex number = new Regex(@"^([+-]?[0-9]+(\.[0-9]+)?)$|^([+-]?[0-9]+(\.[0-9]+)e([+-]?[0-9]+))$");

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
	}
}
