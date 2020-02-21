using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vitkir.UserManager.BLL.Contracts;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.PL.WebApp.Models.Award;
using Vitkir.UserManager.PL.WebApp.Models.User;
using Vitkir.UserManager.PL.WebApp.Models.ViewModels;

namespace Vitkir.UserManager.PL.WebApp.Controllers
{
	public class UsersController : Controller
	{
		private readonly IUserLogic userLogic;
		private readonly IAwardLogic awardLogic;

		public UsersController(IUserLogic userLogic, IAwardLogic awardLogic)
		{
			this.userLogic = userLogic;
			this.awardLogic = awardLogic;
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

		public ActionResult Details(int id)
		{
			try
			{
				var user = userLogic.Get(id);
				var img = userLogic.GetImage(user.ImgId);
				var relatedAwards = user.Awards
					.Select(e => awardLogic.Get(e))
					.Select(e => new AwardModel(e.Title, e.Id))
					.ToList();
				var availableAwards = awardLogic.GetAll().Values
					.Select(e => new AwardModel(e.Title, e.Id))
					.ToList();
				var model = new UserAwardAddingModel(
					user.Id,
					user.Name,
					img.ImgUrl,
					user.Birthday,
					relatedAwards,
					availableAwards);
				return View(model);
			}
			catch (KeyNotFoundException)
			{
				return HttpNotFound();
			}
		}

		[HttpPost]
		public ActionResult AddAward(UserAwardAddingModel model)
		{
			try
			{
				var relation = new Relation(model.Id, model.SelectedAward);
				userLogic.AddAward(relation);
				return View("Details", model);
			}
			catch (KeyNotFoundException)
			{
				return HttpNotFound();
			}
			catch (ArgumentException)
			{
				return HttpNotFound();
			}
		}

		[HttpPost]
		public ActionResult RemoveAward(UserAwardAddingModel model)
		{
			try
			{
				var relation = new Relation(model.Id, model.SelectedAward);
				userLogic.RemoveAward(relation);
				return View("Details", model);
			}
			catch (KeyNotFoundException)
			{
				return HttpNotFound();
			}
			catch (ArgumentException)
			{
				return HttpNotFound();
			}
		}
	}
}
