using System;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.DAL.File
{
	public class UserDAO : AbstractDAO<User>
	{
		public UserDAO() : base(@"C:\Users\T\Desktop\Learning\xt_2016\Task_6\users.txt",
			@"C:\Users\T\Desktop\Learning\xt_2016\Task_6\userstmp.txt",
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
