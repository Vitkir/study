﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Vitkir.UserManager.PL.WebApp.Models.User
{
	public class UserCreationModel : AbstractUserModel
	{
		[Required]
		[DataType(DataType.Date)]
		[Display(Name = "День рождения")]
		public DateTime Birthday { get; set; }

		public UserCreationModel(
			int id, 
			string name, 
			DateTime birthday, 
			string imgUrl) : base(name, imgUrl, id)
		{
			Birthday = birthday;
		}

		public UserCreationModel()
		{
		}
	}
}