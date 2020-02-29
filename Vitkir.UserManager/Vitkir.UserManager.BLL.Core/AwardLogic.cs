using System.Collections.Generic;
using System.Linq;
using Vitkir.UserManager.BLL.Contracts.Cache;
using Vitkir.UserManager.BLL.Contracts.Logic;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;

namespace Vitkir.UserManager.BLL.Logic
{
	public class AwardLogic : AbstractLogic<int, Award>, IAwardLogic
	{
		public AwardLogic(
			IDAO<int, Award> awardDAO,
			IUsersAwardsRelationsCache relationCache) : base(awardDAO, relationCache)
		{
		}

		public List<Award> GetAll(int userId)
		{
			return relationCache.GetAll().Values
				.Where(relation => relation.FirstId == userId
				&& cache.ContainsKey(relation.SecondId))
				.Select(relation => cache[relation.SecondId].Clone())
				.Cast<Award>()
				.ToList();
		}
	}
}
