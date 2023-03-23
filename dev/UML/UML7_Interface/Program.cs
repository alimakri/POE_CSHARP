using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML7_Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IVehicule v;
            var x = Console.ReadLine();
            if (x.ToUpper() == "A")
            {
                v = new Auto();
                ((Auto)v).Sabriter();
            }
            else
                v = new Moto();

            v.Rouler();
            Console.ReadLine();
        }
    }
    interface IVehicule
    {
        void Rouler();
    }
    interface IHabitation
    {
        void Sabriter();
    }
    public class Auto : IVehicule, IHabitation
    {
        public void Rouler()
        {
            Console.WriteLine("L'auto roule");
        }

        public void Sabriter()
        {
            Console.WriteLine("On s'abrite dans l'auto");
        }
    }
    public class Moto : IVehicule
    {
        public void Rouler()
        {
            Console.WriteLine("La moto roule");
        }
    }
}
