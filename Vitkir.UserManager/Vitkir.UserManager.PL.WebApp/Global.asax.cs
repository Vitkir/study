using Ninject;
using Ninject.Web.Mvc;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Vitkir.UserManager.Common.Dependencies;

namespace Vitkir.UserManager.PL.WebApp
{
	public class MvcApplication : HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			var dependencyManager = new DependencyManager();
			var kernel = new StandardKernel(dependencyManager);
			DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
		}
	}
}
