using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.BLL.Logic;

namespace Vitkir.UserManager.PL.Console
{
	class Program
	{
		private static EntityLogic<Entity> entityLogic;

		static void Main()
		{
			ShowEntityOptions();
			GetMenu();
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

		public static void CreateUser()
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
				returned = entityLogic.CreateEntity(user).Id;

			}
			catch (IOException e)
			{
				System.Console.WriteLine(e.Message + ". Close file and try again.");
			}
			System.Console.WriteLine("success. User id: " + returned.ToString());
		}

		public static void UpdateDatabase()
		{
			bool returned = default;
			try
			{
				returned = entityLogic.UpdateEntityDAO();

			}
			catch (IOException e)
			{
				System.Console.WriteLine(e.Message + ". Close file and try again.");
			}
			System.Console.WriteLine("success");
		}

		public static void DeleteUser()
		{
			System.Console.WriteLine("Input id");
			int id;
			id = GetIdFromConsole();
			var returned = entityLogic.DeleteEntityFromCache(id);
			System.Console.WriteLine(returned != 0 ? "User id " + returned.ToString() + " deleted" : "unsuccessful");
		}

		public static void GetUser()
		{
			System.Console.WriteLine("Input id");
			int id;
			id = GetIdFromConsole();
			var user = entityLogic.GetUser(id);
			System.Console.WriteLine(user != null ?
				"User: " + user.ToString() : "User with such id does not exist");
		}

		public static void GetAllUsers()
		{
			var users = entityLogic.GetEntities();
			foreach (var pair in users)
			{
				System.Console.WriteLine(pair.Value.ToString());
			}
		}

		public static void GetMenu()
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

		public static EntityLogic<Entity> GetEntityLogic() => new EntityLogic<Entity>();

		private static void ShowEntityOptions()
		{
			int option = 1;
			foreach (var name in Enum.GetNames(typeof(Menu)))
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
