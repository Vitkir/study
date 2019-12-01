using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;

namespace Vitkir.UserManager.BLL.Logic
{
	public class AwardLogic : EntityLogic<Award>
	{
		public AwardLogic(IDAO<Award> awardDAO) : base(awardDAO)
		{

		}
	}
}
