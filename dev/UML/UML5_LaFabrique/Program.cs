using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML5_LaFabrique
{
    // Encapsulation d'objet
    internal class Program
    {
        static void Main(string[] args)
        {
            // Version 1
            //List<Personne> personnes = new List<Personne>();
            //personnes.Add(new Personne { Nom = "Phil" });
            //personnes.Add(new Personne { Nom = "Bart" });

            // Version 2
            //Personnes personnes = new Personnes();
            //personnes.Add(new Personne { Nom = "Phil" });
            //personnes.Add(new Personne { Nom = "Bart" });

            // Version 3
            //Personnes personnes = new Personnes();
            //personnes.Liste.Add(new Personne { Nom = "Phil" });
            //personnes.Liste.Add(new Personne { Nom = "bart" });

            // Version 4
            Personnes personnes = new Personnes();
            personnes.Add(new Personne { Nom = "Phil" });
            personnes.Add(new Personne { Nom = "Bart" });

            personnes.Afficher();

            Console.ReadLine();
        }
    }
    public class Personne
    {
        public string Nom;
        public override string ToString()
        {
            return Nom;
        }
    }
    // Version 2
    //public class Personnes : List<Personne>
    //{
    //}

    // Version 3
    //public class Personnes
    //{
    //    public List<Personne> Liste = new List<Personne>();
    //}

    // Version 4
    public class Personnes
    {
        private List<Personne> Liste = new List<Personne>();
        public void Add(Personne p)
        {
            Liste.Add(p);
        }

        internal void Afficher()
        {
            foreach (var p in Liste) Console.WriteLine(p);
        }
    }
}
