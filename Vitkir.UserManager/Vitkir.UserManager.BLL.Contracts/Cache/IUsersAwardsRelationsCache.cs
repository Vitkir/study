namespace Vitkir.UserManager.BLL.Contracts.Cache
{
	public interface IUsersAwardsRelationsCache : ICache
	{
		bool DeleteAllForUser(int id);

		bool DeleteAllForAward(int awardId);
	}
}