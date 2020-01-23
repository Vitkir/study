using System;
using System.Collections.Generic;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.BLL.Logic
{
	public interface IRelationLogic : ILogic<User>
	{
		Relation CreateRelation(Relation relation);

		Tuple<int, int> DeleteRelationEntity(int userId, int awardId);

		ICollection<int> GetRelatedEntities(int id);

		void UpdateRelationsDAO();
	}
}
