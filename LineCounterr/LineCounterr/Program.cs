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
            int i;
            do
            {
                bool Lines = int.TryParse(Console.ReadLine(), out i);
                if (!Lines)
                {
                    Console.WriteLine("Enter num");

                }
            }
            while (i <= 0);
            for (int x = 1; x <= i; x++)
            {
                Console.WriteLine(new string('*', x));
            }
            Console.ReadKey();
        }
    }
}

