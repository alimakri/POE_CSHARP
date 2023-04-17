using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O_Exo5
{
    public class Personne
    {
        public Personne? Parent1 = null;
        public Personne? Parent2 = null;
    }
    public static class Genealogie
    {
        public static bool SontFreres(Personne p1, Personne p2)
        {
            return (p1.Parent1 == p2.Parent1 && p1.Parent2 == p2.Parent2);
        }
        public static bool SontDemiFreres(Personne p1, Personne p2)
        {
            return ((p1.Parent1 == p2.Parent2 && p1.Parent1 != null) || (p1.Parent2 == p2.Parent1 && p1.Parent2 != null));
        }
        public static bool SontCousins(Personne p1, Personne p2)
        {
            if (SontFreres(p1, p2) || SontDemiFreres(p1,p2)) return false;
            var listeP1 = new List<Personne?> { p1.Parent1?.Parent1, p1.Parent1?.Parent2, p1.Parent2?.Parent1, p1.Parent2?.Parent2 }
                                .Where(gp=>gp != null);
            var listeP2 = new List<Personne?> { p2.Parent1?.Parent1, p2.Parent1?.Parent2, p2.Parent2?.Parent1, p2.Parent2?.Parent2 }
                                .Where(gp => gp != null);
            var listeEnCommun = listeP1.Intersect(listeP2);
            return listeEnCommun.Count() > 0;
        }
    }
}
