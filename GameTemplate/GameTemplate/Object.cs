using static GameTemplate.Map;

namespace GameTemplate
{
	class Object : IInteracting
	{
		public double Length { get; }
		public double Width { get; }

		public Point Coordinates { get; set; }

		public bool Interact() => false;
	}
}
