using Piscine_DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Piscine_BOL
{
    public static class Metier
    {
        private static List<Piscine> LesPiscines = new List<Piscine>();
        private static List<Acces> LesAcces = new List<Acces>();

        public static int NouvellePiscine(string nom, int capacite)
        {
            var p = new Piscine { Nom = nom, Capacite = capacite };
            LesPiscines.Add(p);
            p.Id = EnregistrerPiscine(p); // AM 20230419 Correction
            return p.Id;
        }

        public static int EnregistrerPiscine(Piscine p)
        {
            return Repository.EnregistrerPiscine(p.ToArrayList());
        }
        public static void Enregistrer()
        {
            Repository.Enregistrer(LesPiscines.ToArrayList(), LesAcces.ToArrayList());
        }

        public static ArrayList GetPiscines(ArrayList recherche)
        {
            return Repository.GetPiscines((int)recherche[0]);
        }

        public static int NouvelAcces(string nom, int[] piscines)
        {
            var a = new Acces { Nom = nom };
            a.Piscines = LesPiscines.Where(x => piscines.Contains(x.Id));
            LesAcces.Add(a);
            return EnregistrerAcces(a);
        }

        private static int EnregistrerAcces(Acces a)
        {
            return Repository.EnregistrerAcces(a.ToArrayList());
        }
        #region Tests unitaires
        public static IEnumerable<string> TestAcces1(string nomAcces)
        {
            var a = LesAcces.FirstOrDefault(x => x.Nom == nomAcces);
            if (a == null) return new List<string>();
            return a.Piscines.Select(x => x.Nom);
        }
        #endregion
    }
    public class Piscine
    {
        public int Id;
        public string Nom;
        public int Capacite;
    }
    public class Acces
    {
        public int Id;
        public string Nom;
        public IEnumerable<Piscine> Piscines;
    }
}
