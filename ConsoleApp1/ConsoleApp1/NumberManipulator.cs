using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class NumberManipulator
    {
        public int FindMax(int first, int second)
        {
            int result; //Здесь хранится наиболшее значение
            if(first>second)
            {
                result = first;
            }
            else
            {
                result = second;
            }
            return result;
        }
    }
}
