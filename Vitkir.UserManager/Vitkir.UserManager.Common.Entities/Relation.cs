using System;

namespace Vitkir.UserManager.Common.Entities
{
	public struct Relation : IEntity<Relation>, IEquatable<Relation>
	{
		public Relation Id { get => this; set { this = value; } }

		public int FirstId { get; }

		public int SecondId { get; }

		public Relation(int firstId, int secondId)
		{
			FirstId = firstId;
			SecondId = secondId;
		}

		public override string ToString()
		{
			return FirstId.ToString() + ":" + SecondId.ToString();
		}

		public override bool Equals(object obj)
		{
			return obj is Relation relation &&
				(FirstId, SecondId) == (relation.FirstId, relation.SecondId);
		}

		public override int GetHashCode()
		{
			var hashCode = -940031710;
			hashCode = hashCode * -1521134295 + FirstId.GetHashCode();
			hashCode = hashCode * -1521134295 + SecondId.GetHashCode();
			return hashCode;
		}

		public bool Equals(Relation other)
		{
			return (FirstId, SecondId) == (other.FirstId, other.SecondId);
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
