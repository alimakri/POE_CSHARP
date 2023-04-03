using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //var liste = TraitementNombre();

            var liste = TraitementPersonne();

            foreach (var element in liste) { Console.WriteLine(element); }
            Console.ReadLine();
        }

        private static IEnumerable<string> TraitementPersonne()
        {
            List<Personne> personnes = new List<Personne>
            {
                new Personne{ Nom="Pierre", Ville="Toulouse" },
                new Personne{ Nom="Sophie", Ville="Strasbourg" },
                new Personne{ Nom="Thomas", Ville="Toulouse" }
            };
            return personnes
                        .Where(x => x.Ville == "Toulouse")
                        .Select(x => x.Nom);
                        //.ToList();
        }

        static IEnumerable<int> TraitementNombre()
        {
            List<int> nombres = new List<int> { 2, 5, 6, 9, 98, 27, 13, 90 };
            var nombresPairs = nombres
                                    .Where(x => x % 2 == 0)
                                    .Where(x => x > 50)
                                    .OrderBy(x => x);
            return nombresPairs;
        }
    }
    class Personne
    {
        public string Nom;
        public string Ville;
        public override string ToString()
        {
            return $"{Nom} de la ville de {Ville}";
        }
    }
}
