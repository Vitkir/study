using System;

namespace ArraySort
{
    class Program
    {

        public static void Main(string[] args)
        {
            int[] array = new int[10];
            Random random = new Random();
            Console.WriteLine("Unsorted array: {0}", string.Join(", ", FillArray(array, random)));
            int maxValue = MaxValue(array);
            Console.WriteLine("Max value array: " + maxValue);
            int minValue = MinValue(array, maxValue);
            Console.WriteLine("Min value array: " + minValue);
            Console.WriteLine("Sorted array: {0}", string.Join(", ", BubbleSort(array)));
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

        static int MaxValue(int[] array)
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

        static int MinValue(int[] array, int MaxValue)
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

        static int[] BubbleSort(int[] sortArray)
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
