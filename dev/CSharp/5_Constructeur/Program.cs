using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructeur
{
    class Program
    {
        static void Main(string[] args)
        {
            var terre = new Planete();
        }
    }
    class Planete
    {
        static Planete() { }

        public Planete() { }
        public Planete(int i) { }
    }
}
