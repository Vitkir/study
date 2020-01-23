using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using Vitkir.UserManager.BLL.Logic;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManadger.PL.Console
{
	public class UserPresentation : AbstractEntityPresentation<User>
	{
		public UserPresentation(ILogic<User> userlogic) : base(userlogic)
		{

		}

		public override void CreateEntity()
		{
			System.Console.WriteLine("Input name");
			var pattern = new Regex("^[a-z]{1,15}$");
			var name = System.Console.ReadLine();
			while (!pattern.IsMatch(name))
			{
				name = System.Console.ReadLine();
			}

			var info = CultureInfo.InvariantCulture;
			var style = DateTimeStyles.None;
			var formate = "yyyy.MM.dd";
			System.Console.WriteLine("Input birthday in formate " + formate);
			DateTime birthday;
			var input = System.Console.ReadLine();
			while (!DateTime.TryParseExact(input, formate, info, style, out birthday))
			{
				input = System.Console.ReadLine();
			}

			var user = new User(name, birthday);
			int returned = default;
			try
			{
				returned = entityLogic.CreateEntity(user).Id;
			}
			catch (IOException e)
			{
				System.Console.WriteLine(e.Message + ". Close file and try again.");
			}
			System.Console.WriteLine("success. User id: " + returned.ToString());
		}

		public class RelationsPresentation : IEntityPresentation
		{
			private UserPresentation parent;

			public RelationsPresentation(UserPresentation parent)
			{
				this.parent = parent;
			}

			public void CreateEntity()
			{
				var userId = parent.GetIdFromConsole();
				var awardId = parent.GetIdFromConsole();
				var relation = new Relation(userId, awardId);
				Relation createdRelation = null;

				try
				{
					createdRelation = CastingEntityLogicToIRelationLogic().CreateRelation(relation);
				}
				catch (IOException e)
				{
					System.Console.WriteLine(e.Message + ". Close file and try again.");
				}
				System.Console.WriteLine(createdRelation != null ?
					"Relation user " + createdRelation.UserId +
					" and award " + createdRelation.AwardId + " created" : "unsuccessful");
			}

			public void DeleteEntity()
			{
				var userId = parent.GetIdFromConsole();
				var awardId = parent.GetIdFromConsole();
				var returned = CastingEntityLogicToIRelationLogic().DeleteRelationEntity(userId, awardId);

				System.Console.WriteLine(returned != null ?
					"user " + returned.Item1.ToString() +
					" and award " + returned.Item2.ToString() + " relation deleted" : "unsuccessful");
			}

			public void GetAllentities()
			{
				int userId = parent.GetIdFromConsole();
				var awards = CastingEntityLogicToIRelationLogic().GetRelatedEntities(userId);
				if (awards == null)
				{
					System.Console.WriteLine("user" + userId.ToString() + "doesn't exists relations");
					return;
				}
				foreach (var award in awards)
				{
					System.Console.WriteLine(award.ToString());
				}
			}

			public void GetEntity()
			{
				var userId = parent.GetIdFromConsole();
				var awardId = parent.GetIdFromConsole();
				var flag = parent.entityLogic.GetEntity(userId).RelatedAwards.Contains(awardId);

				System.Console.WriteLine(flag ?
					"user " + userId.ToString() + " contains award " + awardId.ToString() : "does not contains");
			}

			public void UpdateDatabase()
			{
				try
				{
					CastingEntityLogicToIRelationLogic().UpdateRelationsDAO();
				}
				catch (IOException e)
				{
					System.Console.WriteLine(e.Message + ". Close file and try again.");
				}
				System.Console.WriteLine("success");
			}

			private IRelationLogic CastingEntityLogicToIRelationLogic()
			{
				return (parent.entityLogic as IRelationLogic);
			}

		}
	}
}
