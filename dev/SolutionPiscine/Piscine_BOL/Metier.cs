using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piscine_BOL
{
    public static class Metier
    {
        private static List<Piscine> Piscines = new List<Piscine>();
        public static void NouvellePiscine(int id, string nom, int capacite)
        {
            Piscines.Add(new Piscine { Id = id, Nom = nom, Capacite = capacite });
        }

        public static void NouvelAcces(int id,string nom, int[] piscines)
        {
            var a = new Acces { Id = id, Nom = nom };
            a.Piscines = Piscines.Where(x => piscines.Contains(x.Id));
        }
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
        public List<Piscine> Piscines;
    }
}
