using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_override
{
    class Program
    {
        static void Main(string[] args)
        {
            Figure[] figures =
            {
                new Rect{Height=10,Width=5 },
                new Rect{Height=2,Width=5},
                new Round{Radius=10},
            };
            foreach (var figure in figures)
            {
                Console.WriteLine(figure.Area);
            }
            Console.ReadKey();
        }
    }
    abstract class Figure
    {
        public int X { get; set; }
        public int Y { get; set; }
        public abstract void Draw();
        public abstract double Area { get; }
    }
    class Rect : Figure
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public override void Draw()
        {
            Console.WriteLine("Rect");
        }
        public override double Area
        {
            get
            {
                return Width * Height;
            }
        }
    }
    class Round : Figure
    {
        public int Radius { get; set; }
        public override void Draw()
        {
            Console.WriteLine("Round");
        }
        public override double Area
        {
            get
            {
                return Math.PI*Radius*Radius;
            }
        }
    }
}

    

