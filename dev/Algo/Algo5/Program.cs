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
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach(var person in personnes)
            {
                Console.WriteLine("{0}\t{1}", person.Key, person.Value );
            }
            Console.ReadLine();
        }
    }
}
