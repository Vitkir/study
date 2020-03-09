using System;
using System.Web.Mvc;
using System.Web.Security;
using Vitkir.UserManager.BLL.Contracts.Logic;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.PL.WebApp.Models.Account
{
	public class DefaultRoleProvider : RoleProvider
	{
		private readonly IAccountLogic accountLogic;

		public DefaultRoleProvider()
			: this(accountLogic: DependencyResolver.Current.GetService<IAccountLogic>())
		{
		}

		public DefaultRoleProvider(IAccountLogic accountLogic)
		{
			this.accountLogic = accountLogic;
		}

		public override void AddUsersToRoles(string[] usernames, string[] roleNames)
		{
			
			throw new System.NotImplementedException();
		}

		public override string[] GetAllRoles()
		{
			return Enum.GetNames(typeof(Role));
		}

		public override string[] GetRolesForUser(string username)
		{
			Role role = GetRoleForUSer(username);
			return new string[] { Enum.GetName(typeof(Role), role) };
		}

		public override bool IsUserInRole(string username, string roleName)
		{
			var role = GetRoleForUSer(username);

			return roleName == Enum.GetName(typeof(Role), role);
		}

		private Role GetRoleForUSer(string username)
		{
			return accountLogic.Get(username).Role;
		}

		#region NotImplemented

		public override string ApplicationName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

		public override void CreateRole(string roleName)
		{
			throw new System.NotImplementedException();
		}

		public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
		{
			throw new System.NotImplementedException();
		}

		public override bool RoleExists(string roleName)
		{
			throw new System.NotImplementedException();
		}
		public override string[] FindUsersInRole(string roleName, string usernameToMatch)
		{
			throw new System.NotImplementedException();
		}

		public override string[] GetUsersInRole(string roleName)
		{
			throw new System.NotImplementedException();
		}

		public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
		{
			throw new System.NotImplementedException();
		}

		#endregion
	}
}