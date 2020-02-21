using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.DAL.File
{
	public class ImgFileDAO : AbstractIntIdFileDAO<Image>
	{
		public ImgFileDAO(string entityFilePath,
			string tmpFilePath) : base(entityFilePath,
			tmpFilePath,
			"Cannot write data. Img data file is read only",
			"Img data file missing")
		{
		}

		public override Image ParseString(string entityItem)
		{
			var entityFields = entityItem.Split(':');
			return new Image(entityFields[1])
			{ Id = int.Parse(entityFields[0]) };
		}
	}
}
