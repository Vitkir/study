using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.DAL.File
{
	public class AwardDAO : AbstractDAO<Award>
	{
		public AwardDAO() : base(@"C:\Users\T\Desktop\Learning\xt_2016\Task_6\awards.txt",
			@"C:\Users\T\Desktop\Learning\xt_2016\Task_6\awardstmp.txt",
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
