using System.ComponentModel.DataAnnotations;

namespace Vitkir.UserManager.PL.WebApp.Models.User
{
	public abstract class AbstractUserModel
	{
		[Required]
		[Display(Name = "Имя")]
		[DataType(DataType.Text)]
		[RegularExpression(
			@"[A-z]+", ErrorMessage = "Latin letters only"), 
			StringLength(10, MinimumLength = 2, ErrorMessage = "Min length 3, max length 10")]
		public string Name { get; set; }

		public string ImgUrl { get; set; }

		public AbstractUserModel(
			string name, 
			string imgUrl)
		{
			Name = name;
			ImgUrl = imgUrl ?? "~/Content/Img/mock.jpg";
		}

		public AbstractUserModel()
		{
		}
	}
}