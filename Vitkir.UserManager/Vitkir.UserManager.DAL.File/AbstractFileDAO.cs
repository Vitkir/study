using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;

namespace Vitkir.UserManager.DAL.File
{
	public abstract class AbstractFileDAO<T> : IDAO<T> where T : Entity
	{
		private readonly string entityFilePath;
		private readonly string tmpFilePath;

		private readonly string writingExeption;
		private readonly string fileMissingExeption;

		private int lastId;

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
				CreateEntityDataFile();
			}
			lastId = GetLastId();
		}

		public T CreateEntity(T entity)
		{
			entity.Id = ++lastId;
			var entityItem = entity.ToString() + Environment.NewLine;
			long currentPosition;
			using (FileStream fileStream = new FileStream(entityFilePath, FileMode.Append))
			{
				currentPosition = fileStream.Position;
				var byData = Encoding.ASCII.GetBytes(entityItem);
				fileStream.Write(byData, 0, byData.Length);
			}

			using (StreamReader streamReader = new StreamReader(entityFilePath))
			{
				streamReader.BaseStream.Position = currentPosition;
				entityItem = streamReader.ReadLine();
			}
			return ParseString(entityItem);
		}

		public void UpdateFile(Dictionary<int, T> usersCache)
		{
			var info = new FileInfo(entityFilePath).IsReadOnly;
			if (info)
			{
				throw new IOException(writingExeption);
			}

			System.IO.File.Create(tmpFilePath).Dispose();
			using (StreamWriter streamWriter = new StreamWriter(tmpFilePath))
			{
				foreach (var pair in usersCache)
				{
					streamWriter.WriteLine(pair.Value.ToString());
				}
			}
			System.IO.File.Delete(entityFilePath);
			System.IO.File.Move(tmpFilePath, entityFilePath);
		}

		public Dictionary<int, T> GetEntities()
		{
			if (!System.IO.File.Exists(entityFilePath))
			{
				throw new IOException(fileMissingExeption);
			}
			Dictionary<int, T> entities = new Dictionary<int, T>();
			using (StreamReader streamReader = new StreamReader(entityFilePath))
			{
				var currentLine = streamReader.ReadLine();
				T entity = default;
				while (!string.IsNullOrEmpty(currentLine))
				{
					entity = ParseString(currentLine);
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

		private void CreateEntityDataFile()
		{
			System.IO.File.Create(entityFilePath).Dispose();
		}

		public abstract T ParseString(string entityItem);
	}
}
