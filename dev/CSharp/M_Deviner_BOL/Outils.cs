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
        public static List<Joueur> ToListJoueur(this ArrayList al)
        {
            var liste = new List<Joueur>();
            for(int i=0; i < al.Count; i+=2)
            {
                liste.Add(new Joueur { Nom = (string) al[i], Scores = (List<int>) al[i + 1] });
            }
            return liste;
        }
    }
}
