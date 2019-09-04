using System;

namespace Graphics
{
	public class Program
	{
		public static void Main()
		{
			var round = GetRoundForConsole();
			Console.WriteLine(round);
			Console.ReadKey();
		}

		public static Round GetRoundForConsole()
		{
			Console.WriteLine("Create new Round. Set coordinates [x,y] and radius.");
			return new Round()
			{
				Center = new Round.Point
				{
					X = GetValueForConsole(),
					Y = GetValueForConsole()
				},
				Radius = GetPositiveValueForConsole()
			};
		}

		public static int GetValueForConsole()
		{
			int value;
			Console.WriteLine("Set value");
			while (!int.TryParse(Console.ReadLine(), out value))
			{
				Console.Clear();
				Console.WriteLine("Set valid value");
			}
			return value;
		}

		public static int GetPositiveValueForConsole()
		{
			int positiveValue;
			while ((positiveValue = GetValueForConsole()) <= 0)
			{
				Console.Clear();
				Console.WriteLine("Set positive value");
			}
			return positiveValue;
		}
	}
}
