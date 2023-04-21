using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UILConsole
{
    internal static class DtoInterface
    {
        #region Sortant
        public static ArrayList ToArrayList(this Recherche r)
        {
            return new ArrayList { r.IdAcces, r.IdPiscine };
        }
        #endregion

        #region Entrant
        // Piscines -> ArrayList 
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
        #endregion
    }
}
