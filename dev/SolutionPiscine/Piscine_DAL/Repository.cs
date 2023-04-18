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
        public static void Enregistrer(string dbName, ArrayList alPiscines, ArrayList alAccess)
        {
            Context.Database.Connection.ChangeDatabase(dbName);
            Context.LesPiscines.AddRange(alPiscines.ToListPiscine());
            Context.LesAcces.AddRange(alAccess.ToListAcces());
            Context.SaveChanges();
        }

        internal static List<Piscine> GetAllPiscines()
        {
            return Context.LesPiscines.ToList();
        }
    }
}
