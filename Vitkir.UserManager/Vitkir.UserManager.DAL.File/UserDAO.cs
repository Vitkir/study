using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.DAL.File
{
	public class UserDAO
	{
		private const string usersFilePath = @"C:\Users\User\Desktop\Learning\xt_2016\Task_6\users.txt";
		private const string tmpFilePath = @"C:\Users\User\Desktop\Learning\xt_2016\Task_6\tmp.txt";
		private int lastId;

		public UserDAO()
		{
			lastId = GetLastId();
		}

		public User CreateUser(User user)
		{
			if (!System.IO.File.Exists(usersFilePath))
			{
				System.IO.File.Create(usersFilePath).Dispose();
			}
			user.Id = ++lastId;
			var userItem = user.ToString();
			long currentPosition;

			using (FileStream fileStream = new FileStream(usersFilePath, FileMode.Append))
			{
				currentPosition = fileStream.Position;

				using (StreamWriter streamWriter = new StreamWriter(fileStream))
				{
					streamWriter.WriteLine(userItem);
				}
			}

			using (StreamReader streamReader = new StreamReader(usersFilePath))
			{
				streamReader.BaseStream.Position = currentPosition;
				userItem = streamReader.ReadLine();
			}
			return ParseString(userItem);
		}

		public bool UpdateFile(Dictionary<int, User> usersCache)
		{
			System.IO.File.Create(tmpFilePath).Dispose();
			using (StreamWriter streamWriter = new StreamWriter(tmpFilePath))
			{
				foreach (var pair in usersCache)
				{
					streamWriter.WriteLine(pair.Value.ToString());
				}
			}
			System.IO.File.Delete(usersFilePath);
			System.IO.File.Move(tmpFilePath, usersFilePath);
			return true;
		}

		public Dictionary<int, User> GetUsers()
		{
			var lines = System.IO.File.ReadAllLines(usersFilePath);
			Dictionary<int, User> users = new Dictionary<int, User>();

			for (int i = 0; i < lines.Length; i++)
			{
				if (lines[i].Contains("\\")) continue;
				var user = ParseString(lines[i]);
				users.Add(user.Id, user);
			}
			return users;
		}

		private int GetLastId()
		{
			string currentLine = default;
			int currentId = default;
			using (StreamReader streamReader = new StreamReader(usersFilePath))
			{
				currentLine = streamReader.ReadLine();
				while (!string.IsNullOrEmpty(currentLine))
				{
					if (currentLine.Contains("\\")) continue;
					currentId = ParseId(currentLine);
					currentLine = streamReader.ReadLine();
				}
			}
			return currentId;
		}

		private static int ParseId(string currentLine)
		{
			var separator = currentLine.IndexOf(':');
			return int.Parse(currentLine.Substring(0, separator));
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
