using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_TourHanoi
{
    //deplacements.Add(new Deplacement { Piece = 1, Depart = eA, Arrivee = eB });
    //deplacements.Add(new Deplacement { Piece = 2, Depart = eA, Arrivee = eC });
    //deplacements.Add(new Deplacement { Piece = 1, Depart = eB, Arrivee = eC });
    //deplacements.Add(new Deplacement { Piece = 3, Depart = eA, Arrivee = eB });
    //deplacements.Add(new Deplacement { Piece = 1, Depart = eC, Arrivee = eA });
    //deplacements.Add(new Deplacement { Piece = 2, Depart = eC, Arrivee = eB });
    //deplacements.Add(new Deplacement { Piece = 1, Depart = eA, Arrivee = eB });

    class Program
    {
        private static Deplacements LesDeplacements;
        static void Main(string[] args)
        {
            var eA = "A";
            var eB = "B";
            var eC = "C";

            LesDeplacements = new Deplacements();
            Deplacer(new List<int> { 1, 2, 3 }, eA, eB, eC);

            LesDeplacements.Afficher();

            Console.ReadLine();
        }

        private static void Deplacer(List<int> pile, string depart, string arrivee, string intermediaire)
        {
            if (pile.Count == 1)
                Deplacer(pile[0], depart, arrivee);
            else
            {
                var pieceBase = pile[pile.Count - 1];
                var sousPile = new List<int>(); sousPile.AddRange(pile); sousPile.Remove(pieceBase);
                Deplacer(sousPile, depart, intermediaire, arrivee);
                Deplacer(pieceBase, depart, arrivee);
                Deplacer(sousPile, intermediaire, arrivee, depart);
            }
        }
        private static void Deplacer(int piece, string depart, string arrivee)
        {
            LesDeplacements.Add(new Deplacement { Piece = piece, Depart = depart, Arrivee = arrivee });
        }
    }
    class Deplacements : List<Deplacement>
    {
        public void Afficher()
        {
            foreach (var d in this)
            {
                Console.WriteLine("Pièce {0} de {1} vers {2}", d.Piece, d.Depart, d.Arrivee);
            }
        }
    }
    class Deplacement
    {
        public int Piece;
        public string Depart;
        public string Arrivee;
    }
}
