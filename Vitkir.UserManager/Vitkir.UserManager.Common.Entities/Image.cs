using System;

namespace Vitkir.UserManager.Common.Entities
{
	public class Image : IEntity<int>, IEquatable<Image>, ICloneable
	{
		public int Id { get; set; }

		public string ImgUrl { get; }

		public Image(string imgUrl)
		{
			ImgUrl = imgUrl;
		}

		public override string ToString()
		{
			return string.Format(Id.ToString() + ":" + ImgUrl);
		}

		public object Clone()
		{
			return new Image(ImgUrl) { Id = Id };
		}

		public override bool Equals(object obj)
		{
			return obj is Image other &&
				ImgUrl == other.ImgUrl;
		}

		public bool Equals(Image other)
		{
			return other != null &&
				ImgUrl == other.ImgUrl;
		}

		public override int GetHashCode()
		{
			return ImgUrl.GetHashCode();
		}
	}
}
