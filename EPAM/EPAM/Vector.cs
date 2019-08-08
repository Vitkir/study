using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM
{
    class Program3
    {
        static void Main3(string[] args)
        {
            var v1 = new Vector { X = 1, Y = 4 };
            var v2 = new Vector { X = 2, Y = 8 };

            var v3 = -v2;
            var v4 = v1 + v2;
        }
    }
    class Vector
    {
        public int X { get; set; }
        public int Y { get; set; }
        public override string ToString()
        {
            return string.Format("({0}; {1})", X, Y);
        }
        public static Vector operator -(Vector v)
        {
            return new Vector { X = -v.X, Y = -v.Y };
        }
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector { X = v1.X + v2.X, Y = v1.Y + v2.Y };
        }
    }
}
