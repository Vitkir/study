using Ninject.Modules;
using System.Configuration;
using Vitkir.UserManager.BLL.Contracts;
using Vitkir.UserManager.BLL.Logic;
using Vitkir.UserManager.Common.Dependencies.ConfigurationSettings;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;
using Vitkir.UserManager.DAL.File;

namespace Vitkir.UserManager.Common.Dependencies
{
	public class DependencyManager : NinjectModule
	{
		private readonly FilePathConfigSection configSection = (FilePathConfigSection)ConfigurationManager.GetSection("Paths");

		public override void Load()
		{
			Bind<IDAO<int, User>>().To<UserFileDAO>()
				.WithConstructorArgument("entityFilePath", configSection.PathsCollections["usersDataFilePath"])
				.WithConstructorArgument("tmpFilePath", configSection.PathsCollections["userstmpFilePath"]);
			Bind<IDAO<int, Award>>().To<AwardFileDAO>()
				.WithConstructorArgument("entityFilePath", configSection.PathsCollections["awardsDataFilePath"])
				.WithConstructorArgument("tmpFilePath", configSection.PathsCollections["awardstmpFilePath"]);
			Bind<IRelationDAO>().To<RelationsFileDAO>().InSingletonScope()
				.WithConstructorArgument("entityFilePath", configSection.PathsCollections["relationsFilePath"])
				.WithConstructorArgument("tmpFilePath", configSection.PathsCollections["relationstmpFilePath"]);
			Bind<ICache>().To<RelationCache>().InSingletonScope();
			Bind<IUserLogic>().To<UserLogic>();
			Bind<IAwardLogic>().To<AwardLogic>();
		}
	}
}
