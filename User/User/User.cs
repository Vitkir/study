using System;

namespace User
{
	class User
	{
		private DateTime birthday;
		private int age;

		public string Name { get; set; }

		public string Patronymic { get; set; }

		public string Surname { get; set; }

		public int Age
		{
			get
			{
				DateTime dateNow = DateTime.Now;
				age = dateNow.Year - Birthday.Year;
				if (dateNow.Month < Birthday.Month ||
					(dateNow.Month == Birthday.Month && dateNow.Day < Birthday.Day))
				{
					age--;
				}
				return age;
			}
		}

		public DateTime Birthday
		{
			get => birthday;
			set
			{
				if (DateTime.Today > value)
				{
					birthday = value;
				}
				else
				{
					throw new ArgumentException("Incorrect date entered");
				}
			}
		}

		public User(string name,
					string surname,
					string patronymic,
					DateTime date)
		{
			Name = name;
			Surname = surname;
			Patronymic = patronymic;
			Birthday = date;
		}

		public override string ToString()
		{
			return string.Format("SurName: {1}{0}" +
								 "Name: {2}{0}" +
								 "Patronymic: {3}{0}" +
								 "Birthday: {4}{0}" +
								 "Age: {5}",
								  Environment.NewLine, Surname.ToString(), Name.ToString(), Patronymic.ToString(),
								  Birthday.ToString("dd.MM.yyyy"), Age.ToString());
		}
	}
}
