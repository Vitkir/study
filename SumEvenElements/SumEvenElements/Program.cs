using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumEvenElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[3, 3];
            Random random = new Random();
            Print(ArrayFilling(array, random));
            Console.WriteLine("\n Sum even elements: " + SumEvenElements(array));
            Console.ReadKey();
        }
        static int[,] ArrayFilling(int[,] array, Random random)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++) array[i, j] = random.Next(1, 40);
            }
            return array;
        }
        static int SumEvenElements(int[,] array)
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
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 1; j < array.GetLength(1); j++)
                {
                    Console.Write("{0,3}", array[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
