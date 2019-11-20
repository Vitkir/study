using System;

namespace Vitkir.UserManager.Common.Entities
{
	public class User
	{
		public int Id { get; set; }

		public string Name { get; }

		public DateTime Birthday { get; }

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
		}

		public override string ToString()
		{
			return string.Format("ID: {0} : Name: {1} : Birthday: {2} : Age: {3}",
				Id.ToString(), Name.ToString(), Birthday.ToString("dd.MM.yyyy"), Age.ToString());
		}
	}
}
