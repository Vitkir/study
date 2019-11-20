using System.IO;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.DAL.File
{
	public class UserDAO
	{
		private const string path = @"C:\Users\User\Desktop\Learning\xt_2016\Task_6\users.txt";
		private int counter;

		public int AddUser(User user)
		{
			user.Id = ++counter;
			var userJson = user.ToString();
			using (StreamWriter streamWriter = new StreamWriter(path))
			{
				streamWriter.WriteLine(userJson);
			}
			return user.Id;
		}

		public int DeleteUser(int id)
		{

		}

		public User GetUser()
		{

		}

		public User[] GetUsers()
		{

		}
	}
}
