using System.ComponentModel.DataAnnotations;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.PL.WebApp.Models.Account
{
	public class AccountListModel
	{
		[ScaffoldColumn(false)]
		public int Id { get; set; }

		[Required]
		[DataType(DataType.Text)]
		[Display(Name = "Логин")]
		public string Login { get; set; }

		[DataType(DataType.Text)]
		[Display(Name = "Статус")]
		public Role Role { get; set; }

		public AccountListModel()
		{
		}

		public AccountListModel(string login)
		{
			Login = login;
		}
	}
}