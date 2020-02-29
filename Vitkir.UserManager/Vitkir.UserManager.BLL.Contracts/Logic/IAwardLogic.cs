using System.Collections.Generic;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.BLL.Contracts.Logic
{
	public interface IAwardLogic : ILogic<int, Award>
	{
		List<Award> GetAll(int userId);
	}
}
