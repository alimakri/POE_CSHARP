using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Partie 0 : lecture du fichier
            var personnes = new Dictionary<string, string>();
            var lignes = File.ReadAllLines(@"D:\personnes.csv");
            foreach (var ligne in lignes)
            {
                var tab = ligne.Split(';');
                personnes.Add(tab[0], tab[1]);
            }

            // Partie 1 : saisie
            while (true)
            {
                Console.Write("Nom : ");
                var nom = Console.ReadLine();
                if (string.IsNullOrEmpty(nom)) break;
                Console.Write("Ville : ");
                var ville = Console.ReadLine();
                if (personnes.ContainsKey(nom))
                    Console.WriteLine("J'ai déjà un {0}", nom);
                else
                    personnes.Add(nom, ville);
            }

            // Partie 1.1 : sauvegarder
            var contenu = "";
            foreach (var person in personnes)
            {
                contenu += person.Key + ";" + person.Value + "\n";
            }
            File.WriteAllText(@"D:\personnes.csv", contenu);


            // Partie 2 : affichage
            Affichage();

            // Partie : recherche de ville
            Console.Write("Nom ? ");
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

        private static void Affichage()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var person in personnes)
            {
                Console.WriteLine("{0}\t{1}", person.Key, person.Value);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
