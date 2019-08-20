using System;
using System.Text;

namespace ChangesPositiveNambersToZero
{
    class Program
    {
        static void Main(string[] args)
        {
            int arraySize = 2;
            int[,,] array = new int[arraySize, arraySize, arraySize];
            Random random = new Random();
            ArrayFilling(array, random);
            Print(array);
            ChangePositiveValueFromArray(array);
            Print(array);
            Console.ReadKey();
        }

        static void ArrayFilling(int[,,] array, Random random)
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
        }

        static void ChangePositiveValueFromArray(int[,,] array)
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
        }

        static void Print(int[,,] array)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (int i in array)
            {
                stringBuilder.Append(i + " ");
            }
            Console.WriteLine(stringBuilder);
        }
    }
}
