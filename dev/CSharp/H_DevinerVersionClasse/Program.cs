using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace H_DevinerVersionClasse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Properties.Settings.Default.Couleur);
            int menu = 0; Partie partie = null;
            while (menu != 3)
            {
                if (menu != 2) partie = new Partie(menu);
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
    public class Joueur
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
        public int Valeur = -1;
        public int Min = -1;
        public int Max = -1;
        public Random Alea = new Random();
        public NombreADeviner(int min, int max)
        {
            Min = min;
            Max = max;
        }
        public void Generer()
        {
            Valeur = Alea.Next(Min, Max + 1);
            if (Properties.Settings.Default.Triche)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Valeur);
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Properties.Settings.Default.Couleur);
            }
        }
    }
    enum EtatPartie { None, Gagne, Perdu, TropPetit, TropGrand }
    class Partie
    {
        public EtatPartie Etat = EtatPartie.None;
        public Joueur LeJoueur = new Joueur();
        public NombreADeviner LeNombre;
        public int NCoupMax = Properties.Settings.Default.NCoupMax;
        public List<Joueur> LesJoueurs = new List<Joueur>();
        public Partie(int menu)
        {
            if (Properties.Settings.Default.ModeBDD)
                LesJoueurs = LireDansBDD();
            else  
                LesJoueurs = LireDansFichier("scores.xml");
            LeNombre = new NombreADeviner(Properties.Settings.Default.Min, Properties.Settings.Default.Max);
            Console.Clear();
            Console.WriteLine($"Devinez un nombre compris entre {Properties.Settings.Default.Min} et {Properties.Settings.Default.Max}");
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
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Properties.Settings.Default.Couleur);
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
            var j = LesJoueurs.FirstOrDefault(x => x.Nom == LeJoueur.Nom);
            if (j == null)
            {
                j = new Joueur { Nom = LeJoueur.Nom };
                j.Scores.Add(LeJoueur.NCoup);
                LesJoueurs.Add(j);
            }
            else
            {
                j.Scores.Add(LeJoueur.NCoup);
            }
            if (Properties.Settings.Default.ModeBDD)
                EnregistrerDansBDD();
            else
                EnregistrerDansFichier("scores.xml");
        }

        private void EnregistrerDansFichier(string fichier)
        {
            var serialiser = new XmlSerializer(typeof(List<Joueur>));
            var stream = new StreamWriter(fichier);
            serialiser.Serialize(stream, LesJoueurs);
            stream.Close();
        }
        private List<Joueur> LireDansBDD()
        {
            
        }
        private List<Joueur> LireDansFichier(string fichier)
        {
            if (File.Exists("scores.xml"))
            {
                var serialiser = new XmlSerializer(typeof(List<Joueur>));
                var stream = new StreamReader(fichier);
                var liste = (List<Joueur>)serialiser.Deserialize(stream);
                stream.Close();
                return liste;
            }
            else
                return new List<Joueur>();
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
