using System.Drawing;

using GameTemplate;

namespace Characters
{
	class Monster : MobileObject, INoPlayerCharacter
	{
		public bool AlgorithmMovement() => true;
		public override Point Move(bool move) => Coordinates;
	}
}
