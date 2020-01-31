using System;
using System.Collections.Generic;

namespace Vitkir.UserManager.Common.Entities
{
	public class User : IEntity<int>, IEquatable<User>, ICloneable
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

		public object Clone()
		{
			return new User(Name, Birthday)
			{
				RelatedAwards = RelatedAwards
			};
		}

		public override bool Equals(object obj)
		{
			return obj is User other &&
				(Name, Birthday) == (other.Name, other.Birthday);
		}

		public bool Equals(User other)
		{
			return other != null &&
				(Name, Birthday) == (other.Name, other.Birthday);
		}

		public override int GetHashCode()
		{
			var hashCode = -512614078;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
			hashCode = hashCode * -1521134295 + Birthday.GetHashCode();
			return hashCode;
		}

		public static bool operator ==(User left, User right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(User left, User right)
		{
			return !(left == right);
		}
	}
}
