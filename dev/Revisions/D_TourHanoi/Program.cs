using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_TourHanoi
{
    class Program
    {
        private static Deplacements LesDeplacements;
        static void Main(string[] args)
        {
            List<Emplacement> emplacements = new List<Emplacement>();
            var eA = new Emplacement { Nom = "A", LaTour = new Tour { 1, 2, 3 } };
            var eB = new Emplacement { Nom = "B", LaTour = new Tour() };
            var eC = new Emplacement { Nom = "C", LaTour = new Tour() };
            emplacements.Add(eA);
            emplacements.Add(eB);
            emplacements.Add(eC);

            LesDeplacements = new Deplacements();
            Deplacer(new Tour { 1, 2, 3 }, FonctionEnum.Depart, FonctionEnum.Arrivee, FonctionEnum.intermediaire);

            //deplacements.Add(new Deplacement { Piece = 1, Depart = eA, Arrivee = eB });
            //deplacements.Add(new Deplacement { Piece = 2, Depart = eA, Arrivee = eC });
            //deplacements.Add(new Deplacement { Piece = 1, Depart = eB, Arrivee = eC });
            //deplacements.Add(new Deplacement { Piece = 3, Depart = eA, Arrivee = eB });
            //deplacements.Add(new Deplacement { Piece = 1, Depart = eC, Arrivee = eA });
            //deplacements.Add(new Deplacement { Piece = 2, Depart = eC, Arrivee = eB });
            //deplacements.Add(new Deplacement { Piece = 1, Depart = eA, Arrivee = eB });
            //deplacements.Afficher();

            Console.ReadLine();
        }

        private static void Deplacer(Tour pile, FonctionEnum depart, FonctionEnum arrivee, FonctionEnum intermediaire)
        {
            if (pile.Count == 1)
                Deplacer(pile[0], depart, arrivee);
            else
            {
                var pieceBase = pile[pile.Count - 1];
                var sousPile = new Tour(); sousPile.AddRange(pile); sousPile.Remove(pieceBase);
                Deplacer(sousPile, depart, intermediaire, arrivee);
                Deplacer(pieceBase, depart, arrivee);
                Deplacer(sousPile, intermediaire, arrivee, depart);
            }
        }
        private static void Deplacer(int piece, FonctionEnum depart, FonctionEnum arrivee)
        {
            LesDeplacements.Add(new Deplacement { Piece = piece });
        }
    }
    class Deplacements : List<Deplacement>
    {
        public void Afficher()
        {
            foreach (var d in this)
            {
                Console.WriteLine("Pièce {0} de {1} vers {2}", d.Piece, d.Depart.Nom, d.Arrivee.Nom);
            }
        }
    }
    class Emplacement
    {
        public string Nom;
        public FonctionEnum Fonction;
        public Tour LaTour;
    }
    enum FonctionEnum { Depart, Arrivee, intermediaire }
    class Tour : List<int>
    {
        public Emplacement Place;
    }
    class Deplacement
    {
        public int Piece;
        public Emplacement Depart;
        public Emplacement Arrivee;
    }
}
