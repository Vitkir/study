using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.DAL.File
{
	public class AwardFileDAO : AbstractIntIdFileDAO<Award>
	{
		public AwardFileDAO(string entityFilePath,
			string tmpFilePath) : base(entityFilePath,
			tmpFilePath,
			"Cannot write data. Award data file is read only",
			"Award data file missing")
		{
		}

		public override Award ParseString(string entityItem)
		{
			var entityFields = entityItem.Split(':');
			return new Award(entityFields[1])
			{ Id = int.Parse(entityFields[0]) };
		}
	}
}
