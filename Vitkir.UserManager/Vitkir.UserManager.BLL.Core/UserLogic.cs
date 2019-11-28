﻿using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.File;

namespace Vitkir.UserManager.BLL.Logic
{
	public class UserLogic : EntityLogic<User>
	{
		public UserLogic(UserDAO userDAO) : base(userDAO)
		{

		}
	}
}
