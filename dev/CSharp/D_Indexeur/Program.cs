using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Indexeur
{
    class Program
    {
        static void Main(string[] args)
        {
            var liste = new Animaux
            {
                new Animal{Nom="Chien", Espece="Canidé", EsperanceDeVie=15, DateNaissance=new DateTime(2023, 1,25) },
                new Animal{Nom="Chat", Espece="Félidé", EsperanceDeVie=10, DateNaissance=new DateTime(2023, 2,25) },
                new Animal{Nom="Poisson rouge", Espece="Poisson", EsperanceDeVie=1, DateNaissance=new DateTime(2023, 3,25) },
            };
            //var d = liste[0].DateNaissance;
            var d = liste["Chien"].DateNaissance;
        }
    }
    public class Animal
    {
        public string Nom;
        public string Espece;
        public int EsperanceDeVie;
        public DateTime DateNaissance;
    }

    public class Animaux : List<Animal>
    {
        public Animal this[string nom]
        {
            get
            {
                foreach (var a in this)
                {
                    if (a.Nom == nom) return a;
                }
                return null;
            }
        }
    }
}
