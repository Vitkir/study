using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Round;

namespace Triangle
{
    internal class Triangle : Figure
    {
        private Point a;
        private Point b;
        private Point c;

        public Point A
        {
            get => a;
            set
            {
                a = value;
                AB = new Line(A, AB.SecondPoint);
                AC = new Line(A, AC.SecondPoint);
            }
        }

        public Point B
        {
            get => b;
            set
            {
                b = value;
                AB = new Line(AB.FirstPoint, B);
                BC = new Line(B, AB.SecondPoint);
            }
        }

        public Point C
        {
            get => c;
            set
            {
                c = value;
                AC = new Line(AC.FirstPoint, C);
                BC = new Line(AC.FirstPoint, C);
            }
        }

        public Line AB { get; set; }

        public Line BC { get; set; }

        public Line AC { get; set; }

        public double Perimeter
        {
            get
            {
                return AB.Length + BC.Length + AC.Length;
            }
        }

        public override double Area
        {
            get
            {
                var halfP = Perimeter / 2;
                return Math.Sqrt(halfP * (halfP - AB.Length) * (halfP - BC.Length) * (halfP - AC.Length));
            }
        }

        public Triangle(Point p1, Point p2, Point p3)
        {
            A = p1;
            B = p2;
            C = p3;

            AB = new Line(A, B);

            BC = new Line(B, C);

            AC = new Line(A, C);

            if (AB.Length + BC.Length > AC.Length &&
                AB.Length + AC.Length > BC.Length &&
                BC.Length + AC.Length > AB.Length)
            {

            }
            else
            {
                throw new ArgumentException("Objet cannot be created");
            }
        }

        public override string ToString()
        {
            return string.Format("Triangle:{0}Length AB={1}{0}Length BC={2}{0}Length AC={3}{0}" +
                                "Perimeter = {4}{0}Area ={5}{0}" +
                                "Point A: {6};{7}{0}" +
                                "Point B: {8};{9}{0}" +
                                "Point C: {10};{11}",
                Environment.NewLine, AB.Length.ToString(), BC.Length.ToString(),
                AC.Length.ToString(), Perimeter.ToString(), Area.ToString(),
                A.X.ToString(), A.Y.ToString(),
                B.X.ToString(), B.Y.ToString(),
                C.X.ToString(), C.Y.ToString());
        }
    }
}
