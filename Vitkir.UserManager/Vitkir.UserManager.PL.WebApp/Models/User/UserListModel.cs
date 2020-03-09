using System.ComponentModel.DataAnnotations;

namespace Vitkir.UserManager.PL.WebApp.Models.User
{
	public class UserListModel : AbstractUserModel
	{
		[ScaffoldColumn(false)]
		public int Id { get; set; }

		[DataType(DataType.Text)]
		[Display(Name = "Возраст")]
		public int Age { get; }

		public UserListModel(int id, string name, int age, string imgUrl) : base(name, imgUrl)
		{
			Id = id;
			Age = age;
		}
	}
}