using System;

namespace Round
{
    internal struct Point
    {
        public double X { get; set; }

        public double Y { get; set; }

        public static bool operator ==(Point p1, Point p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        public static bool operator !=(Point p1, Point p2)
        {
            return !(p1 == p2);
        }

        //public override string ToString()
        //{
        //    return string.Format("Points [x,y]: [{0},{1}", X.ToString(), Y.ToString());
        //}
    }
}
