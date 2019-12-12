using System;
using System.Collections.Generic;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;

namespace Vitkir.UserManager.BLL.Logic
{
	public abstract class EntityLogic<T> : ILogic<T> where T : Entity, ICloneable
	{
		private readonly IDAO<T> entityDAO;
		private readonly Dictionary<int, T> entityCache;

		public EntityLogic(IDAO<T> entityDAO)
		{
			this.entityDAO = entityDAO;
			entityCache = entityDAO.GetEntities();
		}

		public T CreateEntity(T entity)
		{
			T createdEntity;
			createdEntity = entityDAO.CreateEntity(entity);
			entityCache.Add(createdEntity.Id, createdEntity);
			return createdEntity;
		}

		public void UpdateEntityDAO()
		{
			var entities = GetEntities();
			entityDAO.UpdateFile(entities);
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

		public T GetEntity(int id)
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
			T entity;
			var entities = new Dictionary<int, T>(len);
			foreach (var pair in entityCache)
			{
				entity = (T)pair.Value.Clone();
				entities.Add(entity.Id, entity);
			}
			return entities;
		}
	}
}
