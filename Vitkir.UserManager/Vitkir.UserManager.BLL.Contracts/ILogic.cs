using System;
using System.Collections.Generic;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.BLL.Contracts
{
	public interface ILogic<T> where T : AbstractEntity, ICloneable
	{
		T CreateEntity(T entity);

		int DeleteEntityFromCache(int id);

		Dictionary<int, T> GetEntities();

		T GetEntity(int id);

		void UpdateEntityDAO();
	}
}