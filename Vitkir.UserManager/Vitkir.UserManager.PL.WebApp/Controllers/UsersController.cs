using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;
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
					e.Value.Age,
					e.Value.ImgId > 0 ? userLogic.GetImage(e.Value.ImgId).ImgUrl : null));
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
				HttpPostedFileBase file = Request.Files["Picture"];
				Image img = null;
				if (file != null && file.ContentLength > 0)
				{
					var fileName = Path.GetFileName(file.FileName);
					var path = "~/Content/Img/" + fileName;
					file.SaveAs(Server.MapPath(path));
					img = new Image(path);
				}
				var createdUser = new User(creationModel.Name, creationModel.Birthday)
				{
					ImgId = userLogic.AddImg(img)
				};
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
				var userModel = new UserListModel(
					user.Id,
					user.Name,
					user.Age,
					user.ImgId > 0 ? userLogic.GetImage(user.ImgId).ImgUrl : null);
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
				var img = user.ImgId > 0 ? userLogic.GetImage(user.ImgId).ImgUrl : null;
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
					user.Birthday,
					relatedAwards,
					availableAwards,
					img);
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
