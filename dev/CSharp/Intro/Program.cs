using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Version 1
            //Patrick.Id = 1;
            //Patrick.Nom = "Hernandez";
            //Patrick.Prenom = "Patrick";
            //Patrick.DateNaissance = new DateTime(1949, 4, 6);
            //Console.WriteLine("{0} {1} est agé de {2} ans", Patrick.Prenom, Patrick.Nom, Patrick.CalculerAge());

            //Freddy.Id = 1;
            //Freddy.Nom = "Bulsara";
            //Freddy.Prenom = "Farrokh";
            //Freddy.DateNaissance = new DateTime(1946, 9, 5);
            //Console.WriteLine("{0} {1} est agé de {2} ans", Freddy.Prenom, Freddy.Nom, Freddy.CalculerAge());


            // Version 
            var patrick = new Personne();
            patrick.Id = 1;
            patrick.Nom = "Hernandez";
            patrick.Prenom = "Patrick";
            patrick.DateNaissance = new DateTime(1949, 4, 6);
            var patrickVille = new PersonneVille { P = patrick, V = "Paris" };
            //Personne.Compteur++;

            var freddy = new Personne(2, "Bulsara");
            freddy.Prenom = "Farrokh";
            freddy.DateNaissance = new DateTime(1946, 9, 5);
            var freddyVille = new PersonneVille { P = freddy, V = "Londres" };
            //Personne.Compteur++;

            var personnes = new List<PersonneVille>();
            personnes.Add(freddyVille);
            personnes.Add((patrickVille));

            Console.WriteLine("{0} personnes ont été définies", Personne.Compteur);
            foreach (PersonneVille person in personnes)
            {
                Console.WriteLine("{0} {1} est agé de {2} ans. Il habite à {3}",
                    person.P.Prenom,
                    person.P.Nom,
                    person.P.CalculerAge(),
                    person.V) ;
            }
            Console.ReadLine();

        }
    }
}
