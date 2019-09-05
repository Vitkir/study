namespace GraphicEditorBlank
{
	public struct Point : IPrintable
	{
		private static string FigureName => "Point";

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

		public Point(double x, double y)
		{
			X = x;
			Y = y;
		}

		public string printable()
		{
			return string.Format($"{FigureName} [x,y]: [{X},{Y}]");
		}
	}
}
