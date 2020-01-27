using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;

namespace Vitkir.UserManager.DAL.File
{
	public abstract class AbstractEntityFileDAO<TEntityId, TEntity> : IDAO<TEntityId, TEntity>
		where TEntity : IEntity<TEntityId>, IEquatable<TEntity>
	{
		private readonly string entityFilePath;
		private readonly string tmpFilePath;

		private readonly string writingExeption;
		private readonly string fileMissingExeption;

		protected int lastId;

		public AbstractEntityFileDAO(string entityFilePath,
			string tmpFilePath,
			string writingExeption,
			string fileMissingExeption)
		{
			this.entityFilePath = entityFilePath;
			this.tmpFilePath = tmpFilePath;
			this.writingExeption = writingExeption;
			this.fileMissingExeption = fileMissingExeption;

			if (!System.IO.File.Exists(this.entityFilePath))
			{
				System.IO.File.Create(this.entityFilePath).Dispose();
			}
			lastId = GetLastId();
		}

		public TEntity CreateEntity(TEntity entity)
		{
			var entityItem = lastId++.ToString() + entity.ToString() + Environment.NewLine;
			long currentPosition;
			using (FileStream fileStream = new FileStream(entityFilePath, FileMode.Append))
			{
				currentPosition = fileStream.Position;
				var byData = Encoding.Unicode.GetBytes(entityItem);
				fileStream.Write(byData, 0, byData.Length);
			}

			using (StreamReader streamReader = new StreamReader(entityFilePath))
			{
				streamReader.BaseStream.Position = currentPosition;
				entityItem = streamReader.ReadLine();
			}
			return ParseString(entityItem);
		}

		public void UpdateFile(List<TEntity> tuples)
		{
			var info = new FileInfo(entityFilePath).IsReadOnly;
			if (info)
			{
				throw new IOException(writingExeption);
			}

			System.IO.File.Create(tmpFilePath).Dispose();
			using (StreamWriter streamWriter = new StreamWriter(tmpFilePath))
			{
				foreach (var tuple in tuples)
				{
					streamWriter.WriteLine(tuple.ToString());
				}
			}
			System.IO.File.Delete(entityFilePath);
			System.IO.File.Move(tmpFilePath, entityFilePath);
		}

		public Dictionary<TEntityId, TEntity> GetEntities()
		{
			if (!System.IO.File.Exists(entityFilePath))
			{
				throw new IOException(fileMissingExeption);
			}
			var entities = new Dictionary<TEntityId, TEntity>();
			using (StreamReader streamReader = new StreamReader(entityFilePath))
			{
				var currentLine = streamReader.ReadLine();
				while (!string.IsNullOrEmpty(currentLine))
				{
					var entity = ParseString(currentLine);
					entities.Add(entity.Id, entity);
					currentLine = streamReader.ReadLine();
				}
			}
			return entities;
		}

		private int GetLastId()
		{
			string currentLine = default;
			int currentId = default;
			using (StreamReader streamReader = new StreamReader(entityFilePath))
			{
				currentLine = streamReader.ReadLine();
				while (!string.IsNullOrEmpty(currentLine))
				{
					currentId = ParseId(currentLine);
					currentLine = streamReader.ReadLine();
				}
			}
			return currentId;
		}

		private int ParseId(string currentLine)
		{
			var separator = currentLine.IndexOf(':');
			return int.Parse(currentLine.Substring(0, separator));
		}

		public abstract TEntity ParseString(string entityItem);
	}
}
