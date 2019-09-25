using System;

namespace ArraySorting
{
	class Program
	{
		static void Main()
		{
			Compare<int> compare = CompareInt;
			int[] vs = new int[0];
			vs.Sort(compare);
		}
		public static int CompareInt(int item1, int item2)
		{
			if (item1 > item2)
				return 1;
			else if (item2 > item1)
				return -1;
			else return 0;
		}
	}
}
