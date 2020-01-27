using System;

namespace Vitkir.UserManager.Common.Entities
{
	public readonly struct Relation : IEntity<Relation>, IEquatable<Relation>
	{
		public int UserId { get; }

		public int AwardId { get; }
		public Relation Id
		{
			get => throw new NotImplementedException();
			set => throw new NotImplementedException();
		}

		public Relation(int userId, int awardId)
		{
			UserId = userId;
			AwardId = awardId;
		}

		public override string ToString()
		{
			return UserId.ToString() + ":" + AwardId.ToString();
		}

		public override bool Equals(object obj)
		{
			return obj is Relation relation &&
				(UserId, AwardId) == (relation.UserId, relation.AwardId);
		}

		public override int GetHashCode()
		{
			var hashCode = -940031710;
			hashCode = hashCode * -1521134295 + UserId.GetHashCode();
			hashCode = hashCode * -1521134295 + AwardId.GetHashCode();
			return hashCode;
		}

		public bool Equals(Relation other)
		{
			return (UserId, AwardId) == (other.UserId, other.AwardId);
		}

		public static bool operator ==(Relation left, Relation right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Relation left, Relation right)
		{
			return !(left == right);
		}
	}
}
