using System.Configuration;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.DAL.File
{
	public class UsersAwardsFileDAO : AbstractFileDAO<UsersAwards>
	{
		public UsersAwardsFileDAO() : base(ConfigurationManager.AppSettings["relationshipsFilePath"],
			ConfigurationManager.AppSettings["relationshipstmpFilePath"],
			"Cannot write data. UsersAwards data file is read only",
			"UsersAwards data file missing")
		{

		}

		public override UsersAwards ParseString(string entityItem)
		{
			var entityFields = entityItem.Split(':');
			return new UsersAwards(int.Parse(entityFields[1]), int.Parse(entityFields[2]))
			{
				Id = int.Parse(entityFields[0])
			};
		}
	}
}
