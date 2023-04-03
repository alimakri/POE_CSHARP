using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_Linq_Exo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pays> lesPays = new List<Pays>
            {
                new Pays{Nom="Italie", Capital="Rome" },
                new Pays{Nom="Vatican", Capital="Rome" },
                new Pays{Nom="Chili", Capital= "Santiago"},
                new Pays{Nom="Chili", Capital= "Valparaiso"},
                new Pays{Nom="Israel", Capital= "Jerusalem"},
                new Pays{Nom="Palestine", Capital= "Jerusalem"}
            };
            // Tous les pays capital Rome
            var romes = lesPays.Where(pays => pays.Capital == "Rome");

            // Capitales du chili
            var chili = lesPays.Where(x => x.Nom == "Chili").ToArray();

            // Pays de Jerusalem
            var qods = lesPays.Where(pays => pays.Capital == "Jerusalem");
        }
    }
    class Pays
    {
        public string Nom;
        public string Capital;
        public int Superficie;
    }
}
