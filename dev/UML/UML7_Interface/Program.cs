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
                v = new Auto();
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
    public class Auto : IVehicule
    {
        public void Rouler()
        {
            Console.WriteLine("L'auto roule");
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
