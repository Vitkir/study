namespace ArraySort
{
	public static class BubbleSort
	{
		public static int MaxValue(int[] array)
		{
			int maxValue = 0;
			foreach (int value in array)
			{
				if (value > maxValue)
				{
					maxValue = value;
				}
			}
			return maxValue;
		}

		public static int MinValue(int[] array, int MaxValue)
		{
			int minValue = MaxValue;
			foreach (int value in array)
			{
				if (value < minValue)
				{
					minValue = value;
				}
			}
			return minValue;
		}

		static void Swap(ref int e1, ref int e2)
		{
			var temp = e1;
			e1 = e2;
			e2 = temp;
		}

		public static int[] GetSort(int[] sortArray)
		{
			var len = sortArray.Length;
			for (var j = 1; j < len; j++)
			{
				for (var k = 0; k < len - j; k++)
				{
					if (sortArray[k] > sortArray[k + 1])
					{
						Swap(ref sortArray[k], ref sortArray[k + 1]);
					}
				}
			}
			return sortArray;
		}
	}
}
