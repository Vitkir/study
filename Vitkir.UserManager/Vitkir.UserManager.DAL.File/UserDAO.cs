using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.DAL.File
{
	public class UserDAO
	{
		private const string usersFilePath = @"C:\Users\User\Desktop\Learning\xt_2016\Task_6\users.txt";
		private const string tmpFilePath = @"C:\Users\User\Desktop\Learning\xt_2016\Task_6\userstmp.txt";

		private const string recordExeption = "Cannot data writing";
		private const string readingExeption = "The users data file could not be read";
		private const string fileMissingExeption = "File missing";

		private int lastId;

		public UserDAO()
		{
			if (!System.IO.File.Exists(usersFilePath))
			{
				CreateUsersDataFile();
			}
			lastId = GetLastId();
		}

		public User CreateUser(User user)
		{
			user.Id = ++lastId;
			var userItem = user.ToString() + Environment.NewLine;
			long currentPosition;
			try
			{
				using (FileStream fileStream = new FileStream(usersFilePath, FileMode.Append))
				{
					currentPosition = fileStream.Position;
					var byData = Encoding.ASCII.GetBytes(userItem);
					fileStream.Write(byData, 0, byData.Length);
				}
			}
			catch (IOException e)
			{
				throw new IOException(recordExeption, e);
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
			var info = new FileInfo(usersFilePath).IsReadOnly;
			if (!info)
			{
				throw new IOException(recordExeption);
			}
			System.IO.File.Move(tmpFilePath, usersFilePath);
			return true;
		}

		public Dictionary<int, User> GetUsers()
		{
			string[] lines;
			if (!System.IO.File.Exists(usersFilePath))
			{
				throw new IOException(fileMissingExeption);
			}
			lines = System.IO.File.ReadAllLines(usersFilePath);

			Dictionary<int, User> users = new Dictionary<int, User>();
			for (int i = 0; i < lines.Length; i++)
			{
				var user = ParseString(lines[i]);
				users.Add(user.Id, user);
			}
			return users;
		}

		private int GetLastId()
		{
			string currentLine = default;
			int currentId = default;
			try
			{
				using (StreamReader streamReader = new StreamReader(usersFilePath))
				{
					currentLine = streamReader.ReadLine();
					while (!string.IsNullOrEmpty(currentLine))
					{
						currentId = ParseId(currentLine);
						currentLine = streamReader.ReadLine();
					}
				}
			}
			catch (IOException e)
			{
				throw new IOException(readingExeption, e);
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

		private static void CreateUsersDataFile()
		{
			System.IO.File.Create(usersFilePath).Dispose();
		}
	}
}
