using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piscine_DAL
{
    public static class DtoDonnees
    {
        internal static Acces ToAcces(this ArrayList al)
        {
            var toutesLesPiscines = Repository.GetAllPiscines();
            Acces resultat =
                new Acces
                {
                    Nom = (string)al[0],
                    LesPiscines = toutesLesPiscines.Where(x=>((int[])al[1]).Contains(x.Id)).ToList() // AM 20230419 Correction
                };
            return resultat;
        }
        internal static Piscine ToPiscine(this ArrayList al) 
        {
            Piscine resultat =
                new Piscine
                {
                    Nom = (string)al[0],
                    Capacite = (int)al[1]
                };
            return resultat;
        }
        internal static List<Piscine> ToListPiscine(this ArrayList al)
        {
            List<Piscine> resultat = new List<Piscine>();
            for (int i = 0; i < al.Count; i += 3)
            {
                resultat.Add(new Piscine
                {
                    Id = (int)al[i],
                    Nom = (string)al[i + 1],
                    Capacite = (int)al[i + 2]
                });
            }
            return resultat;
        }
        internal static List<Acces> ToListAcces(this ArrayList al)
        {
            List<Acces> resultat = new List<Acces>();
            var toutesLesPiscines = Repository.GetAllPiscines();
            for (int i = 0; i < al.Count; i += 3)
            {
                List<Piscine> piscines = new List<Piscine>();
                foreach (var j in (int[])al[i + 2])
                {
                    var p = toutesLesPiscines.FirstOrDefault(x => x.Id == j);
                    if (p != null) piscines.Add(p);
                }
                resultat.Add(new Acces
                {
                    Id = (int)al[i],
                    Nom = (string)al[i + 1],
                    LesPiscines = piscines
                });
            }
            return resultat;
        }
        internal static ArrayList ToArrayList(this List<Piscine> liste)
        {
            var resultat = new ArrayList();
            if (liste == null) return resultat;
            liste.ForEach(x => { resultat.Add(x.Id); resultat.Add(x.Nom); resultat.Add(x.Capacite); });
            return resultat;
        }
    }
}
