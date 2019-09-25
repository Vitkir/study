using System;

namespace ArraySorting
{
	public delegate int Compare<T>(T item1, T item2);

	public static class ArrayExtensionMethod
	{
		public static void Sort<T>(this Array array, Compare<T> compare)
		{

		}
	}
}
