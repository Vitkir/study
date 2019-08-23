using System;

namespace Round
{
    internal class Circle
    {
        private int r;

        public Point Center { get; set; }

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
                return Radius * 2 * Math.PI;
            }
        }
    }
}
