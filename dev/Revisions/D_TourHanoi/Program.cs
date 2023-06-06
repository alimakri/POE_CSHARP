using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_TourHanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Emplacement> emplacements = new List<Emplacement>();
            var eA = new Emplacement { Nom = "A", LaTour = new Tour { 1, 2, 3 } };
            var eB = new Emplacement { Nom = "B", LaTour = new Tour() };
            var eC = new Emplacement { Nom = "C", LaTour = new Tour() };
            emplacements.Add(eA);
            emplacements.Add(eB);
            emplacements.Add(eC);

            Deplacer();

            //Deplacements deplacements = new Deplacements();
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

        private static void Deplacer()
        {
            Deplacements deplacements = new Deplacements();
            deplacements.Add(new Deplacement { Pieces = SousPile(), DepartFonction = FonctionEnum.Depart, ArriveeFonction = FonctionEnum.Intermedidiaire });
            deplacements.Add(new Deplacement { Piece = PieceBase(), DepartFonction = FonctionEnum.Depart, ArriveeFonction = FonctionEnum.Arrivee });
            deplacements.Add(new Deplacement { Pieces = SousPile(), DepartFonction = FonctionEnum.Intermedidiaire, ArriveeFonction = FonctionEnum.Arrivee });
        }
    }
    class Deplacements : List<Deplacement>
    {
        public void Afficher()
        {
            foreach(var d in this)
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
    enum FonctionEnum { Depart, Arrivee, Intermedidiaire }
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
