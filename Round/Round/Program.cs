using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Round
{
    class Program
    {
        public static void Main(string[] args)
        {
            var round = GetRound();
            Console.WriteLine(round);
            Console.ReadKey();
        }

        private static Round GetRound()
        {
            return new Round()
            {
                X = SetValue(),
                Y = SetValue(),
                Radius = SetPositiveValue()
            };
        }

        private static int SetValue()
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Set valid value");
            }
            return value;
        }
        private static int SetPositiveValue()
        {
            int positiveValue;
            while ((positiveValue = SetValue()) <= 0)
            {
                Console.WriteLine("Set positive value");
            }
            return positiveValue;
        }
    }
}
