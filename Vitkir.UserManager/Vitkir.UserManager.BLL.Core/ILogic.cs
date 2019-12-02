using System;
using System.Collections.Generic;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.BLL.Logic
{
	public interface ILogic<T> where T : Entity, ICloneable
	{
		T CreateEntity(T user);

		int DeleteEntityFromCache(int id);

		Dictionary<int, T> GetEntities();

		T GetEntity(int id);

		void UpdateEntityDAO();
	}
}