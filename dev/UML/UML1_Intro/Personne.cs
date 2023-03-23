using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro
{
    // Héritage
    public class Interprete : Personne
    {
        //public int Id;
        //public string Nom;
        //public string Prenom;
        //public DateTime DateNaissance;
        //public static int Compteur = 0;
        //public int CalculerAge()
        //{
        //    return (int)(DateTime.Now - DateNaissance).TotalDays / 365;
        //}
        //public int CalculerAge(char mode)
        //{
        //    switch (mode)
        //    {
        //        case 'd': return (int)(DateTime.Now - DateNaissance).TotalDays;
        //        case 'y': return (int)(DateTime.Now - DateNaissance).TotalDays / 365;
        //        default: return -1;
        //    }
        //}

        // -------------------------------
        public List<string> Concerts;
        public string MaisonProduction;
    }

    // Agrégation d'objets sous forme de propriétés
    public class Personne
    {
        // Constructeur
        public Personne()
        {
            Compteur++;
        }
        public Personne(int id, string nom)
        {
            Id = id;
            Nom = nom;
            Compteur++;
        }
        public int Id;
        public string Nom;
        public string Prenom;
        public DateTime DateNaissance;
        public static int Compteur = 0;
        public int CalculerAge() 
        {
            return (int)(DateTime.Now - DateNaissance).TotalDays / 365;
        }
        public int CalculerAge(char mode)
        {
            switch (mode)
            {
                case 'd': return (int)(DateTime.Now - DateNaissance).TotalDays;
                case 'y': return (int)(DateTime.Now - DateNaissance).TotalDays / 365;
                default: return -1;
            }
        }

    }
    public class PersonneVille
    {
        public Personne P;
        public string V;
    }
    //public static class Patrick
    //{
    //    public static int Id;
    //    public static string Nom;
    //    public static string Prenom;
    //    public static DateTime DateNaissance;
    //    public static int CalculerAge()
    //    {
    //        return (int)(DateTime.Now - DateNaissance).TotalDays / 365;
    //    }
    //}
    //public static class Freddy
    //{
    //    public static int Id;
    //    public static string Nom;
    //    public static string Prenom;
    //    public static DateTime DateNaissance;
    //    public static int CalculerAge()
    //    {
    //        return (int)(DateTime.Now - DateNaissance).TotalDays / 365;
    //    }
    //}
}

