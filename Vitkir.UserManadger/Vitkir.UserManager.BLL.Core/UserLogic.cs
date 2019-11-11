using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vitkir.UserManager.CommonEntities;

namespace Vitkir.UserManager.BLL.Core
{
	public class UserLogic
	{
		private UserCache UserCache;

		public bool Create(string name, DateTime birthday)
		{
			User user = new User(name, birthday);
			return UserCache.Create(user) != 0 ? true : false;
		}

		public bool Delete(int id)
		{
			return UserCache.Delete(id) != 0 ? true : false;
		}

		public IEnumerable<User> Get(int id)
		{
			return UserCache.Get(id);
		}

		public IEnumerable<User> GetAll()
		{
			return UserCache.GetAll();
		}
	}
}
