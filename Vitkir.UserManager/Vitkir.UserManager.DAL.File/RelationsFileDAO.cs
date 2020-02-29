using System.Collections.Generic;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;

namespace Vitkir.UserManager.DAL.File
{
	public class RelationsFileDAO : AbstractFileDAO<Relation, Relation>, IRelationDAO
	{
		public RelationsFileDAO(string entityFilePath,
			string tmpFilePath) : base(entityFilePath,
			tmpFilePath,
			"Cannot write data. UsersAwards data file is read only",
			"UsersAwards data file missing")
		{
		}

		public List<int> GetRelatedIdEntities(int userId)
		{
			var entities = GetEntities();

			List<int> relatedAwards = new List<int>();

			foreach (var entity in entities)
			{
				if (entity.FirstId == userId)
				{
					relatedAwards.Add(entity.SecondId);
				}
			}
			if (relatedAwards.Count == 0) return null;
			return relatedAwards;
		}

		public override Relation ParseString(string entityItem)
		{
			var entityFields = entityItem.Split(':');
			return new Relation(int.Parse(entityFields[0]), int.Parse(entityFields[1]));
		}

		protected override Relation ParseId(string currentLine)
		{
			return ParseString(currentLine);
		}

		protected override Relation GetLastAvaliableId(Relation entity)
		{
			return lastId = entity;
		}
	}
}
