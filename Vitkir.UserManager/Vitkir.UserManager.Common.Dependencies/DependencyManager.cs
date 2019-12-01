﻿using Ninject.Modules;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;
using Vitkir.UserManager.DAL.File;

namespace Vitkir.UserManager.Common.Dependencies
{
	public class DependencyManager : NinjectModule
	{
		public override void Load()
		{
			Bind<IDAO<User>>().To<UserFileDAO>();
		}
	}
}
