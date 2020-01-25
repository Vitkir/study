using System;
using System.Collections.Generic;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;

namespace Vitkir.UserManager.BLL.Logic
{
	public class UserLogic : AbstractLogic<User>
	{
		private readonly IRelationsDAO relationsDAO;

		public UserLogic(IDAO<User> userDAO, IRelationsDAO relationsDAO) : base(userDAO)
		{
			this.relationsDAO = relationsDAO;
			UpdateRelationsCache();
		}

		private void UpdateRelationsCache()
		{
			var relations = relationsDAO.GetEntities();

			foreach (var entity in relations)
			{
				entityCache[entity.Value.UserId].RelatedAwards.Add(entity.Value.AwardId);
			}
		}

		public override User CreateEntity(User entity)
		{
			var createdEntity = base.CreateEntity(entity);
			UpdateCacheRelatedEntitiesFromDAO(createdEntity.Id);
			return createdEntity;
		}

		#region UsersAwardsRelationsLogic

		public Relation CreateRelation(Relation relation)
		{
			var user = entityCache[relation.UserId];
			if (!user.RelatedAwards.Contains(relation.AwardId))
			{
				user.RelatedAwards.Add(relation.AwardId);
				return relationsDAO.CreateEntity(relation);
			}
			return relation;
		}

		public override void UpdateEntityDAO()
		{
			base.UpdateEntityDAO();
			UpdateRelationsDAO();
		}

		public void UpdateRelationsDAO()
		{
			int counter = 0;
			var relations = new Dictionary<int, Relation>();
			foreach (var user in entityCache.Values)
			{
				foreach (var relation in user.RelatedAwards)
				{
					relations.Add(counter++, new Relation(user.Id, relation));
				}
			}
			relationsDAO.UpdateFile(relations);
		}

		public Tuple<int, int> DeleteRelationEntity(int userId, int awardId)
		{
			var user = entityCache[userId];
			if (user.RelatedAwards.Contains(awardId))
			{
				user.RelatedAwards.Remove(awardId);
				return new Tuple<int, int>(userId, awardId);
			}
			return null;
		}

		public ICollection<int> GetRelatedEntities(int id)
		{
			var relations = entityCache[id].RelatedAwards;
			return relations;
		}

		private ICollection<int> UpdateCacheRelatedEntitiesFromDAO(int id)
		{
			var relations = relationsDAO.GetRelatedEntitiesId(id);
			if (relations != null)
			{
				GetEntity(id).RelatedAwards.AddRange(relations);
			}
			return relations;
		}

		#endregion
	}
}
