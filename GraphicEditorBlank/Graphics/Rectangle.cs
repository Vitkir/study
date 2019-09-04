using System;

namespace Graphics
{
	class Rectangle : IConsoleOutput
	{
		private Point a;
		private Point b;
		private Point c;
		private Point d;

		public Point A
		{
			get => a;
			set
			{
				a = value;
				if (value != c)
				{
					A = AB.FirstPoint;
					A = AD.FirstPoint;
				}
				throw new ArgumentException("Point C cannot be equals point A.");
			}
		}

		public Point B
		{
			get => b;
			private set
			{
				b.X = a.X;
				b.Y = c.Y;
				B = AB.SecondPoint;
				B = BC.FirstPoint;
			}
		}

		public Point C
		{
			get => c;
			set
			{
				c = value;
				if (value != a)
				{
					C = BC.SecondPoint;
					C = CD.FirstPoint;
				}
				throw new ArgumentException("Point C cannot be equals point A.");
			}
		}

		public Point D
		{
			get => d;
			private set
			{
				d.X = c.X;
				d.Y = a.Y;
				D = CD.SecondPoint;
				D = AD.SecondPoint;
			}
		}

		public Line AB { get; set; }

		public Line BC { get; set; }

		public Line CD { get; set; }

		public Line AD { get; set; }

		public double Perimeter
		{
			get
			{
				return AB.Length + BC.Length +
						CD.Length + AD.Length;
			}
		}

		public double Area
		{
			get => AB.Length * BC.Length;
		}

		public Rectangle(Point a, Point c)
		{
			A = a;
			C = c;
			B = new Point();
			D = new Point();
			AB = new Line();
			BC = new Line();
			CD = new Line();
			AD = new Line();
		}

		public string OutputsToConsole()
		{
			return string.Format("Rectangle [A,B,C,D]:" +
								"{0}AB:{1}" +
								"{0}BC:{2}" +
								"{0}CD:{3}" +
								"{0}AD{4}{0}" +
								"Perimeter:{5}{0}" +
								"Area:{6}", Environment.NewLine,
								AB.Length,
								BC.Length,
								CD.Length,
								AD.Length,
								Perimeter,
								Area);
		}
	}
}


