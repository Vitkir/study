using System.Collections.Generic;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.BLL.Logic
{
	public interface ICache
	{
		Relation Create(Relation relation);

		bool Delete(Relation relation);

		bool DeleteAllForUser(int id);

		bool DeleteAllForAward(int awardId);

		Dictionary<Relation, Relation> GetAll();

		void UpdateDAO();
	}
}