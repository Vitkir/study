using System.Collections.Generic;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.DAL.Abstract
{
	public interface IUserDAO
    {
		int Create(User user);

		int Delete(int id);

		void Assign();

		IEnumerable<User> Get(int id);

		IEnumerable<User> GetAll();
    }
}
