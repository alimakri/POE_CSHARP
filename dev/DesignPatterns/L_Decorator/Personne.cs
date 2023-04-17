using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_Decorator
{
    public sealed class Personne
    {
        public int Id;
        public string Nom = "";
        public string Prenom = "";
        public int GetAge() { return 0; }
    }
    // Solution 1 : héritage
    //public class PersonneWrapper : Personne
    //{
    //    public DateTime GetDateInscription() { return default; }
    //}
    // Solution 2 : méthode d'extension
    //public static class Tools
    //{
    //    public static DateTime GetDateInscription(this Personne p) { return default; }
    //}

    // Solution 3 : Decorator
    public class PersonneWrapper
    {
        private Personne PersonneSource = new Personne();
        public DateTime DateInscription { get; set; }
        public string Nom { get { return PersonneSource.Nom; } set { PersonneSource.Nom = value; } }
        public string Prenom { get { return PersonneSource.Prenom; } set { PersonneSource.Prenom = value; } }
        public int GetAge() { return PersonneSource.GetAge(); }
        public override string ToString()
        {
            return $"{Nom} {Prenom} {DateInscription}";
        }
    }

}
