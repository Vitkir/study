using System;

namespace Ring
{
	class Ring
	{
		private Round.Round inner;
		private Round.Round outer;
		private double thickness;

		public Round.Round.Point Center { get; set; }

		public double Thickness
		{
			get => Outer.Radius - Inner.Radius;
			set
			{
				thickness = value;
				Outer.Radius = inner.Radius + thickness;
			}
		}

		public Round.Round Inner
		{
			get => inner;
			set
			{
				inner = value;
				Outer.Radius = inner.Radius + thickness;
			}
		}

		public Round.Round Outer
		{
			get => outer;
			set
			{
				outer = value;
				if (outer.Radius - thickness > 0)
				{
					Inner.Radius = outer.Radius - thickness;
				}
				else
				{
					throw new ArgumentException("Invalid outer radius value. The inner radius is less than or equal to zero.");
				}
			}
		}

		public double Area
		{
			get => Outer.Area - Inner.Area;
		}

		public double SumLength
		{
			get => Outer.Length + Inner.Length;
		}

		public Ring(Round.Round inner, Round.Round outer)
		{
			if (inner.Radius < outer.Radius)
			{
				Center = outer.Center = inner.Center;
				Inner = inner;
				Outer = outer;
			}
		}

		public override string ToString()
		{
			return string.Format("Ring: Inner radius: {1}{0}" +
										"Outer radius{2}{0}" +
										"Thickness{3}{0}" +
										"Area{4}{0}" +
										"Sum inner and outer lengths",
										Environment.NewLine,
										Inner.Radius,
										Outer.Radius,
										Thickness,
										Area,
										SumLength);
		}
	}
}

