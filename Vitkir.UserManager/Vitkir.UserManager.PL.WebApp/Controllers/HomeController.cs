using System.Web.Mvc;

namespace Vitkir.UserManager.PL.WebApp.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Users()
		{
			return View();
		}

		public ActionResult Awards()
		{
			return View();
		}
	}
}