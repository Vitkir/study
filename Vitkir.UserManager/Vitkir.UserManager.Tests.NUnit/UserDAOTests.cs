using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vitkir.UserManager.DAL.File;

namespace Vitkir.UserManager.Tests.NUnit
{
	[TestClass]
	public class UserDAOTests
	{
		private readonly UserDAO userDAO;

		public UserDAOTests()
		{
			userDAO = new UserDAO();
		}

		[TestMethod]
		public void ParseUserFromString()
		{
			var user = userDAO.ParseString("1:name:14.05.1994:25");
			Assert.IsNotNull(user, "string cannot parse");
		}
	}
}
