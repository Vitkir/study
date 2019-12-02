using System;

namespace Vitkir.UserManager.Common.Entities
{
	public class Award : Entity, IEquatable<Award>, ICloneable
	{
		public string Title { get; }

		public Award(string title)
		{
			Title = title;
		}

		public override string ToString()
		{
			return string.Format("{0}:{1}", Id.ToString(), Title);
		}

		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			Award objAsAward = obj as Award;
			if (objAsAward == null) return false;
			else return Equals(objAsAward);
		}

		public override int GetHashCode()
		{
			return Id;
		}

		public bool Equals(Award other)
		{
			if (other == null) return false;
			return Id.Equals(other.Id);
		}

		public object Clone()
		{
			return new Award(Title) { Id = Id };
		}
	}
}
