using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Partie 1 : saisie
            var personnes = new Dictionary<string, string>();
            while(true)
            {
                Console.Write("Nom : ");
                var nom = Console.ReadLine();
                if (string.IsNullOrEmpty(nom)) break;
                Console.Write("Ville : ");
                var ville = Console.ReadLine();
                personnes.Add(nom, ville);
            }

            // Partie 2 : affichage
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach(var person in personnes)
            {
                Console.WriteLine("{0}\t{1}", person.Key, person.Value );
            }

            // Partie : recherche de ville
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Nom ?");
            var question = Console.ReadLine();
            if (personnes.ContainsKey(question))
            {
                Console.WriteLine("{0} est de la ville de {1}", 
                    question, 
                    personnes[question]);
            }
            else
            {
                Console.WriteLine("{0} n'existe pas !", question);
            }
            Console.ReadLine();
        }
    }
}
