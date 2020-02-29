using System.Web.Mvc;
using System.Web.Security;
using Vitkir.UserManager.BLL.Contracts.Logic;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.PL.WebApp.Models.Account;

namespace Vitkir.UserManager.PL.WebApp.Controllers
{
	public class AccountController : Controller
	{
		private readonly IAccountLogic accountLogic;

		public AccountController(IAccountLogic accountLogic)
		{
			this.accountLogic = accountLogic;
		}

		public ActionResult Registration(string returnUrl)
		{
			if (!string.IsNullOrWhiteSpace(returnUrl))
			{
				ViewBag.returnUrl = returnUrl;
			}
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Registration(AccountModel model, string returnUrl)
		{
			if (ModelState.IsValid && !accountLogic.AccountExist(model.Id))
			{
				var account = new Account(model.Login, model.Password);
				accountLogic.Create(account);

				return RedirectToAction("Login", routeValues: returnUrl);
			}
			TempData["Error message"] = "Such login exist";
			return View(model);
		}

		public ActionResult Login(string returnUrl)
		{
			if (!string.IsNullOrWhiteSpace(returnUrl))
			{
				ViewBag.returnUrl = returnUrl;
			}
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(AccountModel model, string returnUrl)
		{
			if (ModelState.IsValid && accountLogic.AccountExist(model.Id))
			{
				var account = accountLogic.Get(model.Id);
				if ((account.Login, account.Password) == (model.Login, model.Password))
				{
					FormsAuthentication.SetAuthCookie(model.Login, true);
					if (string.IsNullOrWhiteSpace(returnUrl))
					{
						return Redirect("~");
					}
					return Redirect(returnUrl);
				}
			}
			TempData["Error message"] = "Uncorrect login or password";
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Logout()
		{
			FormsAuthentication.SignOut();
			return Redirect("~");
		}

		[ChildActionOnly]
		public ActionResult AccountInfo()
		{
			var userName = (User != null && User.Identity.IsAuthenticated)
		? User.Identity.Name
		: null;
			if (userName != null)
			{
				return PartialView("_AuthenticatedAccountPartial", userName);
			}
			return PartialView("_GuestAccountPartial");
		}
	}
}