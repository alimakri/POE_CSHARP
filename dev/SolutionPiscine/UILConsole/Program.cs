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
            //var context = new OccupationContext();
            //var p1 = new Piscine { Nom = "Piscine 1", Capacite = 250 };
            //var p2 = new Piscine { Nom = "Piscine 2", Capacite = 410 };
            //var a1 = new Acces { Nom = "Bus 45", LesPiscines = new List<Piscine> { p1, p2 } };
            //p1.LAcces = a1;
            //context.LesPiscines.Add(p1);
            //context.LesPiscines.Add(p2);
            //context.LesAcces.Add(a1);
            //context.SaveChanges();
        }
    }
}
