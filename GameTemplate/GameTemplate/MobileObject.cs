using System.Drawing;

namespace GameTemplate
{
	class MobileObject : Object, ICharacter
	{
		public string Name { get; set; }

		public double Health { get; set; }

		public double Speed { get; set; }

		public double Strength { get; set; }

		public double Damage { get; set; }

		public void TakeItem(Item bonus) { }

		public virtual Point Move() => Coordinates;
		public virtual Point Move(bool move) => Coordinates;

		public bool Live() => true;
	}
}
