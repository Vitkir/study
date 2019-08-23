using System;

namespace Round
{
    internal class Round : Circle
    {
        public double Area
        {
            get
            {
                return Math.PI * Radius * Radius;
            }
        }

        public override string ToString()
        {
            Console.Clear();
            return string.Format("Round:{5}Center [{0}, {1}];{5}Radius: {2};{5}Length: {3};{5}Area: {4}.",
                Center.X.ToString(), Center.Y.ToString(),
                Radius.ToString(), Length.ToString(),
                Area.ToString(), Environment.NewLine);
        }
    }
}
