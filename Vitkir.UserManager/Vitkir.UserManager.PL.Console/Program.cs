using System;
using Vitkir.UserManager.BLL.Logic;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.PL.Console
{
	class Program
	{
		private static UserLogic userLogic;
		static void Main()
		{
			userLogic = new UserLogic();
			ShowUserOptions();
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
			var name = System.Console.ReadLine();

			System.Console.WriteLine("Input birthday in formate yyyy.MM.dd");
			var birthday = DateTime.Parse(System.Console.ReadLine());

			var user = new User(name, birthday);
			var returned = userLogic.CreateUser(user).Id;
			System.Console.WriteLine(returned != 0 ?
				"success. User id: " + returned.ToString() : "unsuccessful");
		}

		public static void UpdateDatabase()
		{
			var returned = userLogic.UpdateUserDAO();
			System.Console.WriteLine(returned == true ? "success" : "unsuccessful");
		}

		public static void DeleteUser()
		{
			System.Console.WriteLine("Input id");
			var id = int.Parse(System.Console.ReadLine());
			var returned = userLogic.DeleteUserFromCache(id);
			System.Console.WriteLine(returned != 0 ? "User: " + returned.ToString() + "deleted" : "unsuccessful");
		}

		public static void GetUser()
		{
			System.Console.WriteLine("Input id");
			var id = int.Parse(System.Console.ReadLine());
			System.Console.WriteLine(userLogic.GetUser(id).ToString());
		}

		public static void GetAllUsers()
		{
			var users = userLogic.GetUsers();
			foreach (var pair in users)
			{
				System.Console.WriteLine(pair.Value.ToString());
			}
		}

		public static void GetMenu()
		{
			ConsoleKey escape = ConsoleKey.Escape;
			char input = default;
			Menu menu;
			while (true)
			{
				System.Console.Write("Select action :>");
				input = System.Console.ReadKey().KeyChar;
				System.Console.WriteLine(Environment.NewLine);
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
						ShowUserOptions();
						break;
					case Menu.Exit:
						UpdateDatabase();
						return;
				}
			}
		}

		private static void ShowUserOptions()
		{
			int option = 1;
			foreach (var name in Enum.GetNames(typeof(Menu)))
			{
				System.Console.WriteLine($"{option.ToString()}: {name}");
				option++;
			}
		}

		public static UserLogic GetUserLogic() => new UserLogic();
	}
}
