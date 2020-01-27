using System;
using System.Collections.Generic;
using Vitkir.UserManager.BLL.Contracts;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;

namespace Vitkir.UserManager.BLL.Logic
{
	public abstract class AbstractLogic<T> : ILogic<T> where T : IEquatable<T>, ICloneable
	{
		protected readonly Dictionary<int, T> entityCache;
		protected readonly IDAO<T> entityDAO;

		public AbstractLogic(IDAO<T> entityDAO)
		{
			this.entityDAO = entityDAO;
			entityCache = entityDAO.GetEntities();
		}

		public virtual T CreateEntity(T entity)
		{
			T createdEntity;
			createdEntity = entityDAO.CreateEntity(entity);
			entityCache.Add(createdEntity.Id, createdEntity);
			return createdEntity;
		}

		public virtual void UpdateEntityDAO()
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
