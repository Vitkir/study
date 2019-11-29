using System.Collections.Generic;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.DAL.File
{
	public interface IDAO<T> where T : Entity
	{
		T CreateEntity(T entity);
		Dictionary<int, T> GetUsers();
		void UpdateFile(Dictionary<int, T> usersCache);
	}
}