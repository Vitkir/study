using System;

namespace Vitkir.UserManager.Common.Entities
{
	public class Relation : AbstractEntity, IEquatable<Relation>, ICloneable
	{
		public int UserId { get; set; }

		public int AwardId { get; set; }

		public Relation(int userId, int awardId)
		{
			UserId = userId;
			AwardId = awardId;
		}

		public override string ToString()
		{
			return Id.ToString() + ":" + UserId.ToString() + ":" + AwardId.ToString();
		}

		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			if (!(obj is Relation)) return false;
			return true;
		}

		public override int GetHashCode()
		{
			return Id;
		}

		public bool Equals(Relation other)
		{
			if (other == null) return false;
			return Id.Equals(other.Id);
		}

		public object Clone()
		{
			return new Relation(UserId, AwardId) { Id = Id };
		}
	}
}
