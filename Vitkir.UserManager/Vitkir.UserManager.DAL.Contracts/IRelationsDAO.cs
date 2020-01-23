using System.Collections.Generic;

namespace Vitkir.UserManager.DAL.Contracts
{
	public interface IRelationsDAO
	{
		List<int> GetRelatedEntitiesId(int destEntityId);
	}
}
