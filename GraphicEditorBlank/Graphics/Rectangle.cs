using System;

namespace Graphics
{
	public class Rectangle : IPrintable
	{
		private Point b;
		private Point d;

		public Point A { get; set; }

		public Point B
		{
			get => b;
			private set
			{
				b.X = A.X;
				b.Y = C.Y;
			}
		}

		public Point C { get; set; }

		public Point D
		{
			get => d;
			private set
			{
				d.X = C.X;
				d.Y = A.Y;
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
			if (a == c)
			{
				throw new ArgumentException("Point C cannot be equals point A.");
			}
			A = a;
			C = c;
			B = new Point();
			D = new Point();
			AB = new Line(A, B);
			BC = new Line(B, C);
			CD = new Line(C, D);
			AD = new Line(A, D);
		}

		public string printable()
		{
			return string.Format("Rectangle [A,B,C,D]:" +
								"{0}AB:{1}" +
								"{0}BC:{2}" +
								"{0}CD:{3}" +
								"{0}AD{4}{0}" +
								"Perimeter:{5}{0}" +
								"Area:{6}", Environment.NewLine,
								AB.Length.ToString(),
								BC.Length.ToString(),
								CD.Length.ToString(),
								AD.Length.ToString(),
								Perimeter.ToString(),
								Area.ToString());
		}
	}
}


