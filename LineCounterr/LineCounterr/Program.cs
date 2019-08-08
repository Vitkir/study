using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineCounterr
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowCount = ReadPositiveValue();
            Draw(rowCount);
            Console.ReadKey();
        }

        private static void Draw(int rowCount)
        {
            for (int i = 1; i <= rowCount; i++)
            {
                Console.WriteLine(new string('*', i));
            }
        }

        private static int ReadPositiveValue()
        {
            int value;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out value))
                {
                    Console.WriteLine("Enter num");
                }
            }
            while (value <= 0);
            return value;
        }
    }
}

