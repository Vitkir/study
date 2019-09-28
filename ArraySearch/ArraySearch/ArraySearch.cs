using System;

namespace ArraySearch
{
	static class ArraySearch
	{
		public delegate bool IsEquals(int item);

		public static void GetNumbers(int[] array, Action<int> print)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] > 0)
					print(array[i]);
			}
			Console.WriteLine();
		}

		public static void GetNumbers(int[] array, IsEquals condition, Action<int> print)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (condition(array[i]))
					print(array[i]);
			}
			Console.WriteLine();
		}
	}
}
