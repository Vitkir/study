using System;

namespace Graphics
{
	public class Round : Circle
	{
		protected override string FigureName => "Round";

		public double Area
		{
			get => Math.PI * Radius * Radius;
		}

		public Round(Point center, double radius) : base(center, radius)
		{
		}

		public override string Printable()
		{
			return string.Format("{1}{0}Area: {2}.",
								Environment.NewLine,
								base.Printable(),
								Area.ToString());
		}
	}
}
