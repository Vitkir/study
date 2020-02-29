using Vitkir.UserManager.BLL.Contracts.Cache;
using Vitkir.UserManager.BLL.Contracts.Logic;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;

namespace Vitkir.UserManager.BLL.Logic
{
	public class AccountLogic : AbstractLogic<int, Account>, IAccountLogic
	{
		public AccountLogic(
			IDAO<int, Account> entityDAO, ICache cache) : base(entityDAO, cache)
		{
		}

		public Relation ChangeRole(Relation relation)
		{
			cache[relation.FirstId].Role = (Role)relation.SecondId;
			return relationCache.Create(relation);
		}

		public bool AccountExist(int id)
		{
			return cache.ContainsKey(id);
		}
	}
}
