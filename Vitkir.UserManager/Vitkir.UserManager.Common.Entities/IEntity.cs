using System;

namespace Vitkir.UserManager.Common.Entities
{
	public interface IEntity<T>
	{
		T Id { get; set; }
	}
}
