using System.Drawing;

namespace GameTemplate
{
	interface ICharacter
	{
		string Name { get; set; }

		double Health { get; set; }

		double Speed { get; set; }

		double Strength { get; set; }

		double Damage { get; set; }

		Point Move();

		void TakeItem(Item bonus);

		bool Live();
	}
}
