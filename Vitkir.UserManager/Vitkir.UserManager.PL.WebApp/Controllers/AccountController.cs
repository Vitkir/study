using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Vitkir.UserManager.BLL.Contracts.Logic;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.PL.WebApp.Models.Account;
using Vitkir.UserManager.PL.WebApp.Models.ViewModels;

namespace Vitkir.UserManager.PL.WebApp.Controllers
{
	public class AccountController : Controller
	{
		private readonly IAccountLogic accountLogic;
		private readonly RoleProvider roleProvider;

		public AccountController(IAccountLogic accountLogic, DefaultRoleProvider roleProvider)
		{
			this.accountLogic = accountLogic;
			this.roleProvider = roleProvider;
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
		public ActionResult Registration([Bind(Include = "Login, Password")] AccountCreationModel model,
			string returnUrl)
		{
			if (ModelState.IsValid && !accountLogic.AccountExist(model.Login))
			{
				var account = new Account(model.Login, model.Password)
				{
					Role = Role.User,
				};
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
		public ActionResult Login([Bind(Include = "Login, Password")] AccountCreationModel model,
			string returnUrl)
		{
			if (ModelState.IsValid && accountLogic.AccountExist(model.Login))
			{
				var account = accountLogic.Get(model.Login);
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
		[Authorize]
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

		[Authorize(Roles = "Admin")]
		public ActionResult Details([Bind(Include = "SelectedId")]AccountRoleAddingModel model)
		{
			var account = accountLogic.Get(model.SelectedId);
			var returnedModel = new AccountListModel(account.Login)
			{
				Id = account.Id,
				Role = account.Role,
			};
			return PartialView("_DetailsAccountPartial", returnedModel);
		}

		[Authorize(Roles = "Admin")]
		public ActionResult ChangeRole()
		{
			var accounts = accountLogic.GetAll().Values
				.Where(e => e.Login != User.Identity.Name)
				.Select(e => new AccountListModel(e.Login)
				{
					Id = e.Id,
					Role = e.Role
				});
			var model = new AccountRoleAddingModel()
			{
				Accounts = accounts
			};
			return View("AdminPage", model);
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		[ValidateAntiForgeryToken]
		public ActionResult ChangeRole([Bind(Include = "Id, Role")]AccountListModel model)
		{
			var account = accountLogic.Get(model.Id);
			account.Role = model.Role;
			accountLogic.Create(account);

			return RedirectToAction("ChangeRole");
		}
	}
}