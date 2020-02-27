using System.ComponentModel.DataAnnotations;

namespace Vitkir.UserManager.PL.WebApp.Models.Common
{
	public class AccountModel
	{
		[Required]
		[DataType(DataType.Text)]
		public string Login { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public AccountModel()
		{
		}

		public AccountModel(string login, string password)
		{
			Login = login;
			Password = password;
		}
	}
}