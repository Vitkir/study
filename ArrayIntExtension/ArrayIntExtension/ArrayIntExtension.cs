namespace ArrayIntExtension
{
	public static class ArrayIntExtension
	{
		public static int SumArrayElements(this int[] array)
		{
			int sum = 0;
			foreach (var item in array)
			{
				sum += item;
			}
			return sum;
		}
	}
}
