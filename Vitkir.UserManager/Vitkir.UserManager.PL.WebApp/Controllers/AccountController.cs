using System.Web.Mvc;
using System.Web.Security;
using Vitkir.UserManager.PL.WebApp.Models.Common;

namespace Vitkir.UserManager.PL.WebApp.Controllers
{
	public class AccountController : Controller
	{
		//private readonly IAccountLogic accountLogic;

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
			if (ModelState.IsValid/* && accountLogic.Login*/)
			{
				FormsAuthentication.SetAuthCookie(model.Login, true);
				if (string.IsNullOrWhiteSpace(returnUrl))
				{
					return Redirect("~");
				}
				return Redirect(returnUrl);
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