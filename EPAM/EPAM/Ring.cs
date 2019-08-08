using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM
{
    class Program
    {
        private static void Main2(string[] args)
        {
            var round = new Round
            {
                Radius = 10
            };
            Console.WriteLine(round.Area);
            Console.ReadKey();
        }
    }
    internal class Circle2
    {
        private int r;

        public int Radius
        {
            get { return r; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Radius cannot de negative or zero");
                }
                r = value;
            }
        }
    }
    class Round : Circle2
    {
        public double Area
        {
            get
            {
                return Math.PI * Radius * Radius;
            }
        }
    }


}
