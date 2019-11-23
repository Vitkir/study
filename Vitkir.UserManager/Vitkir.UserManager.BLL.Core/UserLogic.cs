using System;
using System.Collections.Generic;
using System.Linq;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.File;

namespace Vitkir.UserManager.BLL.Logic
{
	public class UserLogic
	{
		private UserDAO userDAO;
		private Dictionary<int, User> usersCache;
		private Dictionary<int, User> deletedUsersCache;

		public User CreateUser(User user)
		{
			var createdUser = userDAO.CreateUser(user);
			usersCache.Add(createdUser.Id, createdUser);
			return createdUser;
		}

		public bool UpdateUserDAO()
		{
			var users = GetUsers();
			userDAO.UpdateFile(users);
			return true;
		}

		public bool DeleteUserFromCache(int id)
		{
			if (usersCache.ContainsKey(id))
			{
				deletedUsersCache[id] = usersCache[id];
				usersCache.Remove(id);
				return true;
			}
			return false;
		}

		public User GetUser(int id)
		{
			if (usersCache.ContainsKey(id))
			{
				return (User)usersCache[id].Clone();
			}
			return null;
		}

		public Dictionary<int, User> GetUsers()
		{
			var len = usersCache.Count;
			User user;
			var users = new Dictionary<int, User>(len);
			foreach (var pair in usersCache)
			{
				user = (User)pair.Value.Clone();
				users.Add(user.Id, user);
			}
			return users;
		}

		public UserLogic()
		{
			userDAO = new UserDAO();
			usersCache = userDAO.GetUsers();
			deletedUsersCache = new Dictionary<int, User>();
		}
	}
}
