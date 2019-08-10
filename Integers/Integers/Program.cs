using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO: remove unnecessary usings
//TODO: calculate result with arithmetic sum
//TODO: all local variables should be lowercase
namespace Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int X;
            Console.WriteLine("Enter num");
            bool value = int.TryParse(Console.ReadLine(), out X);
            if (!value)
            {
                Console.WriteLine("Enter correct num");
                if(X<=0)
                {

                    Console.WriteLine("Enter num >= 0");
                }
            }
            int sum1 = 0;
            for(int i = 1; i < X; i++)
            {
                if(i%3==0)
                {
                    sum1 = sum1 + i;
                }
            }
            int sum2 = 0;
            for (int i = 1; i < X; i++)
            {
                if (i % 5 == 0)
                {
                    sum2 = sum2 + i;
                }
            }
            int sum3 = sum1 + sum2;
            Console.WriteLine(sum3);
            Console.ReadKey();
        }
    }
}
