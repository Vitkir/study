using System.Collections.Generic;
using System.Linq;
using Vitkir.UserManager.BLL.Contracts;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;

namespace Vitkir.UserManager.BLL.Logic
{
	public class UserLogic : AbstractLogic<int, User>, IUserLogic
	{
		public UserLogic(IDAO<int, User> userDAO, ICache relationCache) : base(userDAO, relationCache)
		{
		}

		public override User Get(int id)
		{
			var user = base.Get(id);
			user.Awards = GetRelatedAwardIds(id);
			return user;
		}

		public override Dictionary<int, User> GetAll()
		{
			var users = base.GetAll();
			foreach (var user in users.Values)
			{
				user.Awards = GetRelatedAwardIds(user.Id);
			}
			return users;
		}

		private List<int> GetRelatedAwardIds(int id)
		{
			return relationCache.GetAll()
				.Where(relation => relation.Key.UserId == id)
				.Select(relation => relation.Key.AwardId)
				.ToList();
		}

		public Relation AddAward(Relation relation)
		{
			return relationCache.Create(relation);
		}

		public bool RemoveAward(Relation relation)
		{
			return relationCache.Delete(relation);
		}

		public bool RemoveAllAwardsUser(int id)
		{
			return relationCache.DeleteAllForUser(id);
		}

		public bool RemoveAwardAllUsers(int id)
		{
			return relationCache.DeleteAllForAward(id);
		}
	}
}
