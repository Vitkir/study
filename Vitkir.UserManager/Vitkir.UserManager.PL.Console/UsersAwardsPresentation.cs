using System.IO;
using Vitkir.UserManager.BLL.Logic;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManadger.PL.Console
{
	class UsersAwardsPresentation : AbstractEntityPresentation<UsersAwards>
	{
		public UsersAwardsPresentation(ILogic<UsersAwards> usersAwardslogic) : base(usersAwardslogic)
		{

		}

		public override void CreateEntity()
		{
			System.Console.WriteLine("Input User");
			var userId = GetIdFromConsole();
			System.Console.WriteLine("Input Award");
			var awardId = GetIdFromConsole();

			var userAward = new UsersAwards(userId, awardId);
			int returned = default;
			try
			{
				returned = entityLogic.CreateEntity(userAward).Id;
			}
			catch (IOException e)
			{
				System.Console.WriteLine(e.Message + ". Close file and try again.");
			}
			System.Console.WriteLine("success. UserAward id: " + returned.ToString());
		}
	}
}
