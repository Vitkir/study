using System;
using System.Collections.Generic;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.File;

namespace Vitkir.UserManager.BLL.Logic
{
	public class EntityLogic<T> where T : Entity, ICloneable
	{
		private readonly AbstractDAO<T> entityDAO;
		private readonly Dictionary<int, T> entityCache;

		public T CreateUser(T user)
		{
			T createdUser;
			createdUser = entityDAO.CreateUser(user);
			entityCache.Add(createdUser.Id, createdUser);
			return createdUser;
		}

		public void UpdateUserDAO()
		{
			var users = GetUsers();
			entityDAO.UpdateFile(users);
		}

		public int DeleteUserFromCache(int id)
		{
			if (entityCache.ContainsKey(id))
			{
				entityCache.Remove(id);
				return id;
			}
			return 0;
		}

		public T GetUser(int id)
		{
			if (entityCache.ContainsKey(id))
			{
				return (T)entityCache[id].Clone();
			}
			return null;
		}

		public Dictionary<int, T> GetUsers()
		{
			var len = entityCache.Count;
			T user;
			var users = new Dictionary<int, T>(len);
			foreach (var pair in entityCache)
			{
				user = (T)pair.Value.Clone();
				users.Add(user.Id, user);
			}
			return users;
		}

		public EntityLogic(AbstractDAO<T> entityDAO)
		{
			this.entityDAO = entityDAO;
			entityCache = entityDAO.GetUsers();
		}
	}
}
