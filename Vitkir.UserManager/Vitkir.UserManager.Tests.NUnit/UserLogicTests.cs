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
		public void CannotUpdateUserByGet()
		{
			User user = new User("name", new DateTime(1994, 05, 14));
			var createdUser = userLogic.CreateUser(user);
			createdUser.Id = 10;
			Assert.AreNotEqual(user.Id, createdUser.Id, "createdUser update couset source user update.");
		}

		
	}
}
