using System;

namespace GraphicEditorBlank
{
	internal struct Line
	{
		public Point FirstPoint { get; set; }

		public Point SecondPoint { get; set; }

		public double Length
		{
			get
			{
				return Math.Sqrt(Math.Pow((SecondPoint.X - FirstPoint.X), 2) + 
								 Math.Pow((SecondPoint.Y - FirstPoint.Y), 2));
			}
		}

		public static bool operator <(Line l1, Line l2)
		{
			return l1.Length < l2.Length;
		}

		public static bool operator >(Line l1, Line l2)
		{
			return l1.Length > l2.Length;
		}

		public Line(Point p1, Point p2)
		{
			if (p1 != p2)
			{
				FirstPoint = p1;
				SecondPoint = p2;
			}
			else
			{
				throw new ArgumentException("Line cannot be created");
			}
		}
	}
}
