using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vitkir.UserManager.BLL.Contracts;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.PL.WebApp.Models.Award;
using Vitkir.UserManager.PL.WebApp.Models.ViewModels;

namespace Vitkir.UserManager.PL.WebApp.Controllers
{
	public class UserDetailsController : Controller
	{
		private readonly IUserLogic userLogic;
		private readonly IAwardLogic awardLogic;

		public UserDetailsController(IUserLogic userLogic, IAwardLogic awardLogic)
		{
			this.userLogic = userLogic;
			this.awardLogic = awardLogic;
		}

		public ActionResult Details(int id)
		{
			try
			{
				var user = userLogic.Get(id);
				var relatedAwards = user.RelatedAwards
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
					availableAwards);
				return View(model);
			}
			catch (KeyNotFoundException)
			{
				return HttpNotFound();
			}
		}

		public ActionResult AddAward(int id)
		{
			try
			{
				var user = userLogic.Get(id);
				var model = awardLogic.GetAll()
				.Select(e => new AwardModel(
					e.Value.Title,
					e.Value.Id));
				return View("AddAward", model);
			}
			catch (KeyNotFoundException)
			{
				return HttpNotFound();
			}
		}

		[HttpPost, ActionName("AddAward")]
		public ActionResult AddAward(UserAwardAddingModel model)
		{
			try
			{
				var relation = new Relation(model.Id, model.SelectedAward);
				userLogic.AddAward(relation);
				return Details(model.Id);
			}
			catch (KeyNotFoundException)
			{
				return HttpNotFound();
			}
		}
	}
}