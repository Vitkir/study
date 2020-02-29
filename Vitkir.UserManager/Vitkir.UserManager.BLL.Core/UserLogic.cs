using System.Collections.Generic;
using System.Linq;
using Vitkir.UserManager.BLL.Contracts.Cache;
using Vitkir.UserManager.BLL.Contracts.Logic;
using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;

namespace Vitkir.UserManager.BLL.Logic
{
	public class UserLogic : AbstractLogic<int, User>, IUserLogic
	{

		private readonly IDAO<int, Image> imgDAO;
		private readonly Dictionary<int, Image> imgCache;

		public UserLogic(
			IDAO<int, User> userDAO,
			IUsersAwardsRelationsCache relationCache,
			IDAO<int, Image> imgDAO) : base(userDAO, relationCache)
		{
			this.imgDAO = imgDAO;
			imgCache = imgDAO.GetEntities().ToDictionary(e => e.Id);
		}

		public override User Get(int id)
		{
			var user = base.Get(id);
			user.Awards = GetAwardIds(id);
			return user;
		}

		public override Dictionary<int, User> GetAll()
		{
			var users = base.GetAll();
			foreach (var user in users.Values)
			{
				user.Awards = GetAwardIds(user.Id);

			}
			return users;
		}

		private List<int> GetAwardIds(int id)
		{
			return relationCache.GetAll()
				.Where(relation => relation.Key.FirstId == id)
				.Select(relation => relation.Key.SecondId)
				.ToList();
		}

		public Relation AddAward(Relation relation)
		{
			return relationCache.Create(relation);
		}

		public bool RemoveAward(Relation relation)
		{
			return relationCache.Delete(relation);
		}

		public bool RemoveAllAwardsUser(int id)
		{
			return (relationCache as IUsersAwardsRelationsCache).DeleteAllForUser(id);
		}

		public bool RemoveAwardAllUsers(int id)
		{
			return (relationCache as IUsersAwardsRelationsCache).DeleteAllForAward(id);
		}

		public int AddImg(Image image)
		{
			if (image == null)
			{
				return 0;
			}
			var returnedImage = imgDAO.CreateEntity(image);
			imgCache.Add(returnedImage.Id, returnedImage);
			return returnedImage.Id;
		}

		public bool RemoveImg(Image image)
		{
			return imgCache.Remove(image.Id);
		}

		public Image GetImage(int imgId)
		{
			return imgCache[imgId];
		}
	}
}
