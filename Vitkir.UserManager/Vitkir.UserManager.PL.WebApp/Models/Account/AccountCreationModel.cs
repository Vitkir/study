using System.ComponentModel.DataAnnotations;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.PL.WebApp.Models.Account
{
	public class AccountCreationModel
	{
		[Required]
		[DataType(DataType.Text)]
		public string Login { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public Role Role { get; set; }

		public AccountCreationModel()
		{
		}

		public AccountCreationModel(string login, string password)
		{
			Login = login;
			Password = password;
		}
	}
}