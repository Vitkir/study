using System;
using System.Collections.Generic;

namespace Vitkir.UserManager.PL.WebApp.Models
{
	public class UserModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public DateTime Birthday { get; set; }

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

		public UserModel()
		{
			Name = default;
			Birthday = default;
			RelatedAwards = new List<int>(0);
		}
	}
}