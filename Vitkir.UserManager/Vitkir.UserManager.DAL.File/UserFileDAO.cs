using System;
using System.Globalization;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.DAL.File
{
	public class UserFileDAO : AbstractIntIdFileDAO<User>
	{
		public UserFileDAO(string entityFilePath,
			string tmpFilePath) : base(entityFilePath,
			tmpFilePath,
			"Cannot write data. User data file is read only",
			"User data file missing")
		{
		}

		public override User ParseString(string entityItem)
		{
			var entityFields = entityItem.Split(':');
			return new User(entityFields[1], DateTime.ParseExact(entityFields[2], "dd.MM.yyyy", CultureInfo.InvariantCulture))
			{
				Id = int.Parse(entityFields[0]),
				ImgId = int.Parse(entityFields[3])
			};
		}
	}
}
