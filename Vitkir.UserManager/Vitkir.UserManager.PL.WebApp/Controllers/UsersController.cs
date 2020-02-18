using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vitkir.UserManager.BLL.Contracts;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.PL.WebApp.Models.User;

namespace Vitkir.UserManager.PL.WebApp.Controllers
{
	public class UsersController : Controller
	{
		private readonly IUserLogic userLogic;

		public UsersController(IUserLogic userLogic)
		{
			this.userLogic = userLogic;
		}

		public ActionResult GetList()
		{
			var model = userLogic.GetAll()
				.Select(e => new UserListModel(
					e.Value.Id,
					e.Value.Name,
					e.Value.Age));
			return View("UserList", model);
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(UserCreationModel creationModel)
		{
			if (ModelState.IsValid)
			{
				var createdUser = new User(creationModel.Name, creationModel.Birthday);
				userLogic.Create(createdUser);
				return RedirectToAction("GetList");
			}
			return View(creationModel);
		}

		public ActionResult Delete(int id)
		{
			try
			{
				var user = userLogic.Get(id);
				var userModel = new UserListModel(user.Id, user.Name, user.Age);
				return View(userModel);
			}
			catch (KeyNotFoundException)
			{
				return HttpNotFound();
			}
		}

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			try
			{
				var user = userLogic.Get(id);
				userLogic.Delete(id);
				userLogic.UpdateDAO();
				return RedirectToAction("GetList");
			}
			catch (KeyNotFoundException)
			{
				return HttpNotFound();
			}
		}
	}
}
