using Piscine_BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UILConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Metier.NouvellePiscine(1, "Piscine 1", 250);
            Metier.NouvellePiscine(2, "Piscine 2", 410);
            Metier.NouvellePiscine(3, "Piscine 3", 210);
            Metier.NouvelAcces(1, "Bus 45", new int[] { 1, 2});

            Metier.Enregistrer();
        }
    }
}
