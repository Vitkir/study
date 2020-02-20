using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;

namespace Vitkir.UserManager.DAL.File
{
	public abstract class AbstractFileDAO<TId, TEntity> : IDAO<TId, TEntity>
		where TEntity : IEntity<TId>, IEquatable<TEntity>
	{
		private readonly string tmpFilePath;

		private readonly string writingExeption;
		private readonly string fileMissingExeption;

		protected readonly string entityFilePath;
		protected TId lastId;

		public AbstractFileDAO(string entityFilePath,
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
				var byteData = Encoding.ASCII.GetBytes(entityItem);
				fileStream.Write(byteData, 0, byteData.Length);
			}

			using (StreamReader streamReader = new StreamReader(entityFilePath))
			{
				streamReader.BaseStream.Position = currentPosition;
				entityItem = streamReader.ReadLine();
			}
			return ParseString(entityItem);
		}

		public void UpdateFile(Dictionary<TId, TEntity> entities)
		{
			var info = new FileInfo(entityFilePath).IsReadOnly;
			if (info)
			{
				throw new IOException(writingExeption);
			}

			System.IO.File.Create(tmpFilePath).Dispose();
			using (StreamWriter streamWriter = new StreamWriter(tmpFilePath))
			{
				foreach (var entity in entities.Values)
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

		protected TId GetLastId()
		{
			string lastLine = default;
			TId lastId = default;
			using (StreamReader streamReader = new StreamReader(entityFilePath))
			{
				var currentLine = streamReader.ReadLine();
				while (true)
				{
					if (string.IsNullOrEmpty(currentLine))
					{
						break;
					}
					lastLine = currentLine;
					currentLine = streamReader.ReadLine();
				}
			}
			if (lastLine != null)
			{
				lastId = ParseId(lastLine);
			}
			return lastId;
		}

		protected abstract TId ParseId(string currentLine);

		protected abstract TId GetLastAvaliableId(TEntity entity);
	}
}
