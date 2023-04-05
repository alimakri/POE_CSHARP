using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H_DevinerVersionClasse
{
    class Program
    {
        static void Main(string[] args)
        {
            int menu = 0;
            while (menu != 3)
            {
                Partie partie = null;
                switch (menu)
                {
                    case 0:
                    case 1:
                        partie = new Partie(true);
                        while (partie.PasFinie)
                        {
                            partie.LeJoueur.GetProposition();
                            partie.Comparer();
                            partie.AfficherEtat();
                        }
                        break;
                    case 2:
                        partie.AfficherMeilleursScores();
                        break;
                }

                if (menu != 3 && menu != 2) menu = partie.LeJoueur.Rejouer();
            }
            Console.WriteLine("A bientôt !");
            Console.ReadLine();
        }
    }
    class Joueur
    {
        public string Nom = null;
        public List<int> Scores = new List<int>();
        public int Proposition = 0;
        public int NCoup = 0;
        public void GetNom()
        {
            do
            {
                Console.Write("Veuillez taper votre nom : ");
                Nom = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(Nom));
        }
        public void GetProposition()
        {
            string s;
            do
            {
                Console.Write("Votre proposition : ");
                s = Console.ReadLine();
            }
            while (!int.TryParse(s, out Proposition));
            NCoup++;
        }

        public int Rejouer()
        {
            string s; int i = 0;
            do
            {
                Console.WriteLine("1. Rejouer ");
                Console.WriteLine("2. Affichage des scores et rejouer");
                Console.WriteLine("3. Quitter ");
                s = Console.ReadLine();
                int.TryParse(s, out i);
                if (i < 1 || i > 3) i = 0;
            }
            while (i == 0);
            return i;
        }
    }
    class NombreADeviner
    {
        public bool Triche = false;
        public int Valeur = -1;
        public int Min = -1;
        public int Max = -1;
        public Random Alea = new Random();
        public NombreADeviner(int min, int max, bool triche = false)
        {
            Min = min;
            Max = max;
            Triche = triche;
        }
        public void Generer()
        {
            Valeur = Alea.Next(Min, Max + 1);
            if (Triche)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Valeur);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
    enum EtatPartie { None, Gagne, Perdu, TropPetit, TropGrand }
    class Partie
    {
        public EtatPartie Etat = EtatPartie.None;
        public Joueur LeJoueur = new Joueur();
        public NombreADeviner LeNombre;
        public int NCoupMax = 7;
        public List<Joueur> LesJoueurs = new List<Joueur>();
        public Partie(bool triche)
        {
            LeNombre = new NombreADeviner(1, 99, triche);
            Console.Clear();
            Console.WriteLine("Devinez un nombre compris entre 1 et 99");
            LeNombre.Generer();
            LeJoueur.GetNom();
            LeJoueur.NCoup = 0;
        }
        public void AfficherEtat()
        {
            switch (Etat)
            {
                case EtatPartie.Gagne: Console.WriteLine("Bravo ! Vous gagnez."); break;
                case EtatPartie.Perdu: Console.WriteLine("Vous perdez."); break;
                case EtatPartie.TropPetit: Console.WriteLine("Trop petit."); break;
                case EtatPartie.TropGrand: Console.WriteLine("Trop grand."); break;
                default: Console.WriteLine("Y a un bug !!!"); break;
            }
        }
        public void AfficherMeilleursScores()
        {
            Console.WriteLine("Affichage des scores");
            var tousLesScores = LesJoueurs
                                    .SelectMany(j => j.Scores.Select(s => new { Joueur = j.Nom, Score = s }))
                                    .OrderBy(x => x.Score)
                                    .Take(5);
            foreach (var score in tousLesScores)
            {
                Console.WriteLine("{0} \t {1}", score.Joueur, score.Score);
            }
        }
        public void Comparer()
        {
            if (LeJoueur.NCoup >= NCoupMax) Etat = EtatPartie.Perdu;
            else if (LeJoueur.Proposition == LeNombre.Valeur) Etat = EtatPartie.Gagne;
            else if (LeJoueur.Proposition < LeNombre.Valeur) Etat = EtatPartie.TropPetit;
            else Etat = EtatPartie.TropGrand;
        }
        public bool PasFinie
        {
            get
            {
                return Etat == EtatPartie.None || (Etat != EtatPartie.Gagne && Etat != EtatPartie.Perdu);
            }
        }
    }
}
