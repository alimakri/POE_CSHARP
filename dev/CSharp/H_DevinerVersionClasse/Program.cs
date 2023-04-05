﻿using System;
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
                Partie partie = new Partie(true, menu);
                switch (menu)
                {
                    case 0:
                    case 1:
                        while (partie.PasFinie)
                        {
                            partie.LeJoueur.GetProposition();
                            partie.Comparer();
                            partie.AfficherEtat();
                            if (partie.Etat == EtatPartie.Gagne) partie.Enregistrer();
                        }
                        break;
                    case 2:
                        partie.AfficherMeilleursScores();
                        break;
                }

                menu = partie.LeJoueur.Rejouer();
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
                Console.WriteLine("2. Affichage des scores");
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
        public Partie(bool triche, int menu)
        {
            if (triche)
            {
                var j1 = new Joueur { Nom = "Alain" };
                j1.Scores.Add(8);
                j1.Scores.Add(7);
                j1.Scores.Add(8);
                var j2 = new Joueur { Nom = "Brigitte" };
                j2.Scores.Add(5);
                j2.Scores.Add(8);
                LesJoueurs.Add(j1);
                LesJoueurs.Add(j2);
            }

            LeNombre = new NombreADeviner(1, 99, triche);
            Console.Clear();
            Console.WriteLine("Devinez un nombre compris entre 1 et 99");
            LeNombre.Generer();
            if (menu != 2) LeJoueur.GetNom();
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Affichage des scores");
            var tousLesScores = LesJoueurs
                                    .SelectMany(j => j.Scores.Select(s => new { Joueur = j.Nom, Score = s }))
                                    .OrderBy(x => x.Score)
                                    .Take(5);
            foreach (var score in tousLesScores)
            {
                Console.WriteLine("{0} \t {1}", score.Joueur, score.Score);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void Comparer()
        {
            if (LeJoueur.NCoup >= NCoupMax) Etat = EtatPartie.Perdu;
            else if (LeJoueur.Proposition == LeNombre.Valeur) Etat = EtatPartie.Gagne;
            else if (LeJoueur.Proposition < LeNombre.Valeur) Etat = EtatPartie.TropPetit;
            else Etat = EtatPartie.TropGrand;
        }

        public void Enregistrer()
        {
            var j = LesJoueurs.FirstOrDefault(x=>x.Nom == LeJoueur.Nom);
            if (j == null)
            {
                j = new Joueur { Nom = LeJoueur.Nom };
                j.Scores.Add(j.NCoup);
                LesJoueurs.Add(j);
            }
            else
            {
                j.Scores.Add(j.NCoup);
            }
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
