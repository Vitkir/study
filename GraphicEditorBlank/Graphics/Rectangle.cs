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
				A = AB.FirstPoint;
				A = AD.FirstPoint;
			}
		}

		public Point B
		{
			get
			{
			return b=
			}
			private set
			{
				B = AB.SecondPoint;
				B = BC.FirstPoint;
			}
		}

		public Point C
		{
			get => c;
			private set
			{
				c = value;
				C = BC.SecondPoint;
				C = CD.FirstPoint;
			}
		}

		public Point D
		{
			get => d;
			private set
			{
				D = CD.SecondPoint;
				D = AD.SecondPoint;
			}
		}

		public Line AB { get; set; }

		public Line BC { get; set; }

		public Line CD { get; set; }

		public Line AD { get; set; }

		public Rectangle(Point p1, Point p2)
		{
			if (p1 != p2)
			{
				A = p1;
				C = p2;
			}
			else throw new ArgumentException("Uncrrected coordinates point C. Point C equals point A.");
		}

		public string OutputsToConsole()
		{
			return string.Format("");
		}
	}
}


