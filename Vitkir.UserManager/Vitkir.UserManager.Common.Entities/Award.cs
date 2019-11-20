using System;

namespace Vitkir.UserManager.Common.Entities
{
	public class Award
	{
		public int Id { get; private set; }

		public string Title { get; private set; }

		public Award(int id, string title)
		{
			Id = id;
			Title = title;
		}

		public override string ToString()
		{
			return string.Format("ID: {1}{0}" +
								"Title: {2}{0}",
								Environment.NewLine,
								Id.ToString(),
								Title);
		}
	}
}
