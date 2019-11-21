﻿using System;

namespace Vitkir.UserManager.Common.Entities
{
	public class User : IEquatable<User>
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

		public User()
		{

		}

		public User(string name, DateTime birthday)
		{
			Name = name;
			Birthday = birthday;
		}

		public override string ToString()
		{
			return string.Format("{0}:{1}:{2}:{3}",
				Id.ToString(), Name.ToString(), Birthday.ToString("dd.MM.yyyy"), Age.ToString());
		}

		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			User objAsUser = obj as User;
			if (objAsUser == null) return false;
			else return Equals(objAsUser);
		}

		public override int GetHashCode()
		{
			return Id;
		}

		public bool Equals(User other)
		{
			if (other == null) return false;
			return Id.Equals(other.Id);
		}
	}
}
