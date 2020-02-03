using System.Configuration;

namespace Vitkir.UserManager.Common.Dependencies.ConfigurationSettings
{
	[ConfigurationCollection(typeof(PathElement))]
	public class PathsCollections : ConfigurationElementCollection
	{
		protected override ConfigurationElement CreateNewElement()
		{
			return new PathElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((PathElement)element).FileName;
		}

		public PathElement this[int i] => (PathElement)BaseGet(i);

		public new PathElement this[string responseString]
		{
			get { return (PathElement)BaseGet(responseString); }
			set
			{
				if (BaseGet(responseString) != null)
				{
					BaseRemoveAt(BaseIndexOf(BaseGet(responseString)));
				}
				BaseAdd(value);
			}
		}
	}
}
