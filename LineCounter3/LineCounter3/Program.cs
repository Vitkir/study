using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineCounter3
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
                Console.WriteLine("Enter num");
                bool Lines = int.TryParse(Console.ReadLine(), out i);
                if (!Lines)
                {
                    Console.WriteLine("Enter num");

                }
                Console.Clear();
            }
            while (i <= 0);
            int r = 1;
            do
            {
                int sum = 1;
                for (int x = 1; x <= r; x++)
                {
                    //Console.SetCursorPosition(left = i - x, top = x);
                    Console.WriteLine(new string('*', sum));
                    sum = sum + 2;
                }
                r++;
            }
            while (r <= i);
            Console.ReadKey();
        }
    }
}
