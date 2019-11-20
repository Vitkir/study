using System;
using Vitkir.UserManager.BLL.Logic;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.PL.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			var userLogic = GetUserLogic();
		}

		private static UserLogic userLogic;

		public enum ItemList
		{
			Award = 1,
			User,
		}

		public enum ActionList
		{
			Create = 1,
			Delete,
			Assign,
			Get,
			GetAll,
			Exit,
		}

		public static void CreateUser(string name, DateTime birthday)
		{
			System.Console.WriteLine(userLogic.AddUser(new User(name, birthday)) != 0 ? "success" : "unsuccessful");
		}

		public static void DeleteUser(int id)
		{
			System.Console.WriteLine(userLogic.DeleteUser(id) ? "success" : "unsuccessful");
		}

		public static void GetUser(int id)
		{
			System.Console.WriteLine(userLogic.GetUser(id).ToString());
		}

		public static void GetAllUsers()
		{
			var users = userLogic.GetUsers();
			for (int i = 0; i < users.Length; i++)
			{
				System.Console.WriteLine(users[i].ToString());
			}
		}

		public static UserLogic GetUserLogic() => new UserLogic();
	}
}
