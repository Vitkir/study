using System.Linq;
using Vitkir.UserManager.BLL.Contracts.Cache;
using Vitkir.UserManager.DAL.Contracts;

namespace Vitkir.UserManager.BLL.Logic.Cache
{
	public class UsersAwardsRelationsCache : RelationsCache, IUsersAwardsRelationsCache
	{
		public UsersAwardsRelationsCache(IRelationDAO relationDAO) : base(relationDAO)
		{
		}

		public bool DeleteAllForUser(int userId)
		{
			foreach (var item in relations.Where(e => e.Key.FirstId == userId).ToList())
			{
				relations.Remove(item.Key);
			}
			return true;
		}

		public bool DeleteAllForAward(int awardId)
		{
			foreach (var item in relations.Where(e => e.Key.SecondId == awardId).ToList())
			{
				relations.Remove(item.Key);
			}
			return true;
		}
	}
}
