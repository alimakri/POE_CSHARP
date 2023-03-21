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
            List<string> personnes = new List<string>();
            while(true)
            {
                Console.Write("Nom : ");
                var nom = Console.ReadLine();
                if (string.IsNullOrEmpty(nom)) break;
                Console.Write("Ville : ");
                var ville = Console.ReadLine();
                personnes.Add(nom + "|" + ville);
            }
            Console.ForegroundColor = ConsoleColor.Cya;
            foreach(var person in personnes)
            {
                Console.WriteLine(person);
            }
            Console.ReadLine();
        }
    }
}
