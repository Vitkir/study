using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return string.Format("Center [{0}, {1}];{5}Radius: {2};{5}Length: {3};{5}Area: {4}.", X.ToString(), Y.ToString(), Radius.ToString(), Length.ToString(), Area.ToString(), Environment.NewLine);
        }
    }
}
