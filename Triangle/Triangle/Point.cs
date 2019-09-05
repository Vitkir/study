using System;

namespace GraphicEditorBlank
{
	internal struct Point
	{
		public double X { get; set; }

		public double Y { get; set; }

		public static bool operator ==(Point p1, Point p2)
		{
			return p1.X == p2.X && p1.Y == p2.Y;
		}

		public static bool operator !=(Point p1, Point p2)
		{
			return !(p1 == p2);
		}
	}
}
