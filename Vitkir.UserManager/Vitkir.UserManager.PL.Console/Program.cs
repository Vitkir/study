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
			var user = new User(name, birthday);
			System.Console.WriteLine(userLogic.CreateUser(user) != null ? "success" : "unsuccessful");
		}

		public static void DeleteUser(int id)
		{
			System.Console.WriteLine(userLogic.DeleteUserFromCache(id) ? "success" : "unsuccessful");
		}

		public static void GetUser(int id)
		{
			System.Console.WriteLine(userLogic.GetUser(id).ToString());
		}

		public static void GetAllUsers()
		{
			var users = userLogic.GetUsers();
			for (int i = 0; i < users.Count; i++)
			{
				System.Console.WriteLine(users[i].ToString());
			}
		}

		public static UserLogic GetUserLogic() => new UserLogic();
	}
}
