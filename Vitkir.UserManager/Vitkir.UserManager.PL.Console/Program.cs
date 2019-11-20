using System;
using Vitkir.UserManager.BLL.Logic;

namespace Vitkir.UserManager.PL.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			var userLogic = new UserLogic();
			userLogic.Add();
		}

		private static UserLogic userLogic;

		private enum ItemList
		{
			Award,
			User,
		}
		public enum ActionList
		{
			Create,
			Delete,
			Assign,
			Get,
			GetAll,
			Exit,
		}

		public static string CreateUser(string name, DateTime birthday)
		{
			return userLogic.Add(name, birthday) ? "Success" : "Unsuccessful";
		}

		public static string DeleteUser(int id)
		{
			return userLogic.Delete(id) ? "Success" : "Unsuccessful";
		}

		public static void GetUser(int id)
		{
			userLogic.Get(id);
		}



		public static void PrintToConsole(string text)
		{
			System.Console.WriteLine(text);
		}
	}
}
