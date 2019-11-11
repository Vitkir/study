using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vitkir.UserManager.CommonEntities;

namespace Vitkir.UserManager.DAL.Abstract
{
    public interface IDAO
    {
		int Create(User user);

		int Delete(int id);

		void Assign();

		IEnumerable<User> Get(int id);

		IEnumerable<User> GetAll();
    }
}
