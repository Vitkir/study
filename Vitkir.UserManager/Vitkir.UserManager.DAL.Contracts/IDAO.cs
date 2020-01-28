using System;
using System.Collections.Generic;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.DAL.Contracts
{
	public interface IDAO<TEntityId, TEntity>
		where TEntity : IEntity<TEntityId>, IEquatable<TEntity>
	{
		TEntity CreateEntity(TEntity entity);

		List<TEntity> GetEntities();

		void UpdateFile(List<TEntity> usersCache);
	}
}