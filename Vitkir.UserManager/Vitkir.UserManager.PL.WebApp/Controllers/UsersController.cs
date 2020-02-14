using System.Web.Mvc;
using Vitkir.UserManager.BLL.Contracts;

namespace Vitkir.UserManager.PL.WebApp.Controllers
{
	public class UsersController : Controller
	{
		private readonly IUserLogic userLogic;

		public UsersController(IUserLogic userLogic)
		{
			this.userLogic = userLogic;
		}

		public ActionResult Users()
		{
			return View();
		}

		public ActionResult Details(int id)
		{
			return View();
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			try
			{

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		public ActionResult Edit(int id)
		{
			return View();
		}

		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			try
			{

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		public ActionResult Delete(int id)
		{
			return View();
		}

		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
