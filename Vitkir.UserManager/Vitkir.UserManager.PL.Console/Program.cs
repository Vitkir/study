using Ninject;
using System;
using Vitkir.UserManadger.PL.Console;
using Vitkir.UserManager.Common.Dependencies;
using static Vitkir.UserManadger.PL.Console.Enums;

namespace Vitkir.UserManager.PL.Console
{
	class Program
	{
		private static UserPresentation userPresentation;
		private static AwardPresentation awardPresentation;
		private static IKernel dependencyManager;
		private static UserMakeIt user;
		private static AwardMakeIt award;

		static void Main()
		{
			dependencyManager = new StandardKernel(new DependencyManager());
			userPresentation = dependencyManager.Get<UserPresentation>();
			awardPresentation = dependencyManager.Get<AwardPresentation>();
			user = new UserMakeIt();
			award = new AwardMakeIt();
			ShowEnum(new MainMenu());
			MainMenu();
		}

		private static void MainMenu()
		{
			char input;
			MainMenu menu;
			while (true)
			{
				System.Console.Write("Select action :>");
				input = System.Console.ReadKey(false).KeyChar;
				System.Console.WriteLine(Environment.NewLine);
				if (char.IsDigit(input))
				{
					menu = (MainMenu)Enum.Parse(typeof(MainMenu), input.ToString());
					switch (menu)
					{
						case Enums.MainMenu.Award:
							ShowEnum(award);
							AwardMakeIt();
							break;
						case Enums.MainMenu.User:
							ShowEnum(user);
							UserMakeIt();
							break;
						case Enums.MainMenu.Exit:
							return;
						default:
							System.Console.WriteLine("Select an action");
							break;
					}
				}
			}
		}

		private static void UserMakeIt()
		{
			char input;
			UserMakeIt userMakeIt;
			while (true)
			{
				System.Console.Write("Select action :>");
				input = System.Console.ReadKey(false).KeyChar;
				System.Console.WriteLine(Environment.NewLine);
				if (char.IsDigit(input))
				{
					userMakeIt = (UserMakeIt)Enum.Parse(typeof(UserMakeIt), input.ToString());
					switch (userMakeIt)
					{
						case Enums.UserMakeIt.Create:
							userPresentation.Create();
							break;
						case Enums.UserMakeIt.Update:
							userPresentation.Update();
							break;
						case Enums.UserMakeIt.Delete:
							userPresentation.Delete();
							break;
						case Enums.UserMakeIt.Get:
							userPresentation.Get();
							break;
						case Enums.UserMakeIt.GetAll:
							userPresentation.GetAll();
							break;
						case Enums.UserMakeIt.AddAward:
							userPresentation.AddAward();
							break;
						case Enums.UserMakeIt.GetAwardsUser:
							awardPresentation.GetAll();
							break;
						case Enums.UserMakeIt.ConsoleClearing:
							System.Console.Clear();
							UserMakeIt();
							break;
						case Enums.UserMakeIt.Back:
							return;
						default:
							System.Console.WriteLine("Select an action");
							break;
					}
				}
			}
		}

		private static void AwardMakeIt()
		{
			char input;
			AwardMakeIt awardMakeIt;
			while (true)
			{
				System.Console.Write("Select action :>");
				input = System.Console.ReadKey(false).KeyChar;
				System.Console.WriteLine(Environment.NewLine);
				if (char.IsDigit(input))
				{
					awardMakeIt = (AwardMakeIt)Enum.Parse(typeof(AwardMakeIt), input.ToString());
					switch (awardMakeIt)
					{
						case Enums.AwardMakeIt.Create:
							awardPresentation.Create();
							break;
						case Enums.AwardMakeIt.Update:
							awardPresentation.Update();
							break;
						case Enums.AwardMakeIt.Delete:
							awardPresentation.Delete();
							break;
						case Enums.AwardMakeIt.Get:
							awardPresentation.Get();
							break;
						case Enums.AwardMakeIt.GetAll:
							awardPresentation.GetAll();
							break;
						case Enums.AwardMakeIt.ConsoleClearing:
							System.Console.Clear();
							AwardMakeIt();
							break;
						case Enums.AwardMakeIt.Back:
							return;
						default:
							System.Console.WriteLine("Select an action");
							break;
					}
				}
			}
		}

		private static void ShowEnum(Enum @enum)
		{
			int option = 1;
			foreach (var name in Enum.GetNames(@enum.GetType()))
			{

				System.Console.WriteLine($"{option.ToString()}: {name}");
				option++;
			}
		}
	}
}
