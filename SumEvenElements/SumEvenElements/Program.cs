using System;
using System.Text;

namespace SumEvenElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[3, 3];
            Random random = new Random();
            FillArrayRandomNumbers(array, random);
            Print(array);
            Console.WriteLine(" Sum even elements: " + SumsArrayElementsAtEvenPositions(array));
            Console.ReadKey();
        }

        static void FillArrayRandomNumbers(int[,] array, Random random)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++) array[i, j] = random.Next(1, 40);
            }
        }

        static int SumsArrayElementsAtEvenPositions(int[,] array)
        {
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 1; j < array.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0) sum += array[i, j];
                }
            }
            return sum;
        }
        static void Print(int[,] array)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 1; j < array.GetLength(1); j++)
                {
                    stringBuilder.Append(array[i, j] + " ");
                }
                Console.WriteLine(stringBuilder);
                stringBuilder.Clear();
            }
        }
    }
}
