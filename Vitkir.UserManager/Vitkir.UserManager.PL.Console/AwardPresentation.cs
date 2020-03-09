using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Vitkir.UserManager.BLL.Contracts;
using Vitkir.UserManager.BLL.Contracts.Logic;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManadger.PL.Console
{
	public class AwardPresentation : AbstractEntityPresentation<Award>
	{
		public AwardPresentation(IAwardLogic awardlogic) : base(awardlogic)
		{
		}

		public override void Create()
		{
			System.Console.WriteLine("Input tytle");
			var pattern = new Regex("^.{1,40}$");
			var tytle = System.Console.ReadLine();
			while (!pattern.IsMatch(tytle))
			{
				tytle = System.Console.ReadLine();
			}

			var award = new Award(tytle);
			int returned = default;
			try
			{
				returned = entityLogic.Create(award).Id;
			}
			catch (IOException e)
			{
				System.Console.WriteLine(e.Message + ". Close file and try again.");
			}
			System.Console.WriteLine("success. Award id: " + returned.ToString());
		}

		public void GetAwardsUser(int id)
		{
			try
			{
				var returnList = (entityLogic as IAwardLogic).GetAll(id);
				foreach (var award in returnList)
				{
					System.Console.WriteLine(award.ToString());
				}
			}
			catch (KeyNotFoundException)
			{
				System.Console.WriteLine("Can't find award");
			}
		}
	}
}