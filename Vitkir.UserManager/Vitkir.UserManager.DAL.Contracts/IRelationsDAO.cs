using System.Collections.Generic;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.DAL.Contracts
{
	public interface IRelationsDAO : IDAO<Relation>
	{
		List<int> GetRelatedEntitiesId(int destEntityId);
	}
}
