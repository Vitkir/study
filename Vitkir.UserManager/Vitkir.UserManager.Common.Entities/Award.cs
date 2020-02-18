using System;

namespace Vitkir.UserManager.Common.Entities
{
	public class Award : IEntity<int>, IEquatable<Award>, ICloneable
	{
		public int Id { get; set; }

		public string Title { get; }

		public Award(string title)
		{
			Title = title;
		}

		public override string ToString()
		{
			return string.Format(Id.ToString() + ":" + Title);
		}

		public object Clone()
		{
			return new Award(Title) { Id = Id };
		}

		public override bool Equals(object obj)
		{
			return obj is Award other &&
				Title == other.Title;
		}

		public bool Equals(Award other)
		{
			return other != null &&
				Title == other.Title;
		}

		public override int GetHashCode()
		{
			return Title.GetHashCode();
		}
	}
}
