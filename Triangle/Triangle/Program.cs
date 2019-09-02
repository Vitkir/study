using System;

namespace Triangle
{
	internal class Program
	{
		internal static void Main()
		{
			var triangle = GetTriangleFromConsole();
			ChangeTrianglesPoint(triangle);
		}

		private static void PointListShow()
		{
			int Index = 1;
			foreach (string name in Enum.GetNames(typeof(TrianglePoint)))
			{
				Console.WriteLine($"{Index} :{name}");
				Index++;
			}
		}

		private static int GetValueFromConsole()
		{
			int value;
			Console.Write("Set value: ");
			while (!int.TryParse(Console.ReadLine(), out value))
			{
				Console.Write("Value is not valid.{0}Set valid value: ", Environment.NewLine);
			}
			return value;
		}

		private static ConsoleKeyInfo GetConsoleKey()
		{
			return Console.ReadKey();
		}

		private static Point GetPointFromConsole()
		{
			Console.WriteLine("Set point [x,y]:");
			return new Point
			{
				X = GetValueFromConsole(),
				Y = GetValueFromConsole()
			};
		}

		private static Triangle GetTriangleFromConsole()
		{
			Console.WriteLine("Create new Triangle. Set points: [A,B,C].");
			return new Triangle(GetPointFromConsole(), GetPointFromConsole(), GetPointFromConsole());
		}

		private static Triangle ChangeTrianglesPoint(Triangle triangle)
		{
			ConsoleKeyInfo input;
			do
			{
				Console.WriteLine(triangle);
				PointListShow();
				input = GetConsoleKey();
				switch (input.KeyChar)
				{
					case '1':
						triangle.A = GetPointFromConsole();
						break;
					case '2':
						triangle.B = GetPointFromConsole();
						break;
					case '3':
						triangle.C = GetPointFromConsole();
						break;
				}
			}
			while (input.Key != ConsoleKey.Escape);
			return triangle;
		}

		private enum TrianglePoint
		{
			a = 1,
			b,
			c
		}
	}
}