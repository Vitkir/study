using System.Configuration;

namespace Vitkir.UserManager.Common.Dependencies.ConfigurationSettings
{
	public class FilePathConfigSection : ConfigurationSection
	{
		[ConfigurationProperty("Paths")]
		public PathsCollections PathsCollections => (PathsCollections)base["Paths"];
	}
}
