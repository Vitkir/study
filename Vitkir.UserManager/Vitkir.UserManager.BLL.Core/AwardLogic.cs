using System.Collections.Generic;
using Vitkir.UserManager.BLL.Contracts;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;

namespace Vitkir.UserManager.BLL.Logic
{
	public class AwardLogic : AbstractLogic<int, Award>, IRelationLogic
	{
		public AwardLogic(IDAO<int, Award> awardDAO) : base(awardDAO)
		{

		}

		public List<Relation> GetRelatedEntities(int UserId)
		{
			throw new System.NotImplementedException();
		}
	}
}
