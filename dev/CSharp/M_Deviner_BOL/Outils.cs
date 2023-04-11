using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_Deviner_BOL
{
    public static class OutilsMetier
    {
        public static ArrayList ToArrayList(this List<Joueur> liste)
        {
            var al = new ArrayList();
            liste.ForEach(x => { al.Add(x.Nom); al.Add(x.Scores); });
            return al;
        }
    }
}
