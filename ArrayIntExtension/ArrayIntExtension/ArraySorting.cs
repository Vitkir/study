using System.Threading;

namespace ArraySorting
{

	public class ArraySort<T>
	{
		public delegate int Compare(T item1, T item2);
		public delegate void Print(T[] array);

		public static event Print printToConsole;

		private static void StoogeSort(T[] array, int startIndex, int endIndex, Compare compare)
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

		public static void StoogeSort(T[] array, Compare compare)
		{
			StoogeSort(array, 0, array.Length - 1, compare);
			printToConsole(array);
		}

		public static void SortInStream(T[] array, Compare compare)
		{
			Thread thread = new Thread(() => StoogeSort(array, compare));
			thread.Start();
		}
	}
}
