using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_Exos
{
    class Program
    {
        static void Main(string[] args)
        {
            var liste = new List<Animal>
            {
                new Animal{Nom="Pif", Race="Chien", Espece="Canidé", EsperanceDeVie=15, DateNaissance=new DateTime(2018, 1,25) },
                new Animal{Nom="Hercule", Race="Chat", Espece="Félidé", EsperanceDeVie=10, DateNaissance=new DateTime(2019, 2,25) },
                new Animal{Nom="Maurice", Race="Poisson rouge", Espece="Poisson", EsperanceDeVie=1, DateNaissance=new DateTime(2020, 3,25) },
                new Animal{Nom="Nemo", Race="Poisson clown", Espece="Poisson", EsperanceDeVie=1, DateNaissance=new DateTime(2022, 3,25) }
            };


            // Liste des espèces (en string)
            var especes = new List<string>();
            especes.AddRange(liste.Select(x => x.Espece).Distinct());

            // Liste d'objets espece
            var listeEspeces =  liste
                                    .Select(animal => new Espece { Nom = animal.Espece, EsperanceDeVie = animal.EsperanceDeVie })
                                    .Distinct(new EspeceComparer())
                                    .ToList();
            // Classe anonyme
            // Liste d'objets avec les propriétés Nom et age.
            var liste2 = liste
                .Select(x => new { Nom = x.Nom, Age = Math.Round((DateTime.Now - x.DateNaissance).TotalDays / 365) });
            var liste3 = liste2.Where(x => x.Age > 2);
            //var a1 = liste3.FirstOrDefault();
            var liste4 = liste3.ToList();
        }
    }
    public class Animal
    {
        public string Race;
        public string Nom;
        public string Espece;
        public int EsperanceDeVie;
        public DateTime DateNaissance;
    }
    public class Espece
    {
        public string Nom;
        public int EsperanceDeVie;
        public override string ToString()
        {
            return $"{Nom}-{EsperanceDeVie}";
        }
    }
    class EspeceComparer : IEqualityComparer<Espece>
    {
        public bool Equals(Espece x, Espece y)
        {
            return x.Nom == y.Nom;
        }

        public int GetHashCode(Espece obj)
        {
            return 0;
        }
    }
}
