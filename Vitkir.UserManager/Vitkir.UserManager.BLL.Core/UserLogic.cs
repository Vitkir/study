using Vitkir.UserManager.Common.Entities;
using Vitkir.UserManager.DAL.Contracts;

namespace Vitkir.UserManager.BLL.Logic
{
	public class UserLogic : EntityLogic<User>
	{
		public UserLogic(IDAO<User> userDAO) : base(userDAO)
		{

		}
	}
}
