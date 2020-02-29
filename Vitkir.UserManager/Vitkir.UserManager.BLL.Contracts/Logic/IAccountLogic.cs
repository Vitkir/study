using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.BLL.Contracts.Logic
{
	public interface IAccountLogic : ILogic<int, Account>
	{
		Relation ChangeRole(Relation relation);

		bool AccountExist(int id);
	}
}
