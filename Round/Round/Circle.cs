using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Round
{
    internal class Circle
    {
        private int r;
        private double length;

        public int X { get; set; }

        public int Y { get; set; }

        public int Radius
        {
            get => r;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Radius should be positive");
                }
                r = value;
            }
        }

        public double Length
        {
            get
            {
                return length = Radius * 2 * Math.PI;
            }
        }

        public Circle()
        {
            X = 0;
            Y = 0;
            r = Radius;
        }
    }
}
