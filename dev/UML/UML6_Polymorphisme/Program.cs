using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML6_Polymorphisme
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicule v;
            var x = Console.ReadLine();
            if (x.ToUpper() == "A")
                v = new Auto();
            else
                v = new Moto();

            v.Rouler();
            Console.ReadLine();
        }
    }
    class Vehicule
    {
        public string Moteur;
        public virtual void Rouler() { Console.WriteLine("Le véhicule roule"); }
    }
    class Auto : Vehicule
    {
        public string Volant;

        public override void Rouler() { Console.WriteLine("L'auto roule"); }
    }
    class Moto : Vehicule
    {
        public string Guidon;
        public override void Rouler() { Console.WriteLine("La moto roule"); }
    }
}
