namespace Vitkir.UserManadger.PL.Console
{
	internal class Enums
	{
		internal enum MainMenu : int
		{
			Award = 1,
			User,
			Exit,
		}

		internal enum UserMakeIt : int
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

		internal enum AwardMakeIt : int
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
