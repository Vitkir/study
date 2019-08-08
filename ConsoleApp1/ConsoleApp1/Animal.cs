using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Animal
    {
        public string Name { get; set; }
        public virtual void GetRoar()
        {
            Console.WriteLine("Random noise");
        }
    }
    class Cat : Animal
    {
        public override void GetRoar()
        {
            Console.WriteLine("raz raz raz");
        }
    }
    class Dog : Animal
    {
        public override void GetRoar()
        {
            Console.WriteLine("gav gav gav");
        }
    }
    class Rat : Animal
    {
        public override void GetRoar()
        {
            Console.WriteLine("abvg abvg");
        }
    }
}
