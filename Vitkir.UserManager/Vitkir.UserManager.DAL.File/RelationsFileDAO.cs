﻿using System;
using System.Collections.Generic;
using System.Configuration;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;


namespace Vitkir.UserManager.DAL.File
{
	public class RelationsFileDAO : IRelationsDAO
	{
		public RelationsFileDAO() : base(ConfigurationManager.AppSettings["relationsFilePath"],
			ConfigurationManager.AppSettings["relationstmpFilePath"],
			"Cannot write data. UsersAwards data file is read only",
			"UsersAwards data file missing")
		{

		}

		public KeyValuePair<int, Relation> CreateEntity(Relation entity)
		{
			throw new NotImplementedException();
		}

		public Dictionary<int, Relation> GetEntities()
		{
			throw new NotImplementedException();
		}

		public List<int> GetRelatedIdEntities(int userId)
		{
			var entities = GetEntities();

			List<int> relatedAwards = new List<int>();

			foreach (var value in entities.Values)
			{
				if (value.UserId == userId)
				{
					relatedAwards.Add(value.AwardId);
				}
			}
			if (relatedAwards.Count == 0) return null;
			return relatedAwards;
		}

		public Relation ParseString(string entityItem)
		{
			var entityFields = entityItem.Split(':');
			return new Relation(int.Parse(entityFields[1]), int.Parse(entityFields[2]));
		}

		public void UpdateFile(Dictionary<int, Relation> usersCache)
		{
			throw new NotImplementedException();
		}
	}
}
