using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;
using System.Linq;
using Vitkir.UserManager.BLL.Contracts.Logic;
using Vitkir.UserManager.Common.Dependencies;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.Tests.NUnit
{
	[TestClass]
	public class EntitiesLogicTests
	{
		private readonly IKernel kernel;
		private readonly IUserLogic userLogic;
		private readonly IAwardLogic awardLogic;
		private readonly int userId = 1;
		private readonly int awardId = 1;

		public EntitiesLogicTests()
		{
			kernel = new StandardKernel(new DependencyManager());
			userLogic = kernel.Get<IUserLogic>();
			awardLogic = kernel.Get<IAwardLogic>();

		}

		[TestMethod]
		public void CannotUpdateUserByCreate()
		{
			User user = new User("name", new DateTime(1994, 05, 14));
			var createdUser = userLogic.Create(user);
			createdUser.Id = 10;
			Assert.AreNotEqual(user.Id, createdUser.Id, "createdUser update couset source user update.");
		}

		[TestMethod]
		public void CannotChangeUserByGetUser()
		{
			var user = userLogic.Get(userId);
			user.Id = 10;
			var testUser = userLogic.Get(1);
			Assert.AreNotEqual(user.Id, testUser.Id, "createdUser update couset source user update.");
		}

		[TestMethod]
		public void CannotChangeUserByGetUsers()
		{
			var users = userLogic.GetAll();
			users[1].Id = 10;
			var testUsers = userLogic.GetAll();
			Assert.AreNotEqual(users[1].Id, testUsers[1].Id, "createdUser update couset source user update.");
		}

		[TestMethod]
		public void AddRelation()
		{
			var relation = new Relation(userId, awardId);

			userLogic.AddAward(relation);
			Assert.IsTrue(userLogic.Get(userId).Awards.Contains(awardId));
		}

		[TestMethod]
		public void GetRelationEntity()
		{
			var collect1 = awardLogic.GetAll(1);
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
			userLogic.Delete(2);
			var dict1 = userLogic.GetAll();
			userLogic.UpdateDAO();
			var dict2 = userLogic.GetAll();
			Assert.AreNotEqual(dict1.Count, dict2.Count, "User deleted");
		}

		[TestMethod]
		public void DeleteRelation()
		{
			var relation = new Relation(userId, 3);
			userLogic.AddAward(relation);
			userLogic.RemoveAward(relation);
			Assert.IsFalse(awardLogic.GetAll(userId)
				.Where(award => award.Id == 3)
				.Select(award => award.Id)
				.ToList()
				.Contains(3));
		}
	}
}
