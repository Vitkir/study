using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage_2
{
    class MaxValue
    {
        static void Main(string[] args)
        {
            HighestValue highestValue = new HighestValue();
            Console.WriteLine(highestValue.GetMax(1, 10));
            Console.WriteLine(highestValue.GetMax("asa0", "asdasff"));
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine(highestValue.GetMax(arr));
            Console.ReadKey();
        }
    }
}
