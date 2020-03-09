using Ninject.Modules;
using System.Configuration;
using Vitkir.UserManager.BLL.Contracts.Cache;
using Vitkir.UserManager.BLL.Contracts.Logic;
using Vitkir.UserManager.BLL.Logic;
using Vitkir.UserManager.BLL.Logic.Cache;
using Vitkir.UserManager.Common.Dependencies.ConfigurationSettings;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;
using Vitkir.UserManager.DAL.File;

namespace Vitkir.UserManager.Common.Dependencies
{
	public class DependencyManager : NinjectModule
	{
		private readonly FilePathConfigSection configSection = (FilePathConfigSection)ConfigurationManager.GetSection("FileDALConfiguration");

		public override void Load()
		{
			Bind<IUserLogic>().To<UserLogic>().InSingletonScope();
			Bind<IAwardLogic>().To<AwardLogic>().InSingletonScope();
			Bind<IAccountLogic>().To<AccountLogic>().InSingletonScope();

			Bind<ICache>().To<RelationsCache>().InSingletonScope();
			Bind<IUsersAwardsRelationsCache>().To<UsersAwardsRelationsCache>().InSingletonScope();

			Bind<IDAO<int, User>>().To<UserFileDAO>().InSingletonScope()
				.WithConstructorArgument("entityFilePath", configSection.PathsCollections["usersDataFilePath"].Path)
				.WithConstructorArgument("tmpFilePath", configSection.PathsCollections["userstmpFilePath"].Path);
			Bind<IDAO<int, Award>>().To<AwardFileDAO>().InSingletonScope()
				.WithConstructorArgument("entityFilePath", configSection.PathsCollections["awardsDataFilePath"].Path)
				.WithConstructorArgument("tmpFilePath", configSection.PathsCollections["awardstmpFilePath"].Path);
			Bind<IDAO<int, Image>>().To<ImgFileDAO>().InSingletonScope()
				.WithConstructorArgument("entityFilePath", configSection.PathsCollections["imgsUrlFilePath"].Path)
				.WithConstructorArgument("tmpFilePath", configSection.PathsCollections["imgsUrltmpFilePath"].Path);
			Bind<IDAO<int, Account>>().To<AccountFileDAO>().InSingletonScope()
				.WithConstructorArgument("entityFilePath", configSection.PathsCollections["accountsDataFilePath"].Path)
				.WithConstructorArgument("tmpFilePath", configSection.PathsCollections["accountstmpFilePath"].Path);
			Bind<IRelationDAO>().To<RelationsFileDAO>().InSingletonScope()
				.WithConstructorArgument("entityFilePath", configSection.PathsCollections["relationsFilePath"].Path)
				.WithConstructorArgument("tmpFilePath", configSection.PathsCollections["relationstmpFilePath"].Path);
		}
	}
}
