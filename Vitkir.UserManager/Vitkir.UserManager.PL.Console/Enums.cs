namespace Vitkir.UserManadger.PL.Console
{
	internal class Enums
	{
		internal enum MainMenu : int
		{
			Award = 1,
			User,
			ConsoleClearing,
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
			RemoveAward,
			GetAwardsUser,
			Back,
		}

		internal enum AwardMakeIt : int
		{
			Create = 1,
			Update,
			Delete,
			Get,
			GetAll,
			Back,
		}
	}
}
