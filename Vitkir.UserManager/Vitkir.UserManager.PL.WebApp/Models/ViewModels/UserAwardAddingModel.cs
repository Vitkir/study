using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Vitkir.UserManager.PL.WebApp.Models.Award;
using Vitkir.UserManager.PL.WebApp.Models.User;

namespace Vitkir.UserManager.PL.WebApp.Models.ViewModels
{
	public class UserAwardAddingModel : AbstractUserModel
	{
		private List<AwardModel> availableAwards;

		[ScaffoldColumn(false)]
		public int Id { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "День рождения")]
		public DateTime Birthday { get; set; }

		[DataType(DataType.Text)]
		[Display(Name = "Возраст")]
		public int Age
		{
			get
			{
				DateTime dateNow = DateTime.Now;
				var age = dateNow.Year - Birthday.Year;
				if (dateNow.Month < Birthday.Month ||
					(dateNow.Month == Birthday.Month && dateNow.Day < Birthday.Day))
				{
					age--;
				}
				return age;
			}
		}

		[Display(Name = "Список наград пользователя")]
		public List<AwardModel> RelatedAwards { get; set; }

		[Display(Name = "Список доступных наград")]
		public List<AwardModel> AvailableAwards
		{
			get => availableAwards?
				.Where(e => !RelatedAwards.Any(r => r.Id == e.Id))
				.ToList();
			set
			{
				availableAwards = value;
			}
		}

		public int SelectedAward { get; set; }

		public UserAwardAddingModel()
		{
		}

		public UserAwardAddingModel(
			int id,
			string name,
			DateTime birthday,
			List<AwardModel> relatedAwards,
			List<AwardModel> availableAwards,
			string imgUrl) : base(name, imgUrl)
		{
			Id = id;
			Birthday = birthday;
			RelatedAwards = relatedAwards;
			AvailableAwards = availableAwards;
		}
	}
}