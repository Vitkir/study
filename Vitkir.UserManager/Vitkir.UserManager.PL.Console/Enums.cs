namespace Vitkir.UserManadger.PL.Console
{
	internal class Enums
	{
		internal enum Entities : int
		{
			Award = 1,
			User,
			Exit,
		}

		internal enum UserMenu : int
		{
			Create = 1,
			Update,
			Delete,
			Get,
			GetAll,
			AddAward,
			GetAwardsUser,
			ConsoleClearing,
			Back,
		}

		internal enum AwardMenu : int
		{
			Create = 1,
			Update,
			Delete,
			Get,
			GetAll,
			ConsoleClearing,
			Back,
		}
	}
}
