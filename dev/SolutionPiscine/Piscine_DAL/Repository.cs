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
        }

        public static List<Piscine> GetAllPiscines()
        {
            throw new NotImplementedException();
        }
    }
}
