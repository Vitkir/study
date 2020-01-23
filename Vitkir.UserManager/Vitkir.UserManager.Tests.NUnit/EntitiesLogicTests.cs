using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;
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
		private int userId = 1;
		private int awardId = 1;

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
			var user = userLogic.GetEntity(userId);
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
		public void AddRelation()
		{
			var relation = new Relation(userId, awardId);

			userLogic.CreateRelation(relation);
			Assert.IsTrue(userLogic.GetEntity(userId).RelatedAwards.Contains(awardId));
		}

		[TestMethod]
		public void GetRelationEntity()
		{
			var collect1 = userLogic.GetRelatedEntities(1);
			try
			{
				Assert.IsNotNull(collect1);
			}
			catch (NullReferenceException)
			{
			}
		}

		[TestMethod]
		public void UpdateUserDAO()
		{
			userLogic.DeleteEntityFromCache(2);
			var dict1 = userLogic.GetEntities();
			userLogic.UpdateEntityDAO();
			var dict2 = userLogic.GetEntities();
			Assert.AreNotEqual(dict1.Count, dict2.Count, "User deleted");
		}

		[TestMethod]
		public void DeleteRelation()
		{
			userLogic.CreateRelation(new Relation(1, 3));
			userLogic.DeleteRelationEntity(userId, 3);
			Assert.IsFalse(userLogic.GetRelatedEntities(userId).Contains(3));
		}
	}
}
