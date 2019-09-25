using System;
using System.Collections.Generic;
using Graphics;
using static GraphicEditorBlank.Enums;

namespace GraphicEditorBlank
{
	class Program
	{
		static private List<IPrintable> figures = new List<IPrintable>();

		static void Main()
		{
			int index;
			ConsoleKeyInfo input;
			do
			{
				Console.WriteLine($"Figures count: {figures.Count.ToString()}");
				ShowMenuList();
				input = Console.ReadKey();
				if (input.Key == ConsoleKey.Escape)
				{
					return;
				}
				Menu menuItem;
				Enum.TryParse(input.KeyChar.ToString(), out menuItem);
				switch (menuItem)
				{
					case Menu.Create:
						AddFigure(figures);
						break;
					case Menu.Delete:
						index = GetIndexFromConsole();
						DeleteFigure(figures, index);
						break;
					case Menu.ShowAll:
						Console.Clear();
						ShowAllFigures(figures);
						break;
					default:
						Console.Clear();
						break;
				}
			}
			while (true);
		}

		public static void AddFigure(List<IPrintable> figures)
		{
			Console.Clear();
			ShowFiguresList();
			ConsoleKeyInfo input = Console.ReadKey();
			Figures figuresItem;
			Enum.TryParse(input.KeyChar.ToString(), out figuresItem);
			switch (figuresItem)
			{
				case Figures.Line:
					figures.Add(GetLineFromConsole());
					break;
				case Figures.Rectangle:
					figures.Add(GetRectangleFromConsole());
					break;
				case Figures.Triangle:
					figures.Add(GetTriangleFromConsole());
					break;
				case Figures.Circle:
					figures.Add(GetCircleFromConsole());
					break;
				case Figures.Round:
					figures.Add(GetRoundFromConsole());
					break;
				case Figures.Ring:
					figures.Add(GetRingFromConsole());
					break;
			}
		}

		private static void ShowMenuList()
		{
			var index = 1;
			foreach (string name in Enum.GetNames(typeof(Menu)))
			{
				Console.WriteLine($"{index}.{name}");
				index++;
			}
		}

		private static void ShowFiguresList()
		{
			var index = 1;
			foreach (string name in Enum.GetNames(typeof(Figures)))
			{
				Console.WriteLine($"{index}.{name}");
				index++;
			}
		}

		private static double GetValueFromConsole()
		{
			double result;
			Console.WriteLine("Set value{0}", Environment.NewLine);
			while (!double.TryParse(Console.ReadLine(), out result))
			{
				Console.Write("Value is not valid, only numbers allowed.{0}Set value: ", Environment.NewLine);
			}
			return result;
		}

		private static int GetIndexFromConsole()
		{
			int result;
			Console.WriteLine("Set value");
			while (!int.TryParse(Console.ReadLine(), out result) && result < 0)
			{
				Console.Write("Value is not valid, only positive numbers allowed.{0}Set value: ", Environment.NewLine);
			}
			return result;
		}

		private static Point GetPointFromConsole()
		{
			Console.WriteLine($"Set coordinates point");
			return new Point(GetValueFromConsole(), GetValueFromConsole());
		}

		private static Line GetLineFromConsole()
		{
			Console.WriteLine($"Create new line. Set two points");
			return new Line(GetPointFromConsole(), GetPointFromConsole());
		}

		private static Rectangle GetRectangleFromConsole() =>
			new Rectangle(GetPointFromConsole(), GetPointFromConsole());

		private static Triangle GetTriangleFromConsole() =>
			new Triangle(GetPointFromConsole(), GetPointFromConsole(), GetPointFromConsole());

		private static Circle GetCircleFromConsole()
		{
			Console.WriteLine("Create new Circle. Set coordinates of center and radius");
			return new Circle(GetPointFromConsole(), GetValueFromConsole());
		}

		private static Round GetRoundFromConsole()
		{
			Console.WriteLine("Create new round. Set coordinates of center and radius");
			return new Round(GetPointFromConsole(), GetValueFromConsole());
		}

		private static Ring GetRingFromConsole()
		{
			Console.WriteLine("Create new Ring. Set coordinates of center, inners and outers radius");
			return new Ring(GetRoundFromConsole(), GetValueFromConsole());
		}

		private static void DeleteFigure(List<IPrintable> figure, int figureIndex)
		{
			if (figure.Count > 0 && figure.Count > figureIndex)
			{
				figure.Remove(figure[figureIndex]);
			}
			else
			{
				Console.WriteLine("Such an index does not exist");
			}
		}

		private static void ShowAllFigures(List<IPrintable> figures)
		{
			foreach (IPrintable figure in figures)
			{
				Console.WriteLine("Index figure [{0}]{1}{2}{1}",
					figures.IndexOf(figure).ToString(),
					Environment.NewLine,
					figure.Printable());
			}
		}
	}
}
