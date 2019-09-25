using System;

namespace Graphics
{
	public class Circle : IPrintable
	{
		protected virtual string FigureName => "Circle";
		private double r;

		public Point Center { get; set; }

		public double Radius
		{
			get => r;
			set
			{
				if (value < 0)
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

		public Circle(Point center, double radius)
		{
			Center = center;
			Radius = radius;
		}

		public virtual string Printable()
		{
			return string.Format("{5}:" +
								"{0}Center x,y: [{1}, {2}]" +
								"{0}Radius: {3}" +
								"{0}Length: {4}", Environment.NewLine,
								Center.X.ToString(),
								Center.Y.ToString(),
								Radius.ToString(),
								Length.ToString(),
								FigureName.ToString());
		}
	}
}
