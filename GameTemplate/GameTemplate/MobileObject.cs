using static GameTemplate.Map;

namespace GameTemplate
{
	class MobileObject : Object, IMoving
	{
		public double Health { get; set; }

		public double Speed { get; set; }

		public double Strength { get; set; }

		public Point Move() => Coordinates;

		public double SetDamage() => Health;

		public double GetDamage() => Health;
	}
}
