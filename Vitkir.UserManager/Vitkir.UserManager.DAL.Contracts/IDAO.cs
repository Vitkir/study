using System;
using System.Collections.Generic;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.DAL.Contracts
{
	public interface IDAO<TId, TEntity>
		where TEntity : IEntity<TId>, IEquatable<TEntity>
	{
		TEntity CreateEntity(TEntity entity);

		List<TEntity> GetEntities();

		void UpdateFile(Dictionary<TId, TEntity> usersCache);
	}
}