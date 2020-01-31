using System.Collections.Generic;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;

namespace Vitkir.UserManager.BLL.Logic
{
	internal class RelationCache : ICache
	{
		private readonly IRelationDAO relationsDAO;
		private readonly Dictionary<Relation> relations;

		public RelationCache(IRelationDAO relationsDAO)
		{
			this.relationsDAO = relationsDAO;
			relations = relationsDAO.GetEntities();
		}

		public Relation Create(Relation relation)
		{
			var returnEntity = relationsDAO.CreateEntity(relation);
			relations.Add(returnEntity);
			return returnEntity;
		}

		public bool Delete(Relation relation)
		{
			return relations.Remove(relation);
		}

		public List<Relation> GetAll()
		{
			return relations;
		}

		public void UpdateDAO()
		{
			relationsDAO.UpdateFile(relations);
		}
	}
}
