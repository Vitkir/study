namespace Vitkir.UserManager.Common.Entities
{
	public interface IEntity<TId>
	{
		TId Id { get; set; }
	}
}
