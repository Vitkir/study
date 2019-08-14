using System;

namespace ChangesPositiveNambersToZero
{
    class Program
    {
        static void Main(string[] args)
        {
            int arraySize = 2;
            int[,,] array = new int[arraySize, arraySize, arraySize];
            Random random = new Random();
            int[,,] array1 = ArrayFilling(array, random);
            Print(array1);
            int[,,] array2 = ChangePositiveValueFromArray(array);
            Print(array2);
            Console.ReadKey();
        }
        static int[,,] ArrayFilling(int[,,] array, Random random)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        array[i, j, k] = random.Next(-50, 50);
                    }
                }
            }
            return array;
        }

        static int[,,] ChangePositiveValueFromArray(int[,,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
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
