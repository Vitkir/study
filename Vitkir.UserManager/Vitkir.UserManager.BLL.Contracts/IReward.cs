using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.BLL.Contracts
{
	public interface IReward
	{
		Relation AddAward(Relation relation);

		bool RemoveAward(Relation relation);
	}
}