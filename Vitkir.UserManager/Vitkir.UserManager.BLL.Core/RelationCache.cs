using System.Collections.Generic;
using System.Linq;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;

namespace Vitkir.UserManager.BLL.Logic
{
	public class RelationCache : ICache
	{
		private readonly IRelationDAO relationDAO;
		private readonly Dictionary<Relation, Relation> relations;

		public RelationCache(IRelationDAO relationsDAO)
		{
			this.relationDAO = relationsDAO;
			relations = relationsDAO.GetEntities().ToDictionary(e => e.Id);
		}

		public Relation Create(Relation relation)
		{
			var returnEntity = relationDAO.CreateEntity(relation);
			relations.Add(returnEntity.Id, returnEntity);
			return returnEntity;
		}

		public bool Delete(Relation relation)
		{
			return relations.Remove(relation);
		}

		public Dictionary<Relation, Relation> GetAll()
		{
			return relations;
		}

		public void UpdateDAO()
		{
			relationDAO.UpdateFile(relations);
		}
	}
}
