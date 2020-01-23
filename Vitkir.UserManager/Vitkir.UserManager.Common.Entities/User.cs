﻿using System;
using System.Collections.Generic;

namespace Vitkir.UserManager.Common.Entities
{
	public class User : AbstractEntity, IEquatable<User>, ICloneable
	{
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

		public List<int> RelatedAwards { get; set; }

		public User(string name, DateTime birthday)
		{
			Name = name;
			Birthday = birthday;
			RelatedAwards = new List<int>(0);
		}

		public override string ToString()
		{
			return string.Format("{0}:{1}:{2}",
				Id.ToString(), Name.ToString(), Birthday.ToString("dd.MM.yyyy"));
		}

		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			if (!(obj is User)) return false;
			return true;
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

		public object Clone()
		{
			return new User(Name, Birthday)
			{
				Id = Id,
				RelatedAwards = RelatedAwards
			};
		}
	}
}
