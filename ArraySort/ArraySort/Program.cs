using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySort
{
    class Program
    {

        public static void Main(string[] args)
        {
            int[] array = new int[20];
            Random random = new Random();
            Console.WriteLine("Unsorted array:");
            ArrayFilling(array, random);
            Console.WriteLine("Отсортированный массив: {0}", string.Join(", ", BubbleSort(array)));
            Console.ReadKey();
        }
        static int[] ArrayFilling(int[] unsortedArray, Random random)
        {
            for (var i = 0; i < unsortedArray.Length; i++)
            {
                unsortedArray[i] = random.Next(1, 40);
                Console.WriteLine(unsortedArray[i]);
            }
            return unsortedArray;
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
