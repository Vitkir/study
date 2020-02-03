using System.Configuration;

namespace Vitkir.UserManager.Common.Dependencies.ConfigurationSettings
{
	public class PathElement : ConfigurationElement
	{
		[ConfigurationProperty("fileName", DefaultValue = "", IsKey = true, IsRequired = true)]
		public string FileName
		{
			get { return (string)base["fileName"]; }
			set { base["fileName"] = value; }
		}

		[ConfigurationProperty("path", DefaultValue = "", IsKey = false, IsRequired = false)]
		public string Path
		{
			get { return (string)base["path"]; }
			set { base["path"] = value; }
		}
	}
}