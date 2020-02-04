using System.Configuration;

namespace Vitkir.UserManager.Common.Dependencies.ConfigurationSettings
{
	public class FilePathConfigSection : ConfigurationSection
	{
		[ConfigurationProperty("FilePaths")]
		public PathsCollections PathsCollections => (PathsCollections)base["FilePaths"];
	}
}
