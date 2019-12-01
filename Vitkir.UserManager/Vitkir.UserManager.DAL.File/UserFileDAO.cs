using System;
using Vitkir.UserManager.Common.Entities;
using System.Configuration;

namespace Vitkir.UserManager.DAL.File
{
	public class UserFileDAO : AbstractFileDAO<User>
	{
		public UserFileDAO() : base(ConfigurationManager.AppSettings["usersDataFilePath"],
			ConfigurationManager.AppSettings["userstmpFilePath"],
			"Cannot write data. User data file is read only",
			"User data file missing")
		{

		}

		protected override User ParseString(string entityItem)
		{
			var entityFields = entityItem.Split(':');
			return new User(entityFields[1], DateTime.Parse(entityFields[2]))
			{
				Id = int.Parse(entityFields[0])
			};
		}
	}
}
