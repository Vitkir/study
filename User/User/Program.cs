using System;
using System.Collections.Generic;
using System.Globalization;

namespace User
{
	class Program
	{
		static void Main()
		{
			var users = new List<User>();
			GetUserOptions(users);
		}

		static string GetTextFromConsole() => Console.ReadLine();

		static DateTime GetDateTimeFromConsole()
		{
			DateTime date;
			Console.WriteLine("Enter date formate: dd MM yyyy");
			while (!DateTime.TryParseExact(GetTextFromConsole(), "dd MM yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
			{
				Console.WriteLine("Incorrect dates format");
			}
			return date;
		}

		private static ConsoleKeyInfo GetInputFromConsole() => Console.ReadKey();

		private static int GetUsersIndexFromConsole()
		{
			int index;
			Console.WriteLine("Enter index user for delete");
			while (!int.TryParse(GetTextFromConsole(), out index))
			{
				Console.WriteLine("Enter enteger value");
			}
			return index;
		}

		static User GetUserFromConsole()
		{
			Console.WriteLine("Enter surname, name, patr, birthday");
			return new User(GetTextFromConsole(),
							GetTextFromConsole(),
							GetTextFromConsole(),
							GetDateTimeFromConsole());
		}

		private static void DeleteUser(List<User> users, int userIndex)
		{
			if (users.Count > 0 && users.Count > userIndex)
			{
				users.Remove(users[userIndex]);
			}
			else
			{
				Console.WriteLine("Such an index does not exist");
			}
		}

		enum UserOptions
		{
			Add = 1,
			Delete,
			ShowUsers
		}

		private static void ShowUserOptions()
		{
			int option = 1;
			foreach (string name in Enum.GetNames(typeof(UserOptions)))
			{
				Console.WriteLine($"{option}: {name}");
				option++;
			}
		}

		private static void ShowUserList(List<User> users)
		{
			foreach (var user in users)
			{
				Console.WriteLine(user);
			}
		}

		private static void GetUserOptions(List<User> users)
		{
			ConsoleKeyInfo input;
			int userIndex;
			do
			{
				Console.WriteLine("Count: " + users.Count);
				ShowUserOptions();
				input = GetInputFromConsole();
				Console.WriteLine();
				switch (input.KeyChar)
				{
					case '1':
						users.Add(GetUserFromConsole());
						break;
					case '2':
						userIndex = GetUsersIndexFromConsole();
						DeleteUser(users, userIndex);
						break;
					case '3':
						ShowUserList(users);
						break;
					default:
						Console.Clear();
						break;
				}
			} while (input.Key != ConsoleKey.Escape);
		}
	}
}
