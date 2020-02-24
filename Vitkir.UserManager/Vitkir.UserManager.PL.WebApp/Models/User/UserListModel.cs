using System.ComponentModel.DataAnnotations;

namespace Vitkir.UserManager.PL.WebApp.Models.User
{
	public class UserListModel : AbstractUserModel
	{
		[DataType(DataType.Text)]
		[Display(Name = "Возраст")]
		public int Age { get; }

		public UserListModel(int id, string name, int age, string imgUrl) : base(name, imgUrl, id)
		{
			Age = age;
		}
	}
}