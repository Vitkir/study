using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EPAM
{
    class Program2
    {
        static void Main(string[] args)
        {
            Circle[] circes ={
            new Circle(10),
            new Circle(12)};
            circes[0] = circes[1];
            //GC.Collect();
            //Thread.Sleep(2000);
        }
    }
    class Ring : Circle
    {
        public Ring(int innerRadius, int outerRadius)
            :base(outerRadius)
        {

        }
    }
    class Circle
    {
        public int x, y, r;
        private static string FigureName;
        static Circle()
        {
            FigureName = "Окружность";
        }
        public Circle(int r)
            :base()
        {
            if (r <= 0)
            {
                throw new ArgumentException("...");
            }
            this.r = r;
        }
        public Circle(int x, int y, int r)
        {
            this.x = x;
            this.y = y;
            this.r = r;
        }
        ~Circle()
        {
            Console.WriteLine("Удаление r= " + r);
        }
    }
    struct Point
    {
        public int x, y;

        public Point(int x)
            : this()
        {
            this.x = x;
        }
    }
}
