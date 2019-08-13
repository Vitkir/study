using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._6
{

    enum HttpResponses : byte
    {
        Ok = 200,
        NotFound = 255,
        Redirect = 1,
        ServerError = 3,
    }

    struct Triangle
    {
        public int AB { get; set; }
        public int BC { get; set; }
        public int CD { get; set; }

        public Triangle(int ab, int  bc, int cd)
        {
            AB = ab;
            BC = bc;
            CD = cd;
        }
    }

    class TriangleClass
    {
        public int AB { get; set; }
        public int BC { get; set; }
        public int CD { get; set; }

        public TriangleClass(int ab, int bc, int cd)
        {
            AB = ab;
            BC = bc;
            CD = cd;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            HttpResponses httpRespons = HttpResponses.Ok;
            httpRespons = (HttpResponses)600;
        }
    }
}
