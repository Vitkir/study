﻿using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.BLL.Logic;
using Vitkir.UserManager.Common.Dependencies;
using Ninject;

namespace Vitkir.UserManager.PL.Console
{
	public class Program
	{
		private static UserLogic userLogic;
		private static AwardLogic awardLogic;
		private static IKernel dependencyManager;

		static void Main()
		{
			ShowEntityOptions();
			GetMenu();
		}

		public enum Entities : int
		{
			Award = 1,
			User,
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
			userLogic = dependencyManager.Get<UserLogic>();
			awardLogic = dependencyManager.Get<AwardLogic>();
		}

		private static void GetMenu()
		{
			char input;
			Menu menu;
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
							CreateUser();
							break;
						case Menu.Update:
							UpdateDatabase();
							break;
						case Menu.Delete:
							DeleteUser();
							break;
						case Menu.Get:
							GetUser();
							break;
						case Menu.GetAll:
							GetAllUsers();
							break;
						case Menu.ConsoleClearing:
							System.Console.Clear();
							ShowEntityOptions();
							break;
						case Menu.Exit:
							UpdateDatabase();
							return;
					}
				}
			}
		}

		private static void ShowEntityOptions()
		{
			int option = 1;
			foreach (var name in Enum.GetNames(typeof(Menu)))
			{
				System.Console.WriteLine($"{option.ToString()}: {name}");
				option++;
			}
		}

		private static void CreateUser()
		{
			System.Console.WriteLine("Input name");
			var pattern = new Regex("^[a-z]{1,15}$");
			var name = System.Console.ReadLine();
			while (!pattern.IsMatch(name))
			{
				name = System.Console.ReadLine();
			}

			var info = CultureInfo.InvariantCulture;
			var style = DateTimeStyles.None;
			var formate = "yyyy.MM.dd";
			System.Console.WriteLine("Input birthday in formate " + formate);
			DateTime birthday;
			var input = System.Console.ReadLine();
			while (!DateTime.TryParseExact(input, formate, info, style, out birthday))
			{
				input = System.Console.ReadLine();
			}

			var user = new User(name, birthday);
			int returned = default;
			try
			{
				returned = userLogic.CreateEntity(user).Id;

			}
			catch (IOException e)
			{
				System.Console.WriteLine(e.Message + ". Close file and try again.");
			}
			System.Console.WriteLine("success. User id: " + returned.ToString());
		}

		private static void UpdateDatabase()
		{
			try
			{
				userLogic.UpdateEntityDAO();

			}
			catch (IOException e)
			{
				System.Console.WriteLine(e.Message + ". Close file and try again.");
			}
			System.Console.WriteLine("success");
		}

		private static void DeleteUser()
		{
			System.Console.WriteLine("Input id");
			int id;
			id = GetIdFromConsole();
			var returned = userLogic.DeleteEntityFromCache(id);
			System.Console.WriteLine(returned != 0 ? "User id " + returned.ToString() + " deleted" : "unsuccessful");
		}

		private static void GetUser()
		{
			System.Console.WriteLine("Input id");
			int id;
			id = GetIdFromConsole();
			var user = userLogic.GetUser(id);
			System.Console.WriteLine(user != null ?
				"User: " + user.ToString() : "User with such id does not exist");
		}

		private static void GetAllUsers()
		{
			var users = userLogic.GetEntities();
			foreach (var pair in users)
			{
				System.Console.WriteLine(pair.Value.ToString());
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
