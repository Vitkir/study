using System;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.DAL.File
{
	public abstract class AbstractIntIdFileDAO<TEntity> : AbstractFileDAO<int, TEntity>
		where TEntity : IEntity<int>, IEquatable<TEntity>
	{
		public AbstractIntIdFileDAO(string entityFilePath,
			string tmpFilePath,
			string writingExeption,
			string fileMissingExeption) : base(entityFilePath, tmpFilePath, writingExeption, fileMissingExeption)
		{
		}

		protected override int ParseId(string currentLine)
		{
			var arr = currentLine.Split(':');
			return int.Parse(arr[0]);
		}
		protected override int GetLastAvaliableId(TEntity entity)
		{
			return ++lastId;
		}
	}
}
