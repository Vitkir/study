using System.Collections.Generic;
using System.Linq;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;

namespace Vitkir.UserManager.BLL.Logic
{
	public class AwardLogic : AbstractLogic<int, Award>
	{
		public AwardLogic(IDAO<int, Award> awardDAO) : base(awardDAO)
		{
		}

		public List<Award> GetAwardsUser(int userId)
		{
			return relationCache.GetAll()
				.Where(relation => relation.UserId == userId)
				.Select(relation => cache[relation.AwardId].Clone())
				.Cast<Award>()
				.ToList();
		}
	}
}
