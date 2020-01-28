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
		private readonly string tmpFilePath;

		private readonly string writingExeption;
		private readonly string fileMissingExeption;

		protected readonly string entityFilePath;
		protected TEntityId lastId;

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

		public abstract TEntity ParseString(string entityItem);

		public TEntity CreateEntity(TEntity entity)
		{
			entity.Id = GetLastAvaliableId(entity);
			var entityItem = entity.ToString() + Environment.NewLine;
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

		public void UpdateFile(List<TEntity> entities)
		{
			var info = new FileInfo(entityFilePath).IsReadOnly;
			if (info)
			{
				throw new IOException(writingExeption);
			}

			System.IO.File.Create(tmpFilePath).Dispose();
			using (StreamWriter streamWriter = new StreamWriter(tmpFilePath))
			{
				foreach (var entity in entities)
				{
					streamWriter.WriteLine(entity.ToString());
				}
			}
			System.IO.File.Delete(entityFilePath);
			System.IO.File.Move(tmpFilePath, entityFilePath);
		}

		public List<TEntity> GetEntities()
		{
			if (!System.IO.File.Exists(entityFilePath))
			{
				throw new IOException(fileMissingExeption);
			}
			var entities = new List<TEntity>();
			using (StreamReader streamReader = new StreamReader(entityFilePath))
			{
				var currentLine = streamReader.ReadLine();
				while (!string.IsNullOrEmpty(currentLine))
				{
					var entity = ParseString(currentLine);
					entities.Add(entity);
					currentLine = streamReader.ReadLine();
				}
			}
			return entities;
		}

		protected TEntityId GetLastId()
		{
			string lastLine = default;
			string currentLine = default;
			TEntityId lastId = default;
			using (StreamReader streamReader = new StreamReader(entityFilePath))
			{
				currentLine = streamReader.ReadLine();
				while (true)
				{
					currentLine = streamReader.ReadLine();
					if (string.IsNullOrEmpty(currentLine))
					{
						break;
					}
					lastLine = currentLine;
				}
				lastId = ParseId(lastLine);
			}
			return lastId;
		}

		protected abstract TEntityId ParseId(string currentLine);

		protected abstract TEntityId GetLastAvaliableId(TEntity entity);
	}
}
