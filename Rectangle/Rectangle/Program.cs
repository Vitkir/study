using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangle
{
    class Program
    {
        static void Main()
        {
            int a;
            int b;
            Console.WriteLine("Enter value length");
            do
            {
                bool length = int.TryParse(Console.ReadLine(), out a);
                if (!length)
                {
                    Console.WriteLine("Enter another value");
                }
            }
            while (a <= 0);
            
            Console.WriteLine("Enter value widgh");
            do
            {
                bool widgh = int.TryParse(Console.ReadLine(), out b);
                if (!widgh)
                {
                    Console.WriteLine("Enter another value");
                }
            }
            while (b <= 0);
            int s = a * b;

            Console.WriteLine("Rectangle area = " + s);
            Console.ReadKey();
        }
    }
}


