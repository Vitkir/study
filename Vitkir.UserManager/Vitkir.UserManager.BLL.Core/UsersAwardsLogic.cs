using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;

namespace Vitkir.UserManager.BLL.Logic
{
	public class UsersAwardsLogic: EntityLogic<UsersAwards>
	{
		public UsersAwardsLogic(IDAO<UsersAwards> usersAwardsDAO) : base(usersAwardsDAO)
		{

		}
	}
}
