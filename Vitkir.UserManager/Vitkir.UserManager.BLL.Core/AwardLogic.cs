using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.File;

namespace Vitkir.UserManager.BLL.Logic
{
	class AwardLogic : EntityLogic<Award>
	{
		public AwardLogic(AwardDAO awardDAO) : base(awardDAO)
		{

		}
	}
}
