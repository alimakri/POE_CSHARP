using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LesAttributs
{
    class Program
    {
        static void Main(string[] args)
        {
            var e = new Entreprise();
            var ca = e.GetCA("M2i");

            e.RechercheAttribut();
        }
    }
    class Entreprise
    {
        [Obsolete("Utilisez l'autre méthode avec le coef. C'est mieux !")]
        [DevelopperPar("André")]
        public decimal GetCA(string nom)
        {
            switch (nom)
            {
                case "M2i": return 1000000;
                case "Sogeti": return 2000000;
                default: return 0;
            }
        }
        [DevelopperPar("Ali MAKRI")]
        public decimal GetCA(string nom, decimal coef)
        {
            switch (nom)
            {
                case "M2i": return 1000000;
                case "Sogeti": return 2000000;
                default: return 0;
            }
        }
        public void RechercheAttribut()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var classeEntreprise = assembly.GetTypes().Where(x => x.Name == "Entreprise").FirstOrDefault();
            if (classeEntreprise != null)
            {
                var methodes = classeEntreprise.GetMethods();
                foreach(var m in methodes)
                {
                    var attributs = m.GetCustomAttributes(false);
                    foreach(var a in attributs)
                    {
                        if (a is DevelopperParAttribute) Console.WriteLine(((DevelopperParAttribute)a).Nom);
                    }
                }
            }
            
        }
    }
    class DevelopperParAttribute : Attribute
    {
        public string Nom;
        public DevelopperParAttribute(string nom)
        {
            Nom = nom;
        }
    }
}
