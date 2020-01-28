using System;
using System.Collections.Generic;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.BLL.Contracts
{
	public interface ILogic<TId, TEntity> where TEntity : IEntity<TId>, IEquatable<TEntity>
	{
		TEntity CreateEntity(TEntity entity);

		TId DeleteEntityFromCache(TId id);

		TEntity GetEntity(TId id);

		List<TEntity> GetEntities();

		void UpdateEntityDAO();
	}
}