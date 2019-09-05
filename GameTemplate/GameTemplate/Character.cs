using static GameTemplate.Map;

namespace GameTemplate
{
	class Character : Object, IInteracting
	{
		public Point Move()
		{
			return Coordinates;
		}
		public bool Interact() => false;
	}
}
