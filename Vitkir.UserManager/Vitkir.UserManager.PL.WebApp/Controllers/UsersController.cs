using System.Linq;
using System.Web.Mvc;
using Vitkir.UserManager.BLL.Contracts;
using Vitkir.UserManager.PL.WebApp.Models;

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
			var model = userLogic.GetAll()
				.Select(e => new UserModel()
				{
					Id = e.Value.Id,
					Name = e.Value.Name,
					Birthday = e.Value.Birthday,
					RelatedAwards = e.Value.RelatedAwards,
				});
			return View(model);
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

				return RedirectToAction("Users");
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

				return RedirectToAction("Users");
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

				return RedirectToAction("Users");
			}
			catch
			{
				return View();
			}
		}
	}
}
