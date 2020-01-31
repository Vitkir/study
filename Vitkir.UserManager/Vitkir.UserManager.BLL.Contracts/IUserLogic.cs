using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.BLL.Contracts
{
	public interface IUserLogic : ILogic<int, User>
	{
		Relation AddAward(Relation relation);

		bool RemoveAward(Relation relation);
	}
}