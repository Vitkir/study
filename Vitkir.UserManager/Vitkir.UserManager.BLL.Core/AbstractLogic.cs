using System;
using System.Collections.Generic;
using System.Linq;
using Vitkir.UserManager.BLL.Contracts.Cache;
using Vitkir.UserManager.BLL.Contracts.Logic;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;

namespace Vitkir.UserManager.BLL.Logic
{
	public abstract class AbstractLogic<TId, TEntity> : ILogic<TId, TEntity>
		where TEntity : IEntity<TId>, IEquatable<TEntity>, ICloneable
	{
		protected readonly Dictionary<TId, TEntity> cache;
		protected readonly ICache relationCache;
		protected readonly IDAO<TId, TEntity> entityDAO;

		public AbstractLogic(IDAO<TId, TEntity> entityDAO, ICache relationCache)
		{
			this.entityDAO = entityDAO;
			cache = GetAllFromDAO();
			this.relationCache = relationCache;
		}

		public TEntity Create(TEntity entity)
		{
			if (cache.ContainsKey(entity.Id) && cache[entity.Id].Equals(entity))
			{
				cache[entity.Id] = entity;
				UpdateDAO();
				return entity;
			}
			TEntity createdEntity;
			createdEntity = entityDAO.CreateEntity(entity);
			cache.Add(createdEntity.Id, createdEntity);
			return createdEntity;
		}

		public void UpdateDAO()
		{
			var entities = GetAll();
			entityDAO.UpdateFile(entities);
			relationCache.UpdateDAO();
		}

		public bool Delete(TId id)
		{
			return cache.Remove(id);
		}

		public virtual TEntity Get(TId id)
		{
			return (TEntity)cache[id].Clone();
		}

		public virtual Dictionary<TId, TEntity> GetAll()
		{
			return cache.Values
				.Select(entity => entity.Clone())
				.Cast<TEntity>()
				.ToDictionary(e => e.Id);
		}

		private Dictionary<TId, TEntity> GetAllFromDAO()
		{
			return entityDAO.GetEntities()
				.ToDictionary(entity => entity.Id);
		}
	}
}
