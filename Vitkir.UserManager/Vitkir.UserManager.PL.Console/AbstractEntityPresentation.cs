﻿using System;
using System.IO;
using Vitkir.UserManager.BLL.Logic;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManadger.PL.Console
{
	public abstract class AbstractEntityPresentation<T> : IEntityPresentation where T : Entity, ICloneable
	{
		protected readonly ILogic<T> entityLogic;

		protected AbstractEntityPresentation(ILogic<T> entitylogic)
		{
			entityLogic = entitylogic;
		}

		public abstract void CreateEntity();

		public void UpdateDatabase()
		{
			try
			{
				entityLogic.UpdateEntityDAO();

			}
			catch (IOException e)
			{
				System.Console.WriteLine(e.Message + ". Close file and try again.");
			}
			System.Console.WriteLine("success");
		}

		public void DeleteEntity()
		{
			int id = GetIdFromConsole();
			var returned = entityLogic.DeleteEntityFromCache(id);
			System.Console.WriteLine(returned != 0 ? nameof(T) + " id " + returned.ToString() + " deleted" : "unsuccessful");
		}

		public void GetEntity()
		{
			int id = GetIdFromConsole();
			System.Console.WriteLine("Input id");
			var entity = entityLogic.GetEntity(id);
			System.Console.WriteLine(entity != null ?
				nameof(T) + ": " + entity.ToString() : nameof(T) + " with such id does not exist");
		}

		public void GetAllentities()
		{
			var etities = entityLogic.GetEntities();
			foreach (var pair in etities)
			{
				System.Console.WriteLine(pair.Value.ToString());
			}
		}

		private int GetIdFromConsole()
		{
			int id;
			var input = System.Console.ReadLine();
			while (!int.TryParse(input, out id))
			{
				input = System.Console.ReadLine();
			}
			return id;
		}
	}
}
