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
        //USE[master];
        //alter database PiscineDB set single_user with rollback immediate;
        //GO
        //DROP DATABASE PiscineDB
        static void Main(string[] args)
        {
            #region Admin
            Metier.NouveauRegex("Capacite", @"<td class=""place-name"">[\n\t ]*(.*?)[\n\t ]*<\/td>(?:.*?)*(?:\s)*([0-9]*)(?:.*?)(?:\s)*<td(?:.*?)>(?:\s)*<div(?:.*?)>(?:[\s-])*<\/div>(?:\s)*<div(?:.*?)>(?:[A-zé\n\s-])*<\/div>(?:\s)*<div(?:.*?)>(?:\s*?)[\s]*Capacité totale :  [0-9]*");
            //Metier.NouveauRegex("Capacite", @"<td class=""place-name"">([^<]+)[^<]+<[^<]+<[^<]+<[^>]+>[^<]+<[^<]+<[^<]+<[^<]+<[^>]+>[^:]*:  ([0-9]*)");
            Metier.NouveauRegex("Occupation", @"<td class=""place-name"">([^<]+)[^<]+<[^<]+<[^<]+<[^>]+>([^<]+)<");

            //Metier.NouveauRegex("Activites", @"");
            //Metier.NouvellesActivites("https://www.strasbourg.eu/lieu/-/entity/sig/401_SPO_2/centre-nautique-de-schiltigheim");
            //Metier.NouvellesActivites("https://www.strasbourg.eu/lieu/-/entity/sig/402_SPO_3/piscine-de-hautepierre");
            #endregion

            Metier.Init();
            //var a1 = Metier.NouvelAcces("Bus 45", new int[] { 1, 2 });

            //int c1 = Metier.NouvelleActivite("20230501", "20230930", "Yoga Paddle", 1);
            //int c2 = Metier.NouvelleActivite("20220901", "20230630", "AquaBoxing", 1);
            //int c3 = Metier.NouvelleActivite("20220901", "20230630", "AquaBike", 1);

            //Metier.NouveauDetailActivite("01/06/2023 10:00", "01/06/2023 12:00", 20, c1);
            //Metier.NouveauDetailActivite("01/07/2023 10:00", "01/07/2023 12:00", 12, c1);


            //var premiereFois = true;
            //if (premiereFois)
            //{
            //var p1 = Metier.NouvellePiscine("Piscine 1", 250);
            //var p2 = Metier.NouvellePiscine("Piscine 2", 410);
            //var p3 = Metier.NouvellePiscine("Piscine 3", 210);
            //var a1 = Metier.NouvelAcces("Bus 45", new int[] { p1, p2 });

            //int c1 = Metier.NouvelleActivite("20230501", "20230930", "Yoga Paddle", p1);
            //int c2 = Metier.NouvelleActivite("20220901", "20230630", "AquaBoxing", p1);
            //int c3 = Metier.NouvelleActivite("20220901", "20230630", "AquaBike", p1);

            //Metier.NouveauDetailActivite("01/06/2023 10:00", "01/06/2023 12:00", 20, c1);
            //Metier.NouveauDetailActivite("01/07/2023 10:00", "01/07/2023 12:00", 12, c1);
            //}
            //var recherchePiscinesBus45 = new Recherche { IdAcces = 1 };
            //recherchePiscinesBus45.Find();

            //Console.WriteLine("Les piscines accessibles par le Bus 45 sont :");
            //foreach (var p in recherchePiscinesBus45.ResultatPiscine)
            //{
            //    Console.WriteLine(p.Nom);
            //}
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
        public int Occupation;
    }
    internal class Acces
    {
        public int Id;
        public string Nom;
        public IEnumerable<Piscine> Piscines;
    }
}
