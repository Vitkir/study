using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vitkir.UserManager.BLL.Contracts.Logic;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.PL.WebApp.Models.Award;

namespace Vitkir.UserManager.PL.WebApp.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AwardsController : Controller
	{
		private readonly IAwardLogic awardLogic;

		public AwardsController(IAwardLogic awardLogic)
		{
			this.awardLogic = awardLogic;
		}

		[OverrideAuthorization]
		[Authorize(Roles = "Admin, User")]
		public ActionResult GetList()
		{
			var model = awardLogic.GetAll()
				.Select(e => new AwardModel(
					e.Value.Title,
					e.Value.Id));
			return View("AwardList", model);
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(AwardModel creationModel)
		{
			if (ModelState.IsValid)
			{
				var createdAward = new Award(creationModel.Title);
				awardLogic.Create(createdAward);
				return RedirectToAction("GetList");
			}
			return View(creationModel);
		}

		public ActionResult Delete(int id)
		{
			try
			{
				var award = awardLogic.Get(id);
				var awardModel = new AwardModel(award.Title, award.Id);
				return View(awardModel);
			}
			catch (KeyNotFoundException)
			{
				return HttpNotFound();
			}
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			try
			{
				var award = awardLogic.Get(id);
				awardLogic.Delete(id);
				awardLogic.UpdateDAO();
				return RedirectToAction("GetList");
			}
			catch (KeyNotFoundException)
			{
				return HttpNotFound();
			}
		}
	}
}
