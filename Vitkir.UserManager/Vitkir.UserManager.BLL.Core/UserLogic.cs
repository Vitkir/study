using System;
using System.Collections.Generic;
using System.IO;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.File;

namespace Vitkir.UserManager.BLL.Logic
{
	public class UserLogic
	{
		private readonly UserDAO userDAO;
		private readonly Dictionary<int, User> usersCache;
		private readonly Dictionary<int, User> deletedUsersCache;

		public User CreateUser(User user)
		{
			User createdUser;
			try
			{
				createdUser = userDAO.CreateUser(user);
			}
			catch (IOException e)
			{
				throw new IOException(e.Message, e);
			}
			usersCache.Add(createdUser.Id, createdUser);
			return createdUser;
		}

		public bool UpdateUserDAO()
		{
			var users = GetUsers();
			try
			{
				userDAO.UpdateFile(users);
			}
			catch (IOException e)
			{
				throw new IOException(e.Message);
			}
			return true;
		}

		public int DeleteUserFromCache(int id)
		{
			if (usersCache.ContainsKey(id))
			{
				deletedUsersCache[id] = usersCache[id];
				usersCache.Remove(id);
				return id;
			}
			return 0;
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
