using System.Collections.Generic;
using System.Linq;
using Vitkir.UserManager.BLL.Contracts;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;

namespace Vitkir.UserManager.BLL.Logic
{
	public class AwardLogic : AbstractLogic<int, Award>, IAwardLogic
	{
		public AwardLogic(IDAO<int, Award> awardDAO, ICache relationCache) : base(awardDAO, relationCache)
		{
		}

		public List<Award> GetAll(int userId)
		{
			return relationCache.GetAll().Values
				.Where(relation => relation.UserId == userId 
				&& cache.ContainsKey(relation.AwardId))
				.Select(relation => cache[relation.AwardId].Clone())
				.Cast<Award>()
				.ToList();
		}
	}
}
