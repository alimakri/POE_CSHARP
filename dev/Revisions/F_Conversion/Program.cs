using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_Conversion
{
    class Program
    {
        static void Main(string[] args)
        {
            var formulaire = "nom= MAKRI , prenom=Ali";
            Personne p = formulaire.ToPersonne();
        }
    }
    public class Personne
    {
        public string Nom;
        public string Prenom;
    }
    //public static class OutilsString
    //{
    //    public static Personne ToPersonne(this string s)
    //    {
    //        var tab = s.Split(new char[] { '=', ',' });
    //        return new Personne
    //        {
    //            Nom = tab[1].Trim(),
    //            Prenom = tab[3].Trim()
    //        };
    //    }
    //}
}
