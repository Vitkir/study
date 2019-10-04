using System.Text.RegularExpressions;

namespace Block_4_Regex
{
	static class StringSearch
	{
		static Regex validDate = new Regex("(0[1-9]|[1-2][0-9]|3[0,1])-(0[1-9]|1[1,2])-(000[1-9]|[0-9])");
		static Regex htmlTag = new Regex(@"<[^>]+>");
		static Regex email = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

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
			MatchCollection emails = Regex.(text, email.ToString());
			return emails;
		}
	}
}
