using static GameTemplate.Map;

namespace GameTemplate
{
	class NonPlayerCharacter : Object, IMoving, IInteracting
	{
		public Point Move()
		{
			return Coordinates;
		}
		public bool Interact() => false;
	}
}
