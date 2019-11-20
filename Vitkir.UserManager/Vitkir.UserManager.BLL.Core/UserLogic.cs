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

		public int AddUser(User user)
		{
			return userDAO.AddUser(user) != 0 ? user.Id : 0;
		}

		public bool DeleteUser(int id)
		{
			users.Remove(new User() { Id = id });
			return userDAO.DeleteUser(id) != 0 ? true : false;
		}

		public User GetUser(int id)
		{
			return users.Find(user => user.Id == id);
		}

		public User[] GetUsers()
		{
			return users.ToArray();
		}

		public UserLogic()
		{
			userDAO = new UserDAO();
			users = new List<User>();
		}
	}
}
