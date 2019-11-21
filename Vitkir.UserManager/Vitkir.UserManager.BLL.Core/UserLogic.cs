using System;
using System.Collections.Generic;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.File;

namespace Vitkir.UserManager.BLL.Logic
{
	public class UserLogic
	{
		private UserDAO userDAO;
		private Dictionary<int, User> usersCache;

		public User CreateUser(User user)
		{
			var createdUser = userDAO.CreateUser(user);
			usersCache.Add(createdUser.Id, createdUser);
			return createdUser;
		}

		public bool DeleteUser(int id)
		{
			usersCache.Remove(id);
			return userDAO.DeleteUser(id);
		}

		public User GetUser(int id)
		{
			return usersCache[id];
		}

		public User[] GetUsers()
		{

			return usersCache.
		}

		public UserLogic()
		{
			userDAO = new UserDAO();
			usersCache = userDAO.GetUsers();

		}
	}
}
