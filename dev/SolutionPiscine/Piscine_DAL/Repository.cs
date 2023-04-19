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
        public static int EnregistrerAcces(ArrayList alAcces)
        {
            var newA = alAcces.ToAcces();
            Context.LesAcces.Add(newA);
            Context.SaveChanges();
            return newA.Id;
        }

        public static int EnregistrerPiscine(ArrayList alPiscine)
        {
            var newP = alPiscine.ToPiscine();
            Context.LesPiscines.Add(newP);
            Context.SaveChanges();
            return newP.Id;
        }

        public static ArrayList GetPiscines(int idAcces)
        {
            var resultat = new List<Piscine>();
            var acces = Context.LesAcces.Include("LesPiscines").FirstOrDefault(x => x.Id == idAcces);
            if (acces != null) resultat = acces.LesPiscines;

            return resultat.ToArrayList();
        }

        public static int EnregistrerActivite(ArrayList alActivite)
        {
            var newA = alActivite.ToActivite();
            Context.LesActivites.Add(newA);
            Context.SaveChanges();
            return newA.Id;
        }
    }
}
