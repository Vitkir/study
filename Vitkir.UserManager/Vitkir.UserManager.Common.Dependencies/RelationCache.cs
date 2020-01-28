using System.Collections.Generic;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;

namespace Vitkir.UserManager.Common.Dependencies
{
	class RelationCache
	{
		private readonly IRelationsDAO relationsDAO;
		private readonly List<Relation> relations;

		public RelationCache(IRelationsDAO relationsDAO)
		{
			this.relationsDAO = relationsDAO;
			relations = relationsDAO.GetEntities();
		}

		public Relation CreaeRelation(Relation relation)
		{
			var returnEntity = relationsDAO.CreateEntity(relation);
			relations.Add(returnEntity);
			return returnEntity;
		}

		public void UpdateReltionDAO()
		{
			relationsDAO.UpdateFile(relations);
		}

		public bool DeleteRelationFromCache(Relation relation)
		{
			return relations.Remove(relation);
		}

		public List<Relation> GetRelations()
		{
			return relations;
		}
	}
}
