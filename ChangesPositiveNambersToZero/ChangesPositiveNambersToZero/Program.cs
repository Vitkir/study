using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangesPositiveNambersToZero
{
    class Program
    {
        static void Main(string[] args)
        {
            int arraySize = 2;
            int[,,] array = new int[arraySize, arraySize, arraySize];
            Random random = new Random();
            int[,,] array1 = ArrayFilling(array, random, arraySize);
            Print(array1);
            int[,,] array2 = ChangePositiveValueFromArray(array, arraySize);
            Print(array2);
            Console.ReadKey();
        }
        static int[,,] ArrayFilling(int[,,] array, Random random, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        array[i, j, k] = random.Next(-50, 50);
                    }
                }
            }
            return array;
        }

        static int[,,] ChangePositiveValueFromArray(int[,,] array, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        if (array[i, j, k] > 0) array[i, j, k] = 0;
                    }
                }
            }
            return array;
        }

        static void Print(int[,,] array)
        {
            Console.WriteLine();
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
        }
    }
}
