namespace ArraySorting
{
	public delegate int Compare<T>(T item1, T item2);

	public static class ArrayExtensionMethod
	{
		static void StoogeSort<T>(T[] array, int startIndex, int endIndex, Compare<T> compare)
		{
			if (compare(array[startIndex], array[endIndex]) == -1)
			{
				var temp = array[startIndex];
				array[startIndex] = array[endIndex];
				array[endIndex] = temp;
			}

			if (endIndex - startIndex > 1)
			{
				int len = (endIndex - startIndex + 1) / 3;
				StoogeSort(array, startIndex, endIndex - len, compare);
				StoogeSort(array, startIndex + len, endIndex, compare);
				StoogeSort(array, startIndex, endIndex - len, compare);
			}
		}

		public static void StoogeSort<T>(this T[] array, Compare<T> compare)
		{
			StoogeSort(array, 0, array.Length - 1, compare);
		}
	}
}
