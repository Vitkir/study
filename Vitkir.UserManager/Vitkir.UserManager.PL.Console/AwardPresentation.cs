using System.IO;
using System.Text.RegularExpressions;
using Vitkir.UserManager.BLL.Logic;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManadger.PL.Console
{
	class AwardPresentation : AbstractEntityPresentation<Award>
	{
		public AwardPresentation(ILogic<Award> awardlogic) : base(awardlogic)
		{

		}

		public override void CreateEntity()
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
				returned = entityLogic.CreateEntity(award).Id;
			}
			catch (IOException e)
			{
				System.Console.WriteLine(e.Message + ". Close file and try again.");
			}
			System.Console.WriteLine("success. Award id: " + returned.ToString());
		}
	}
}