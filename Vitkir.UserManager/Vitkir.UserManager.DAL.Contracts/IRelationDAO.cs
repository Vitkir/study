using System.Collections.Generic;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.DAL.Contracts
{
	public interface IRelationDAO : IDAO<Relation, Relation>
	{
		List<int> GetRelatedIdEntities(int EntityId);
	}
}
