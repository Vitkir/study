using System.Collections.Generic;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.BLL.Logic
{
	public interface ICache
	{
		Relation Create(Relation relation);

		bool Delete(Relation relation);

		List<Relation> GetAll();

		void UpdateDAO();
	}
}