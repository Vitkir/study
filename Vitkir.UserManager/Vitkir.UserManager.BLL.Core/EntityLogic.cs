using System;
using System.Collections.Generic;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;

namespace Vitkir.UserManager.BLL.Logic
{
	public abstract class EntityLogic<T> where T : Entity, ICloneable
	{
		private readonly IDAO<T> entityDAO;
		private readonly Dictionary<int, T> entityCache;

		public T CreateEntity(T user)
		{
			T createdUser;
			createdUser = entityDAO.CreateEntity(user);
			entityCache.Add(createdUser.Id, createdUser);
			return createdUser;
		}

		public void UpdateEntityDAO()
		{
			var users = GetEntities();
			entityDAO.UpdateFile(users);
		}

		public int DeleteEntityFromCache(int id)
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

		public Dictionary<int, T> GetEntities()
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

		public EntityLogic(IDAO<T> entityDAO)
		{
			this.entityDAO = entityDAO;
			entityCache = entityDAO.GetEntities();
		}
	}
}
