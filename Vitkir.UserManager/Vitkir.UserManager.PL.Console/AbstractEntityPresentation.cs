using System;
using System.Collections.Generic;
using System.IO;
using Vitkir.UserManadger.PL.Contracts;
using Vitkir.UserManager.BLL.Contracts.Logic;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManadger.PL.Console
{
	public abstract class AbstractEntityPresentation<TEntity> : IEntityPresentation
		where TEntity : IEntity<int>, IEquatable<TEntity>
	{
		protected readonly ILogic<int, TEntity> entityLogic;

		protected AbstractEntityPresentation(ILogic<int, TEntity> entitylogic)
		{
			entityLogic = entitylogic;
		}

		public abstract void Create();

		public void Delete(int id)
		{
			var returned = entityLogic.Delete(id);
			System.Console.WriteLine(returned == true ? nameof(TEntity) + " id " + returned.ToString() + " deleted" : "unsuccessful");
		}

		public void Get(int id)
		{
			try
			{
				var entity = entityLogic.Get(id);
				System.Console.WriteLine(nameof(TEntity) + ": " + entity.ToString());
			}
			catch (KeyNotFoundException)
			{
				System.Console.WriteLine(nameof(TEntity) + " with such id does not exist");
			}
		}

		public void Update()
		{
			try
			{
				entityLogic.UpdateDAO();
			}
			catch (IOException e)
			{
				System.Console.WriteLine(e.Message + ". Close file and try again.");
			}
			System.Console.WriteLine("success");
		}

		public void GetAll()
		{
			var etities = entityLogic.GetAll();
			foreach (var entity in etities.Values)
			{
				System.Console.WriteLine(entity.ToString());
			}
		}
	}
}
