using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    class User
    {
        private DateTime birthday;

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public string SurName { get; set; }

        public int Age
        {
            get
            {
                return DateTime.Today.Year - Birthday.Year;
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

        public User(string name, string surname, string patr, DateTime date)
        {
            Name = name;
            SurName = surname;
            Patronymic = patr;
            Birthday = date;
        }
        public override string ToString()
        {
            return string.Format($"{SurName} {Name} {Patronymic}" +
                                  "{0}{1}" +
                                  "{0}{2}",
                                  Environment.NewLine, Birthday.ToString("dd.MM.yyyy"), Age.ToString());
        }
    }
}
