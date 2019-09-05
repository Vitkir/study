using System;

namespace GameTemplate
{
	public class Map
	{
		public static double Width { get; }
		public static double Height { get; }

		public struct Point
		{
			private double x;
			private double y;

			public double X
			{
				get => x;
				set
				{
					if (value > 0 && value < Width)
					{
						x = value;
					}
					throw new ArgumentException();
				}
			}

			public double Y
			{
				get => y;
				set
				{
					if (value > 0 && value < Height)
					{
						y = value;
					}
					throw new ArgumentException();
				}
			}
		}
	}
}
