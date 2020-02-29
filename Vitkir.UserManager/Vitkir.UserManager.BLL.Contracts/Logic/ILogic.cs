using System;
using System.Collections.Generic;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.BLL.Contracts.Logic
{
	public interface ILogic<TId, TEntity> where TEntity : IEntity<TId>, IEquatable<TEntity>
	{
		TEntity Create(TEntity entity);

		bool Delete(TId id);

		TEntity Get(TId id);

		Dictionary<TId, TEntity> GetAll();

		void UpdateDAO();
	}
}