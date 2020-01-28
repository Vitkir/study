using System;
using System.Collections.Generic;
using Vitkir.UserManager.BLL.Contracts;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;

namespace Vitkir.UserManager.BLL.Logic
{
	public abstract class AbstractLogic<TId, TEntity> : ILogic<TId, TEntity>
		where TEntity : IEntity<TId>, IEquatable<TEntity>, ICloneable
	{
		protected readonly Dictionary<TId, TEntity> cache;
		protected readonly IDAO<TId, TEntity> entityDAO;

		public AbstractLogic(IDAO<TId, TEntity> entityDAO)
		{
			this.entityDAO = entityDAO;
			cache = entityDAO.GetEntities();
		}

		public virtual TEntity CreateEntity(TEntity entity)
		{
			TEntity createdEntity;
			createdEntity = entityDAO.CreateEntity(entity);
			cache.Add(createdEntity.Id, createdEntity);
			return createdEntity;
		}

		public virtual void UpdateEntityDAO()
		{
			var entities = GetEntities();
			entityDAO.UpdateFile(entities);
		}

		public TId DeleteEntityFromCache(TId id)//check whether ContainsKey check is necessary
		{
			if (cache.ContainsKey(id))
			{
				cache.Remove(id);
				return id;
			}
			throw new KeyNotFoundException();
		}

		public TEntity GetEntity(TId id)//check whether ContainsKey check is necessary
		{
			if (cache.ContainsKey(id))
			{
				return (TEntity)cache[id].Clone();
			}
			throw new KeyNotFoundException();
		}

		public List<TEntity> GetEntities()// make the same with linq and choose the best way
		{
			var len = cache.Count;
			TEntity entity;
			var entities = new List<TEntity>(len);
			foreach (var pair in cache.Values)
			{
				entity = (TEntity)pair.Clone();
				entities.Add(entity);
			}
			return entities;
		}
	}
}
