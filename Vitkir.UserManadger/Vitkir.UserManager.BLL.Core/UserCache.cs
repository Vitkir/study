using System;
using System.Collections.Generic;
using Vitkir.UserManager.CommonEntities;
using Vitkir.UserManager.DAL.Abstract;

namespace Vitkir.UserManager.BLL.Core
{
	public class UserCache : IDAO
	{
		private List<User> users;
		private int len;

		public void Assign()
		{
			throw new NotImplementedException();
		}

		public int Create(User user)
		{
			user.Id = ++len;
			users.Add(user);
			return user.Id;
		}

		public int Delete(int id)
		{
			if (id <= 0 || id > len)
			{
				return 0;
			}
			else
			{
				users.RemoveAt(id);
				return id;
			}
		}

		public IEnumerable<User> Get(int id)
		{
			foreach (var user in users)
			{
				if (user.Id == id)
				{
					yield return user;
				}
			}
		}

		public IEnumerable<User> GetAll()
		{
			foreach (var user in users)
			{
				yield return user;
			}
		}

		public UserCache()
		{
			users = new List<User>();
			len = users.Count;
		}
	}
}
