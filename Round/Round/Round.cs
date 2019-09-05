using System;

namespace GraphicEditorBlank
{
	public class Round
	{
		private double r;

		public struct Point
		{
			public int X { get; set; }
			public int Y { get; set; }
		}

		public Point Center { get; set; }

		public double Radius
		{
			get => r;
			set
			{
				if (value > 0)
				{
					r = value;
				}
				throw new ArgumentException("Radius should be positive");
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

		public static bool operator >(Round r1, Round r2)
		{
			return r1.Radius > r2.Radius;
		}

		public static bool operator <(Round r1, Round r2)
		{
			return r1.Radius < r2.Radius;
		}

		public static bool operator ==(Round r1, Round r2)
		{
			return r1.Radius == r2.Radius;
		}

		public static bool operator !=(Round r1, Round r2)
		{
			return r1.Radius != r2.Radius;
		}

		public override string OutputsToConsole()
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
