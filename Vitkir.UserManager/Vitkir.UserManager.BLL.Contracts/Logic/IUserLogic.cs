using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.BLL.Contracts.Logic
{
	public interface IUserLogic : ILogic<int, User>
	{
		Relation AddAward(Relation relation);

		bool RemoveAward(Relation relation);

		bool RemoveAllAwardsUser(int id);

		bool RemoveAwardAllUsers(int id);

		int AddImg(Image image);

		Image GetImage(int imgId);
	}
}