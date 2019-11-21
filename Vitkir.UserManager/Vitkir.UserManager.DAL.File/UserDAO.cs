using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.DAL.File
{
	public class UserDAO
	{
		private const string UsersFilePath = @"C:\Users\User\Desktop\Learning\xt_2016\Task_6\users.txt";
		private const string IndexerFilePath = @"C:\Users\User\Desktop\Learning\xt_2016\Task_6\Indexer.txt";
		private int counter;

		public User CreateUser(User user)
		{
			user.Id = ++counter;
			var userItem = user.ToString();
			long currentPosition;

			using (FileStream fileStream = new FileStream(UsersFilePath, FileMode.Append))
			{
				currentPosition = fileStream.Position;

				using (StreamWriter streamWriter = new StreamWriter(fileStream))
				{
					streamWriter.WriteLine(userItem);
				}
			}
			using (StreamReader streamReader = new StreamReader(UsersFilePath))
			{
				streamReader.BaseStream.Position = currentPosition;
				userItem = streamReader.ReadLine();
			}
			return ParseString(userItem);
		}

		public bool DeleteUser(int id)
		{
			var lines = System.IO.File.ReadLines(UsersFilePath);
			int currentId;
			int separator;
			foreach (var line in lines)
			{
				separator = line.IndexOf(':');
				currentId = int.Parse(line.Substring(0, separator - 1));
				if (currentId == id)
				{
					line.Insert(0, "\\");
					return true;
				}
			}
			return false;
		}

		public User GetUser(int id)
		{

		}

		public Dictionary<int, User> GetUsers()
		{
			var lines = System.IO.File.ReadAllLines(UsersFilePath);
			Dictionary<int, User> users = new Dictionary<int, User>();

			for (int i = 0; i < lines.Length; i++)
			{
				var user = ParseString(lines[i]);
				users.Add(user.Id, user);
			}
			return users;
		}

		private bool CreateUserIndex()
		{
			return true;
		}

		public User ParseString(string userItem)
		{
			var UserFields = userItem.Split(':');
			return new User(UserFields[1], DateTime.Parse(UserFields[2]))
			{
				Id = int.Parse(UserFields[0])
			};
		}
	}
}
