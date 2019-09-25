using System;

namespace ArraySort
{
    class Program
    {

        public static void Main()
        {
            int[] array = new int[10];
            Random random = new Random();
            Console.WriteLine("Unsorted array: {0}", string.Join(", ", FillArray(array, random)));
			int maxValue = BubbleSort.MaxValue(array);
            Console.WriteLine("Max value array: " + maxValue);
            int minValue = BubbleSort.MinValue(array, maxValue);
            Console.WriteLine("Min value array: " + minValue);
            Console.WriteLine("Sorted array: {0}", string.Join(", ", BubbleSort.GetSort(array)));
            Console.ReadKey();
        }

        static int[] FillArray(int[] unsortedArray, Random random)
        {
            for (var i = 0; i < unsortedArray.Length; i++)
            {
                unsortedArray[i] = random.Next(-40, 40);
            }
            return unsortedArray;
        }

    }
}
