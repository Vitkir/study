using System;

namespace Round
{
    internal class Round : Figure
    {
        public Circle circle;

        override public Point Point
        {
            get => circle.Center;
            set => circle.Center = value;
        }

        override public double Area
        {
            get
            {
                return Math.PI * circle.Radius * circle.Radius;
            }
        }

        override public double Perimeter
        {
            get
            {
                return circle.Length;
            }
        }

        public override string ToString()
        {
            Console.Clear();
            return string.Format("Round:{5}Center [{0}, {1}];{5}Radius: {2};{5}Length: {3};{5}Area: {4}.",
                circle.Center.X.ToString(), circle.Center.Y.ToString(),
                circle.Radius.ToString(), circle.Length.ToString(),
                Area.ToString(), Environment.NewLine);
        }
    }
}
