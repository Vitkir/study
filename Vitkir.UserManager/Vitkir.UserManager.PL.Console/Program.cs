using Ninject;
using System;
using Vitkir.UserManadger.PL.Console;
using Vitkir.UserManager.Common.Dependencies;
using static Vitkir.UserManadger.PL.Console.Enums;

namespace Vitkir.UserManager.PL.Console
{
	class Program
	{
		private static IKernel dependencyManager;
		private static UserPresentation userPresentation;
		private static AwardPresentation awardPresentation;

		private static MainMenu main;
		private static UserMakeIt user;
		private static AwardMakeIt award;

		static void Main()
		{
			dependencyManager = new StandardKernel(new DependencyManager());
			userPresentation = dependencyManager.Get<UserPresentation>();
			awardPresentation = dependencyManager.Get<AwardPresentation>();
			user = new UserMakeIt();
			award = new AwardMakeIt();
			main = new MainMenu();
			ShowEnum(main);
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
						case Enums.MainMenu.ConsoleClearing:
							System.Console.Clear();
							ShowEnum(main);
							break;
						case Enums.MainMenu.Exit:
							userPresentation.Update();
							awardPresentation.Update();
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
							var id = GetIdFromConsole();
							userPresentation.RemoveAllAwardsUser(id);
							userPresentation.Delete(id);
							break;
						case Enums.UserMakeIt.Get:
							userPresentation.Get(GetIdFromConsole());
							break;
						case Enums.UserMakeIt.GetAll:
							userPresentation.GetAll();
							break;
						case Enums.UserMakeIt.AddAward:
							userPresentation.AddAward(
								GetIdFromConsole(),
								GetIdFromConsole());
							break;
						case Enums.UserMakeIt.RemoveAward:
							userPresentation.RemoveAward(
								GetIdFromConsole(),
								GetIdFromConsole());
							break;
						case Enums.UserMakeIt.GetAwardsUser:
							awardPresentation.GetAwardsUser(GetIdFromConsole());
							break;
						case Enums.UserMakeIt.Back:
							ShowEnum(main);
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
							var id = GetIdFromConsole();
							userPresentation.RemoveAwardAllUsers(id);
							awardPresentation.Delete(id);
							break;
						case Enums.AwardMakeIt.Get:
							awardPresentation.Get(GetIdFromConsole());
							break;
						case Enums.AwardMakeIt.GetAll:
							awardPresentation.GetAll();
							break;
						case Enums.AwardMakeIt.Back:
							ShowEnum(main);
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

		private static int GetIdFromConsole()
		{
			int id;
			System.Console.WriteLine("Input id");
			var input = System.Console.ReadLine();
			while (!int.TryParse(input, out id))
			{
				System.Console.WriteLine("Incorrect input");
				input = System.Console.ReadLine();
			}
			return id;
		}
	}
}
