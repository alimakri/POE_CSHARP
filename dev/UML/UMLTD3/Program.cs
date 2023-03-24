using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLTD3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var vache = new Bovide();
            Console.WriteLine(vache);
            vache.Traire();
            Console.ReadLine();
        }
    }
    class Animal
    {
        public override string ToString()
        {
            return "Animal";
        }
    }
    class Mamiffere : Animal
    {
        public override string ToString()
        {
            var x = base.ToString();
            return x + "- Mamiffere";
        }
        public virtual void Traire()
        {
            Console.WriteLine("Traite de Mamiffere");
        }
    }
    class Bovide :Mamiffere
    {
        public override string ToString()
        {
            var x = base.ToString();
            return x + "- Bovide";
        }
        public override void Traire()
        {
            Console.WriteLine("Traite de Bovide");
        }
    }
}
