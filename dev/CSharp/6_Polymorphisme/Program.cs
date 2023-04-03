using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Polymorphisme
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicule v;
            if (Console.ReadLine() == "A")
            {
                v = new Auto();
            }
            else
            {
                v = new Moto();
            }
            v.Rouler();
        }
    }
    class Vehicule
    {
        public virtual void Rouler()
        {
            Console.WriteLine("Le véhicule roule");
        }
    }
    class Auto : Vehicule
    {
        public override void Rouler()
        {
            Console.WriteLine("L'auto roule");
        }
    }
    class Moto : Vehicule
    {
        public override void Rouler()
        {
            Console.WriteLine("La moto roule");
        }
    }
    class Kawasaki : Moto
    {
        public override void Rouler()
        {
            Console.WriteLine("La moto roule");
        }
    }
}
