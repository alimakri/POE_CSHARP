using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piscine_DAL
{
    public static class Repository
    {
        private static OccupationContext Context = new OccupationContext();
        public static void Enregistrer(ArrayList alPiscines, ArrayList alAccess)
        {
            Context.LesPiscines.AddRange(alPiscines.ToListPiscine());
            Context.LesAcces.AddRange(alAccess.ToListAcces());
            Context.SaveChanges();
        }

        internal static List<Piscine> GetAllPiscines()
        {
            return Context.LesPiscines.ToList();
        }

        public static ArrayList GetPiscines(int idAcces)
        {
            var resultat = new List<Piscine>();
            var acces = Context.LesAcces.FirstOrDefault(x => x.Id == idAcces);
            if (acces != null) resultat = acces.LesPiscines;

            return resultat.ToArrayList();
        }
    }
}
