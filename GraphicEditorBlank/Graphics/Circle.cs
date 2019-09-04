using System;

namespace Graphics
{
	public class Circle : IConsoleOutput
	{
		protected virtual string FigureName => "Circle";
		private double r;

		public Point Center { get; set; }

		public double Radius
		{
			get => r;
			set
			{
				r = value;
				if (value < 0)
				{
					throw new ArgumentException("Radius should be positive");
				}
			}
		}

		public double Length
		{
			get => Radius * 2 * Math.PI;
		}

		public static bool operator >(Circle r1, Circle r2)
		{
			return r1.Radius > r2.Radius;
		}

		public static bool operator <(Circle r1, Circle r2)
		{
			return r1.Radius < r2.Radius;
		}

		public static bool operator ==(Circle r1, Circle r2)
		{
			return r1.Radius == r2.Radius;
		}

		public static bool operator !=(Circle r1, Circle r2)
		{
			return r1.Radius != r2.Radius;
		}
		public virtual string OutputsToConsole()
		{
			return string.Format("{5}:" +
								"{0}Center x,y: [{1}, {2}]" +
								"{0}Radius: {3}" +
								"{0}Length: {4}", Environment.NewLine,
								Center.X.ToString(),
								Center.Y.ToString(),
								Radius.ToString(),
								Length.ToString(),
								FigureName);
		}
	}
}
