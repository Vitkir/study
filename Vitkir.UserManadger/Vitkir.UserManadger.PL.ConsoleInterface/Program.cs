using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vitkir.UserManager.BLL.Core;
using Vitkir.UserManager.CommonEntities;

namespace Vitkir.UserManager.PL.Console
{
	class Program
	{
		private static UserLogic userLogic;

		static Program()
		{
			userLogic = new UserLogic();
		}

		static void Main()
		{

		}

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

		public static string Create(string name, DateTime birthday)
		{
			return userLogic.Create(name, birthday) ? "Success" : "Unsuccessful";
		}

		public static string Delete(int id)
		{
			return userLogic.Delete(id) ? "Success" : "Unsuccessful";
		}

		public static string Get(int id)
		{
			userLogic.Get(id);
		}

		public static void PrintToConsole(string text)
		{
			System.Console.WriteLine(text);
		}
	}
}
