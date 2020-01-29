using System.Collections.Generic;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.BLL.Contracts
{
	public interface IGetRelationCache//relationdoes not have logic
	{
		List<Award> GetAwardsUser(int UserId);
	}
}
