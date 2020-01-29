using System;
using System.IO;
using Vitkir.UserManadger.PL.Contracts;
using Vitkir.UserManager.BLL.Contracts;
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

		public void Delete()
		{
			int id = GetIdFromConsole();
			var returned = entityLogic.Delete(id);
			System.Console.WriteLine(returned == true ? nameof(TEntity) + " id " + returned.ToString() + " deleted" : "unsuccessful");
		}

		public void Get()
		{
			int id = GetIdFromConsole();
			try
			{
				var entity = entityLogic.Get(id);
				System.Console.WriteLine(nameof(TEntity) + ": " + entity.ToString());
			}
			catch (IndexOutOfRangeException)
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
			foreach (var entity in etities)
			{
				System.Console.WriteLine(entity.ToString());
			}
		}

		protected int GetIdFromConsole()
		{
			int id;
			System.Console.WriteLine("Input id");
			var input = System.Console.ReadLine();
			while (!int.TryParse(input, out id))
			{
				System.Console.WriteLine("Incorrect input");
				input = System.Console.ReadLine();
			}
			return id;
		}
	}
}
