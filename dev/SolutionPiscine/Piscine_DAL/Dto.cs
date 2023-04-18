using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piscine_DAL
{
    public static class DataTransferObject
    {
        public static List<Piscine> ToListPiscine(this ArrayList al)
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
        public static List<Acces> ToListAcces(this ArrayList al)
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
    }
}
