using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter value:");
            string x = Console.ReadLine();
            int a = Convert.ToInt32(x);
            a = a * a;
            Console.WriteLine(a);
            Console.ReadKey();
        }
    }
}
