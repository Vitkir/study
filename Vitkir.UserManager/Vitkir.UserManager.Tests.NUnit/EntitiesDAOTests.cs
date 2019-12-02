using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vitkir.UserManager.Common.Dependencies;
using Vitkir.UserManager.DAL.File;

namespace Vitkir.UserManager.Tests.NUnit
{
	[TestClass]
	public class EntitiesDAOTests
	{
		private readonly UserFileDAO userDAO;

		public EntitiesDAOTests()
		{
			userDAO = new UserFileDAO();
		}

		[TestMethod]
		public void GetEntities()
		{
			var entities = userDAO.GetEntities();
			Assert.IsNotNull(entities, "fail");
		}

		[TestMethod]
		public void ParseString()
		{
			var user = userDAO.ParseString("1:name:14.05.1994");
			Assert.IsNotNull(user, "fail");
		}
	}
}
