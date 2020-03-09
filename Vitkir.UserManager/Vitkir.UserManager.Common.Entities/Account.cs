using System;
using System.Collections.Generic;

namespace Vitkir.UserManager.Common.Entities
{
	public class Account : IEntity<int>, IEquatable<Account>, ICloneable
	{
		public int Id { get; set; }

		public string Login { get; set; }

		public string Password { get; set; }

		public Role Role { get; set; }

		public Account(string login, string password)
		{
			Login = login;
			Password = password;
		}

		public override string ToString()
		{
			return string.Format("{0}:{1}:{2}:{3}", Id.ToString(), Login, Password, ((int)Role).ToString());
		}

		public object Clone()
		{
			return new Account(Login, Password)
			{
				Id = Id,
				Role = Role,
			};
		}

		public override bool Equals(object obj)
		{
			return obj is Account other &&
				(Login, Password) == (other.Login, other.Password);
		}

		public bool Equals(Account other)
		{
			return other != null &&
				(Login, Password) == (other.Login, other.Password);
		}

		public override int GetHashCode()
		{
			var hashCode = 2079674330;
			hashCode = hashCode * -1521134295 + Id.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Login);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
			return hashCode;
		}
	}
}
