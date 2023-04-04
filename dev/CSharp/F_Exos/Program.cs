using System;
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
                new Animal{Nom="Chien", Espece="Canidé", EsperanceDeVie=15, DateNaissance=new DateTime(2023, 1,25) },
                new Animal{Nom="Chat", Espece="Félidé", EsperanceDeVie=10, DateNaissance=new DateTime(2023, 2,25) },
                new Animal{Nom="Poisson rouge", Espece="Poisson", EsperanceDeVie=1, DateNaissance=new DateTime(2023, 3,25) },
            };


            // Liste des espèces
        }
    }
    public class Animal
    {
        public string Nom;
        public string Espece;
        public int EsperanceDeVie;
        public DateTime DateNaissance;
    }
}
