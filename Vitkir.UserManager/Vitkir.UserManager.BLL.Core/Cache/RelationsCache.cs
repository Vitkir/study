using System.Collections.Generic;
using System.Linq;
using Vitkir.UserManager.BLL.Contracts.Cache;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;

namespace Vitkir.UserManager.BLL.Logic.Cache
{
	public class RelationsCache : ICache
	{
		protected readonly IRelationDAO relationDAO;
		protected readonly Dictionary<Relation, Relation> relations;

		public RelationsCache(IRelationDAO relationDAO)
		{
			this.relationDAO = relationDAO;
			relations = relationDAO.GetEntities().ToDictionary(e => e.Id);
		}

		public Relation Create(Relation relation)
		{
			if (!relations.ContainsKey(relation.Id))
			{
				relations.Add(relation.Id, relation);
			}
			return relationDAO.CreateEntity(relation);
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
