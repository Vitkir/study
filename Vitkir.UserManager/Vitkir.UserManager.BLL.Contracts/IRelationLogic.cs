using System.Collections.Generic;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.BLL.Contracts
{
	public interface IRelationLogic
	{
		List<Relation> GetRelatedEntities(int UserId);
	}
}
