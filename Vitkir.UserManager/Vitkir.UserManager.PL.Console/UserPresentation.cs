using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using Vitkir.UserManager.BLL.Contracts.Logic;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManadger.PL.Console
{
	public class UserPresentation : AbstractEntityPresentation<User>
	{
		public UserPresentation(IUserLogic userlogic) : base(userlogic)
		{
		}

		public override void Create()
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
				returned = entityLogic.Create(user).Id;
			}
			catch (IOException e)
			{
				System.Console.WriteLine(e.Message + ". Close file and try again.");
			}
			System.Console.WriteLine("success. User id: " + returned.ToString());
		}

		public void AddAward(int userId, int awardId)
		{
			var relation = new Relation(userId, awardId);
			Relation createdRelation = default;

			try
			{
				createdRelation = (entityLogic as IUserLogic).AddAward(relation);
			}
			catch (IOException e)
			{
				System.Console.WriteLine(e.Message + ". Close file and try again.");
			}
			System.Console.WriteLine(createdRelation != null ?
				"Relation user " + createdRelation.FirstId +
				" and award " + createdRelation.SecondId + " created" : "unsuccessful");
		}

		public void RemoveAward(int userId, int awardId)
		{
			var relation = new Relation(userId, awardId);
			var returned = (entityLogic as IUserLogic).RemoveAward(relation);

			System.Console.WriteLine(returned == true ?
				"user " + userId.ToString() +
				" and award " + awardId.ToString() + " award deleted" : "unsuccessful");
		}

		public void RemoveAllAwardsUser(int userId)
		{
			var returned = (entityLogic as IUserLogic).RemoveAllAwardsUser(userId);
			System.Console.WriteLine(returned == true ?
				"Awards remove" : "unsuccessful");
		}

		public void RemoveAwardAllUsers(int awardId)
		{
			var returned = (entityLogic as IUserLogic).RemoveAwardAllUsers(awardId);
			System.Console.WriteLine(returned == true ?
				"Award remove" : "unsuccessful");
		}
	}
}
