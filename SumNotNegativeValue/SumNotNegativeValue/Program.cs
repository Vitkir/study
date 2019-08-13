using System;

namespace SumNotNegativeValue
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];
            Random random = new Random();
            Console.WriteLine("Array: {0}", string.Join(", ", ArrayFilling(array, random)));
            Console.WriteLine("Sum not negative value = " + SumNotNegativeValue(array));
            Console.ReadKey();
        }
        static int[] ArrayFilling(int[] array, Random random)
        {
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-15, 15);
            }
            return array;
        }
        static int SumNotNegativeValue(int[] array)
        {
            int sum = 0;
            foreach (int i in array)
            {
                if (i >= 0) sum += i;
            }
            return sum;
        }
    }
}
