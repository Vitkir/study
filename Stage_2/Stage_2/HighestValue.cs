using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage_2
{
    class HighestValue
    {
        public int GetMax(params int[] args)
        {
            int result = args[0];
            for (int i=0;i<args.Length;i++)
            {
                if (result < args[i])
                {
                    result = args[i];
                }
            }
            return result;
        }
        public string GetMax(string a, string b)
        {
            return a.Length > b.Length ? a : b;
        }
    }
}
