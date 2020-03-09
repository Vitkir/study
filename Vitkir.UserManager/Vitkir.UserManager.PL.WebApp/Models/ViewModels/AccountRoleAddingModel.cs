using System.Collections.Generic;
using Vitkir.UserManager.PL.WebApp.Models.Account;

namespace Vitkir.UserManager.PL.WebApp.Models.ViewModels
{
	public class AccountRoleAddingModel
	{
		public int SelectedId { get; set; }

		public IEnumerable<AccountListModel> Accounts { get; set; }

		public AccountRoleAddingModel()
		{
		}
	}
}