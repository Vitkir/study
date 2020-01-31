using System.Collections.Generic;
using System.Linq;
using Vitkir.UserManager.BLL.Contracts;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;

namespace Vitkir.UserManager.BLL.Logic
{
	public class UserLogic : AbstractLogic<int, User>, IUserLogic
	{
		public UserLogic(IDAO<int, User> userDAO) : base(userDAO)
		{
		}

		public override User Get(int id)
		{
			var user = base.Get(id);
			user.RelatedAwards = GetRelatedAwardIds(id);
			return user;
		}

		public override Dictionary<int, User> GetAll()
		{
			var users = base.GetAll();
			foreach (var user in users.Values)
			{
				user.RelatedAwards = GetRelatedAwardIds(user.Id);
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
	}
}
