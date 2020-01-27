using System;
using System.Configuration;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.DAL.File
{
	public class AwardFileDAO : AbstractEntityFileDAO<Award>
	{
		public AwardFileDAO() : base(ConfigurationManager.AppSettings["awardsDataFilePath"],
			ConfigurationManager.AppSettings["awardstmpFilePath"],
			"Cannot write data. Award data file is read only",
			"Award data file missing")
		{

		}

		public override ValueTuple<int,Award> ParseString(string entityItem)
		{
			var entityFields = entityItem.Split(':');
			lastId = int.Parse(entityFields[0]);
			var award = new Award(entityFields[1]);
			return (lastId,award);
		}
	}
}
