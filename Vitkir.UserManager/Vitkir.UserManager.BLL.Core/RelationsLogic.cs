using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;

namespace Vitkir.UserManager.BLL.Logic
{
	public class RelationsLogic: AbstractLogic<Relation>
	{
		public RelationsLogic(IDAO<Relation> usersAwardsDAO) : base(usersAwardsDAO)
		{

		}
	}
}
