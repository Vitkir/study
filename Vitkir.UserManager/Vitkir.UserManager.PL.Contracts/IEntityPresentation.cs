namespace Vitkir.UserManadger.PL.Contracts
{
	public interface IEntityPresentation
	{
		void Create();

		void Delete(int id);

		void GetAll();

		void Get(int id);

		void Update();
	}
}