using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Delegue
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class Centrale
    {

    }
    class PompeHydraulique
    {
        public void Refroidir() { Console.WriteLine("La pome hydraulique est lancée !"); }
    }
    class PompeElectrique
    {
        public void Refroidir() { Console.WriteLine("La pome electrique est lancée !"); }
    }
}
