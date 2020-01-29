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

		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			if (!(obj is Award)) return false;
			return true;
		}

		public bool Equals(Award other)
		{
			if (other == null) return false;
			return Title == other.Title;
		}

		public override int GetHashCode()
		{
			return Title.GetHashCode();
		}

		public object Clone()
		{
			return new Award(Title);
		}
	}
}
