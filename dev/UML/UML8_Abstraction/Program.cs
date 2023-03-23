using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML8_Abstraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var v = new Vehicule();

        }
    }
    public abstract class Vehicule
    {
        public string Moteur;
        public abstract void Rouler();
    }
    public class Auto : Vehicule
    {
        public override void Rouler()
        {

        }
    }
    public class Moto : Vehicule
    {
        public override void Rouler()
        {
        }
    }
}
