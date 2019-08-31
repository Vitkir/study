using System;

namespace User
{
	class Employee : User
	{
		private int workExperiens;
		private DateTime beginningWork;

		public string Position { get; set; }

		public DateTime BeginningWork
		{
			get => beginningWork;
			set
			{
				if (BeginningWork.Year > Birthday.Year + 18 && BeginningWork.Month > Birthday.Month ||
					(BeginningWork.Month == Birthday.Month && BeginningWork.Day >= Birthday.Day))
				{
					beginningWork = value;
				}
				else
				{
					throw new ArgumentException("Uncorrected date beginning work");
				}
			}
		}

		public int WorkExperiens
		{
			get
			{
				DateTime dateNow = DateTime.Now;
				workExperiens = dateNow.Year - BeginningWork.Year;
				if (dateNow.Month < BeginningWork.Month ||
					(dateNow.Month == BeginningWork.Month && dateNow.Day < BeginningWork.Day))
				{
					workExperiens--;
				}
				return workExperiens;
			}
		}

		public Employee(string position, DateTime beginningWork,
						string name,
						string surname,
						string patronymic, DateTime date) :
						base(name, surname, patronymic, date)
		{
			Position = position;
			BeginningWork = beginningWork;
		}

		public override string ToString()
		{
			return string.Format("Employee:" +
								 "SurName: {1}{0}" +
								 "Name: {2}{0}" +
								 "Patronymic: {3}{0}" +
								 "Birthday: {4}{0}" +
								 "Age: {5}" +
								 "Position{6}{0}" +
								 "Work experiens{7}{0}",
								  Environment.NewLine, Surname.ToString(), Name.ToString(), Patronymic.ToString(),
								  Birthday.ToString("dd.MM.yyyy"), Age.ToString());
		}
	}
}
