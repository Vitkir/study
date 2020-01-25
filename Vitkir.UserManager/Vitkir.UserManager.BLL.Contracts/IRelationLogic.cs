using System;
using System.Collections.Generic;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.BLL.Contracts
{
	public interface IRelationLogic
	{
		Relation CreateRelation(Relation relation);

		Tuple<int, int> DeleteRelation(int userId, int awardId);

		ICollection<int> GetRelatedEntities(int id);
	}
}
