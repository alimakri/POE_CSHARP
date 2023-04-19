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
            var premiereFois = false;
            if (premiereFois)
            {
                var p1 = Metier.NouvellePiscine("Piscine 1", 250);
                var p2 = Metier.NouvellePiscine("Piscine 2", 410);
                var p3 = Metier.NouvellePiscine("Piscine 3", 210);
                var a1 = Metier.NouvelAcces("Bus 45", new int[] { p1, p2 });

                int c1 = Metier.NouvelleActivite("20230501", "20230930", "Yoga Paddle", p1);
                int c2 = Metier.NouvelleActivite("20220901", "20230630", "AquaBoxing", p1);
                int c3 = Metier.NouvelleActivite("20220901", "20230630", "AquaBike", p1);
            }
            var recherchePiscinesBus45 = new Recherche { IdAcces = 1 };
            recherchePiscinesBus45.Find();

            Console.WriteLine("Les piscines accessibles par le Bus 45 sont :");
            foreach (var p in recherchePiscinesBus45.ResultatPiscine)
            {
                Console.WriteLine(p.Nom);
            }
            Console.ReadLine();
        }

    }
    internal class Recherche
    {
        public int IdAcces;
        public int IdPiscine;
        public List<Piscine> ResultatPiscine;
        public List<Acces> ResultatAcces; // TODO : faire ......

        public void Find()
        {
            ResultatPiscine = Metier.GetPiscines(this.ToArrayList()).ToListPiscine();

        }
    }
    internal class Piscine
    {
        public int Id;
        public string Nom;
        public int Capacite;
    }
    internal class Acces
    {
        public int Id;
        public string Nom;
        public IEnumerable<Piscine> Piscines;
    }
}
