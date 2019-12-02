using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using Vitkir.UserManager.BLL.Logic;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManadger.PL.Console
{
	class UserPresentation : AbstractEntityPresentation<User>
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
	}
}
