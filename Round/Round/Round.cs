using System;

namespace Round
{
	public class Round
	{
		private int r;

		public struct Point
		{
			public int X { get; set; }
			public int Y { get; set; }
		}

		public Point Center { get; set; }

		public int Radius
		{
			get => r;
			set
			{
				if (value <= 0)
				{
					throw new ArgumentException("Radius should be positive");
				}
				r = value;
			}
		}

		public double Length
		{
			get => Radius * 2 * Math.PI;
		}

		public double Area
		{
			get => Math.PI * Radius * Radius;
		}

		public override string ToString()
		{
			Console.Clear();
			return string.Format(
				"Round:{5}Center x,y: [{0}, {1}];{5}Radius: {2};{5}Length: {3};{5}Area: {4}.",
				Center.X.ToString(),
				Center.Y.ToString(),
				Radius.ToString(),
				Length.ToString(),
				Area.ToString(),
				Environment.NewLine);
		}
	}
}
