using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineCounter2
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            int left;
            int top;
            do
            {
                bool Lines = int.TryParse(Console.ReadLine(), out i);
                if (!Lines)
                {
                    Console.WriteLine("Enter num");

                }
            }
            while (i <= 0);
            int sum = 1;
            for (int x = 1; x <= i; x++)
            {
                Console.SetCursorPosition(left = i - x, top = x);
                Console.WriteLine(new string('*', sum));
                sum = sum + 2;
            }
            Console.ReadKey();
        }
    }

}
