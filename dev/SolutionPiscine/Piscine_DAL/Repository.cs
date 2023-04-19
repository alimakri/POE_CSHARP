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
            Context.SaveChanges();
            Context.LesAcces.AddRange(alAccess.ToListAcces());
            Context.SaveChanges();
        }

        internal static List<Piscine> GetAllPiscines()
        {
            var n = Context.LesPiscines.ToList();
            return n;
        }

        public static ArrayList GetPiscines(int idAcces)
        {
            var a = Context.LesPiscines.ToList();
            var b = Context.LesAcces.ToList();
            var resultat = new List<Piscine>();
            var acces = Context.LesAcces.Include("LesPiscines").FirstOrDefault(x => x.Id == idAcces);
            if (acces != null) resultat = acces.LesPiscines;

            return resultat.ToArrayList();
        }
    }
}
