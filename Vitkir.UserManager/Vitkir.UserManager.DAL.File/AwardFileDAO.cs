using System.Configuration;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.DAL.File
{
	public class AwardFileDAO : AbstractFileDAO<Award>
	{
		public AwardFileDAO() : base(ConfigurationManager.AppSettings["awardsDataFilePath"],
			ConfigurationManager.AppSettings["awardstmpFilePath"],
			"Cannot write data. Award data file is read only",
			"Award data file missing")
		{

		}

		protected override Award ParseString(string entityItem)
		{
			var entityFields = entityItem.Split(':');
			return new Award(entityFields[1])
			{
				Id = int.Parse(entityFields[0])
			};
		}
	}
}
