using System.Collections.Generic;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.DAL.Contracts
{
	public interface IDAO<T> where T : AbstractEntity
	{
		T CreateEntity(T entity);

		Dictionary<int, T> GetEntities();

		void UpdateFile(Dictionary<int, T> usersCache);
	}
}