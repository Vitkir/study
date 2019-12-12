using System;

namespace Vitkir.UserManager.Common.Entities
{
	public class UsersAwards : Entity, IEquatable<UsersAwards>, ICloneable
	{
		public int UserId { get; set; }

		public int AwardId { get; set; }

		public UsersAwards(int userId, int awardId)
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
			UsersAwards objAsUser = obj as UsersAwards;
			if (objAsUser == null) return false;
			else return Equals(objAsUser);
		}

		public override int GetHashCode()
		{
			return Id;
		}

		public bool Equals(UsersAwards other)
		{
			if (other == null) return false;
			return Id.Equals(other.Id);
		}

		public object Clone()
		{
			return new UsersAwards(UserId, AwardId) { Id = Id };
		}
	}
}
