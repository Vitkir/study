using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vitkir.UserManager.BLL.Logic;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.Tests.NUnit
{
	[TestClass]
	public class UserLogicTests
	{
		private readonly UserLogic userLogic;

		public UserLogicTests()
		{
			userLogic = new UserLogic();
		}

		[TestMethod]
		public void CannotUpdateUserByCreate()
		{
			User user = new User("name", new DateTime(1994, 05, 14));
			var createdUser = userLogic.CreateUser(user);
			createdUser.Id = 10;
			Assert.AreNotEqual(user.Id, createdUser.Id, "createdUser update couset source user update.");
		}

		[TestMethod]
		public void CannotChangeUserByGetUser()
		{
			var user = userLogic.GetUser(1);
			user.Id = 10;
			var testUser = userLogic.GetUser(1);
			Assert.AreNotEqual(user.Id, testUser.Id, "createdUser update couset source user update.");
		}

		[TestMethod]
		public void CannotChangeUserByGetUsers()
		{
			var users = userLogic.GetUsers();
			users[1].Id = 10;
			var testUsers = userLogic.GetUsers();
			Assert.AreNotEqual(users[1].Id, testUsers[1].Id, "createdUser update couset source user update.");
		}
		[TestMethod]
		public void UpdateUserDAO()
		{
			try
			{
				userLogic.DeleteUserFromCache(2);
				userLogic.UpdateUserDAO();
			}
			catch (Exception)
			{
				Assert.Fail("method dont work");
			}

		}

	}
}
