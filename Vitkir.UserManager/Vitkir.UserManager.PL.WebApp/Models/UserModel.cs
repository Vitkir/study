using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vitkir.UserManager.PL.WebApp.Models
{
	public class UserModel
	{
		public int id { get; set; }

		public string Name { get; }

		public DateTime Birthday { get; }

		public int Age { get; }

		public List<int> RelationsAwards { get; set; }

		public UserModel(string name, DateTime birthday)
		{

		}

	}
}