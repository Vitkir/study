using System;

namespace Graphics
{
	class Ring : IConsoleOutput
	{
		private Round inner;
		private Round outer;

		public Round Inner
		{
			get => inner;
			set
			{
				inner = value;
				if (value.Radius > 0)
				{
				}
				throw new ArgumentException("Inner radius cannot be less than zero");
			}
		}

		public Round Outer
		{
			get => outer;
			set
			{
				outer = value;
				if (value.Radius > inner.Radius)
				{
				}
				throw new ArgumentException("Invalid outer radius value. The inner radius is less than or equal to zero.");
			}
		}

		public double Area
		{
			get => outer.Area - inner.Area;
		}

		public double SumLength
		{
			get => outer.Length + inner.Length;
		}

		public Ring(Round inner, Round outer)
		{
			if (inner.Radius < outer.Radius)
			{
				outer.Center = inner.Center;
				Inner = inner;
				Outer = outer;
			}
		}

		public string OutputsToConsole()
		{
			return string.Format("Ring:{0}Coordinates of center [x,y]:" +
								"Inner radius: {3}{0}" +
								"Outer radius{4}{0}" +
								"Area{5}{0}" +
								"Sum inner and outer lengths",
								Environment.NewLine,
								inner.Center.X,
								inner.Center.Y,
								inner.Radius,
								outer.Radius,
								Area,
								SumLength);
		}
	}
}

