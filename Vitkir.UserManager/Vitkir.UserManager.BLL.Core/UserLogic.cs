using System;
using System.Collections.Generic;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.File;

namespace Vitkir.UserManager.BLL.Logic
{
	public class UserLogic
	{
		private UserDAO userDAO;
		private List<User> users;

		public bool Add(string name = "jo", DateTime birthday = default)
		{
			User user = new User(name, birthday);
			return userDAO.Add(user) != 0 ? true : false;
		}

		public bool Delete(int id)
		{
			users.Remove()
			return UserCache.Delete(id) != 0 ? true : false;
		}

		public IEnumerable<User> Get(int id)
		{
			return UserCache.Get(id);
		}

		public IEnumerable<User> GetAll()
		{
			return UserCache.GetAll();
		}

		public UserLogic()
		{
			userDAO = new UserDAO();
			users = new List<User>();
		}
	}
}
