using System;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.DAL.File
{
	public class AccountFileDAO : AbstractIntIdFileDAO<Account>
	{
		public AccountFileDAO(string entityFilePath,
			string tmpFilePath) : base(entityFilePath,
			tmpFilePath,
			"Cannot write data. Account data file is read only",
			"Account data file missing")
		{
		}

		public override Account ParseString(string entityItem)
		{
			var entityFields = entityItem.Split(':');
			return new Account(entityFields[1], entityFields[2])
			{
				Id = int.Parse(entityFields[0]),
				Role = (Role)Enum.Parse(typeof(Role), entityFields[3]),
			};
		}
	}
}
