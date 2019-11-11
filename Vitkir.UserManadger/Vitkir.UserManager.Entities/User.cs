using System;

namespace Vitkir.UserManager.CommonEntities
{
	public class User
	{
		public int Id { get; set; }

		public string Name { get; private set; }

		public DateTime Birthday { get; private set; }

		public static int Counter { get; private set; }

		public int Age
		{
			get
			{
				DateTime dateNow = DateTime.Now;
				var age = dateNow.Year - Birthday.Year;
				if (dateNow.Month < Birthday.Month ||
					(dateNow.Month == Birthday.Month && dateNow.Day < Birthday.Day))
				{
					age--;
				}
				return age;
			}
		}

		public User(string name, DateTime birthday)
		{
			Name = name;
			Birthday = birthday;
			Counter++;
		}

		public override string ToString()
		{
			return string.Format("ID: {1}{0}" +
								"Name: {2}{0}" +
								"Birthday: {3}{0}" +
								"Age: {4}{0}",
								 Environment.NewLine, Id.ToString(), Name.ToString(),
								 Birthday.ToString("dd.MM.yyyy"), Age.ToString());
		}
	}
}
