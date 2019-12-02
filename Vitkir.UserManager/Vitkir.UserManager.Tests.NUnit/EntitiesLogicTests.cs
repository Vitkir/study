using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Vitkir.UserManager.BLL.Logic;
using Vitkir.UserManager.Common.Dependencies;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.Tests.NUnit
{
	[TestClass]
	public class EntitiesLogicTests
	{
		private readonly IKernel kernel;
		private readonly UserLogic userLogic;

		public EntitiesLogicTests()
		{
			kernel = new StandardKernel(new DependencyManager());
			userLogic = kernel.Get<UserLogic>();
		}

		[TestMethod]
		public void CannotUpdateUserByCreate()
		{
			User user = new User("name", new DateTime(1994, 05, 14));
			var createdUser = userLogic.CreateEntity(user);
			createdUser.Id = 10;
			Assert.AreNotEqual(user.Id, createdUser.Id, "createdUser update couset source user update.");
		}

		[TestMethod]
		public void CannotChangeUserByGetUser()
		{
			var user = userLogic.GetEntity(1);
			user.Id = 10;
			var testUser = userLogic.GetEntity(1);
			Assert.AreNotEqual(user.Id, testUser.Id, "createdUser update couset source user update.");
		}

		[TestMethod]
		public void CannotChangeUserByGetUsers()
		{
			var users = userLogic.GetEntities();
			users[1].Id = 10;
			var testUsers = userLogic.GetEntities();
			Assert.AreNotEqual(users[1].Id, testUsers[1].Id, "createdUser update couset source user update.");
		}

		[TestMethod]
		public void UpdateUserDAO()
		{
			try
			{
				userLogic.DeleteEntityFromCache(2);
				userLogic.UpdateEntityDAO();
			}
			catch (Exception)
			{
				Assert.Fail("method dont work");
			}
		}
	}
}
