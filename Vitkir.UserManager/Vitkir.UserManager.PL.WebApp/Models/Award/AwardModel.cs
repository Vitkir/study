using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Vitkir.UserManager.PL.WebApp.Models.Award
{
	public class AwardModel
	{
		[HiddenInput(DisplayValue = false)]
		public int Id { get; }

		[Required]
		[Display(Name = "Текст награды")]
		[DataType(DataType.Text)]
		[RegularExpression(@"[A-z]+",
			ErrorMessage = "Latin letters only"), 
			StringLength(20, MinimumLength = 10, ErrorMessage = "Min length 10, max length 20")]
		public string Title { get; set; }

		public AwardModel(string title, int id = 0)
		{
			Id = id;
			Title = title;
		}

		public AwardModel()
		{
		}
	}
}