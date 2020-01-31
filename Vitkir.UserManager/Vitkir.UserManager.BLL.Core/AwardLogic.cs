using System.Collections.Generic;
using System.Linq;
using Vitkir.UserManager.BLL.Contracts;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;

namespace Vitkir.UserManager.BLL.Logic
{
	public class AwardLogic : AbstractLogic<int, Award>, IAwardLogic
	{
		public AwardLogic(IDAO<int, Award> awardDAO) : base(awardDAO)
		{
		}

		public List<Award> GetAll(int userId)
		{
			return relationCache.GetAll()
				.Where(relation => relation.Key.UserId == userId)
				.Select(relation => cache[relation.Key.AwardId].Clone())
				.Cast<Award>()
				.ToList();
		}
	}
}
