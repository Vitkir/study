using System;

namespace Graphics
{
	public class Rectangle : IPrintable
	{
		private Point a;
		private Point b;
		private Point c;
		private Point d;
		private Line ab;
		private Line bc;
		private Line cd;
		private Line ad;

		private Exception exception = new ArgumentException("Point C cannot be equals point A, C.X cannot be equals A.X, C.Y cannot be equals A.Y.");

		public Point A
		{
			get => a;
			set
			{
				if (value.X == c.X || value.Y == c.Y)
				{
					throw exception;
				}
				a = value;
				b.X = a.X;
				d.Y = a.Y;
				ab.FirstPoint = a;
				ab.SecondPoint = b;
				ad.FirstPoint = a;
				ad.SecondPoint = d;
				bc.FirstPoint = b;
				cd.SecondPoint = d;
			}
		}

		public Point B => b;

		public Point C
		{
			get => c;
			set
			{
				if (value.X == a.X || value.Y == a.Y)
				{
					throw exception;
				}
				c = value;
				b.Y = c.Y;
				d.X = a.X;
				bc.FirstPoint = b;
				bc.SecondPoint = c;
				cd.FirstPoint = c;
				cd.SecondPoint = d;
				ab.SecondPoint = b;
				ad.SecondPoint = d;
			}
		}

		public Point D => d;

		public Line AB => ab;

		public Line BC => bc;

		public Line CD => cd;

		public Line AD => ad;

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
			if (a.X == c.X || a.Y == c.Y)
			{
				throw exception;
			}
			A = a;
			C = c;
			b = new Point(A.X, C.Y);
			d = new Point(C.X, A.Y);
			ab = new Line(A, B);
			bc = new Line(B, C);
			cd = new Line(C, D);
			ad = new Line(A, D);
		}

		public string Printable()
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


