using Ninject.Modules;
using Vitkir.UserManager.BLL.Contracts;
using Vitkir.UserManager.BLL.Logic;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;
using Vitkir.UserManager.DAL.File;

namespace Vitkir.UserManager.Common.Dependencies
{
	public class DependencyManager : NinjectModule
	{
		public override void Load()
		{
			Bind<IDAO<int,User>>().To<UserFileDAO>();
			Bind<IDAO<int, Award>>().To<AwardFileDAO>();
			Bind<IRelationDAO>().To<RelationsFileDAO>().InSingletonScope();
			Bind<ILogic<User>>().To<UserLogic>();
			Bind<ILogic<Award>>().To<AwardLogic>();
		}
	}
}
