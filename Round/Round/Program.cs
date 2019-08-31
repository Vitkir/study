﻿using System;

namespace Round
{
	class Program
	{
		public static void Main()
		{
			var round = GetRoundForConsole();
			Console.WriteLine(round);
			Console.ReadKey();
		}

		private static Round GetRoundForConsole()
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

		private static int GetValueForConsole()
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

		private static int GetPositiveValueForConsole()
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
