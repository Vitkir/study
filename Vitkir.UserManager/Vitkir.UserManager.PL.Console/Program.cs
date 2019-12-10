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

		static void Main()
		{
			dependencyManager = new StandardKernel(new DependencyManager());
			userPresentation = dependencyManager.Get<UserPresentation>();
			awardPresentation = dependencyManager.Get<AwardPresentation>();
			ShowEnum(new Menu());
			GetMenu();
		}

		private static void GetMenu()
		{
			char input;
			Menu menu;
			Entities entities = new Entities();
			while (true)
			{
				System.Console.Write("Select action :>");
				input = System.Console.ReadKey().KeyChar;
				System.Console.WriteLine(Environment.NewLine);
				if (char.IsDigit(input))
				{
					menu = (Menu)Enum.Parse(typeof(Menu), input.ToString());
					switch (menu)
					{
						case Menu.Create:
							ShowEnum(entities);
							GetSubMenu().CreateEntity();
							break;
						case Menu.Update:
							userPresentation.UpdateDatabase();
							awardPresentation.UpdateDatabase();
							break;
						case Menu.Delete:
							ShowEnum(entities);
							GetSubMenu().DeleteEntity();
							break;
						case Menu.Get:
							ShowEnum(entities);
							GetSubMenu().GetEntity();
							break;
						case Menu.GetAll:
							ShowEnum(entities);
							GetSubMenu().GetAllentities();
							break;
						case Menu.Assign:
							ShowEnum(entities);

							break;
						case Menu.ConsoleClearing:
							System.Console.Clear();
							ShowEnum(menu);
							break;
						case Menu.Exit:
							userPresentation.UpdateDatabase();
							awardPresentation.UpdateDatabase();
							return;
					}
				}
			}
		}

		private static IEntityPresentation GetSubMenu()
		{
			char input;
			Entities entities;
			while (true)
			{
				System.Console.Write("Select action :>");
				input = System.Console.ReadKey().KeyChar;
				System.Console.WriteLine(Environment.NewLine);
				if (char.IsDigit(input))
				{
					entities = (Entities)Enum.Parse(typeof(Entities), input.ToString());
					switch (entities)
					{
						case Entities.Award:
							return awardPresentation;
						case Entities.User:
							return userPresentation;
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
