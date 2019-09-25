using System;

namespace Graphics
{
	public class Triangle : IPrintable
	{
		protected string FigureName => "Triangle";
		private Point a;
		private Point b;
		private Point c;
		private Line ab;
		private Line bc;
		private Line ac;

		public Point A
		{
			get => a;
			set
			{
				CheckNotBelongToOneLine(value, b, c);
				a = value;
				ac.FirstPoint = a;
				ab.FirstPoint = a;
			}
		}

		public Point B
		{
			get => b;
			set
			{
				CheckNotBelongToOneLine(a, value, c);
				b = value;
				ab.SecondPoint = b;
				bc.FirstPoint = b;
			}
		}

		public Point C
		{
			get => c;
			set
			{
				CheckNotBelongToOneLine(a, b, value);
				c = value;
				bc.SecondPoint = c;
				ac.SecondPoint = c;
			}
		}

		public Line AB => ab;

		public Line BC => bc;

		public Line AC => ac;

		public double Perimeter
		{
			get
			{
				return AB.Length + BC.Length + AC.Length;
			}
		}

		public double Area
		{
			get
			{
				var halfP = Perimeter / 2;
				return Math.Sqrt(halfP * (halfP - AB.Length) * (halfP - BC.Length) * (halfP - AC.Length));
			}
		}

		public Triangle(Point p1, Point p2, Point p3)
		{
			A = p1;
			B = p2;
			C = p3;

			ab = new Line(A, B);

			bc = new Line(B, C);

			ac = new Line(A, C);

			if (AB.Length + BC.Length <= AC.Length &&
				AB.Length + AC.Length <= BC.Length &&
				BC.Length + AC.Length <= AB.Length)
			{
				throw new ArgumentException("Objet cannot be created");
			}
		}

		public string Printable()
		{
			return string.Format("{12}:{0}Length AB={1}{0}Length BC={2}{0}Length AC={3}{0}" +
								"Perimeter = {4}{0}Area ={5}{0}" +
								"Point A: {6};{7}{0}" +
								"Point B: {8};{9}{0}" +
								"Point C: {10};{11}",
				Environment.NewLine, AB.Length.ToString(), BC.Length.ToString(),
				AC.Length.ToString(), Perimeter.ToString(), Area.ToString(),
				A.X.ToString(), A.Y.ToString(),
				B.X.ToString(), B.Y.ToString(),
				C.X.ToString(), C.Y.ToString(),
				FigureName.ToString());
		}
		private void CheckNotBelongToOneLine(Point a, Point b, Point c)
		{
			if ((c.X - a.X) / (b.X - a.X) == (c.X - a.Y) / (b.Y - a.Y))
				throw new ArgumentException("Points cannot belong to one line.");
		}
	}
}
