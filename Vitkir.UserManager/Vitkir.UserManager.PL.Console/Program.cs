using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.BLL.Logic;
using Vitkir.UserManager.Common.Dependencies;
using Ninject;
using Vitkir.UserManadger.PL.Console;

namespace Vitkir.UserManager.PL.Console
{
	public class Program
	{
		private static UserPresentation userPresentation;
		private static AwardPresentation awardPresentation;
		private static IKernel dependencyManager;

		static void Main()
		{
			ShowEntityOptions(new Menu());
			GetMenu();
		}

		public enum Entities : int
		{
			Award = 1,
			User,
			Exit,
		}

		public enum Menu : int
		{
			Create = 1,
			Update,
			Delete,
			Get,
			GetAll,
			ConsoleClearing,
			Exit,
		}

		public Program()
		{
			dependencyManager = new StandardKernel(new DependencyManager());
			userPresentation = dependencyManager.Get<UserPresentation>();
			awardPresentation = dependencyManager.Get<AwardPresentation>();
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
							ShowEntityOptions(entities);
							break;
						case Menu.Update:
							userPresentation.UpdateDatabase();
							awardPresentation.UpdateDatabase();
							break;
						case Menu.Delete:
							ShowEntityOptions(entities);
							break;
						case Menu.Get:
							ShowEntityOptions(entities);
							break;
						case Menu.GetAll:
							ShowEntityOptions(entities);
							break;
						case Menu.ConsoleClearing:
							System.Console.Clear();
							ShowEntityOptions(menu);
							break;
						case Menu.Exit:
							userPresentation.UpdateDatabase();
							awardPresentation.UpdateDatabase();
							return;
					}
				}
			}
		}
		private static void GetSubMenu()
		{
			char input;
			Entities menu;
			while (true)
			{
				System.Console.Write("Select action :>");
				input = System.Console.ReadKey().KeyChar;
				System.Console.WriteLine(Environment.NewLine);
				if (char.IsDigit(input))
				{
					menu = (Entities)Enum.Parse(typeof(Entities), input.ToString());
					switch (menu)
					{
						case Entities.Award:
							break;
						case Entities.User:
							break;
						case Entities.Exit:
							return;
					}
				}
			}
		}

		private static void ShowEntityOptions(Enum @enum)
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
			var input = System.Console.ReadLine();
			while (!int.TryParse(input, out id))
			{
				input = System.Console.ReadLine();
			}
			return id;
		}
	}
}
