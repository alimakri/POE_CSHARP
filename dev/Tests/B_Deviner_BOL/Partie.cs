using M_Deviner_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace M_Deviner_BOL
{
    class Partie
    {
        public EtatPartie Etat = EtatPartie.None;
        public Joueur LeJoueur = new Joueur();
        public NombreADeviner LeNombre;
        public int NCoupMax = 0;
        public bool ModeBDD = false;
        public bool Triche = false;
        public List<Joueur> LesJoueurs = new List<Joueur>();
        public string MessageErreur = null;
        public Partie(bool mode, int ncoupMax, bool triche)
        {
            ModeBDD = mode;
            NCoupMax = ncoupMax;
            Triche = triche;
            if (mode)
            {
                //LesJoueurs = Donnees.LireDansBDD();
                var al = M_Deviner_DAL.Donnees.LireDansBDD("JeuBD");
                LesJoueurs = al.ToListJoueur();
                if (LesJoueurs == null)
                {
                    MessageErreur = "Pas de Sql Server";
                    LesJoueurs = new List<Joueur>();
                }
            }
            else
            {
                //LesJoueurs = Donnees.LireDansFichier("scores.xml");
                var al = M_Deviner_DAL2.Donnees.LireDansFichier("scores.xml");
                LesJoueurs = al.ToListJoueur();
            }
            LeJoueur.NCoup = 0;
        }


        public List<JoueurScore> GetMeilleursScores()
        {
            return LesJoueurs.SelectMany(j => j.Scores.Select(s => new JoueurScore { Joueur = j.Nom, Score = s }))
                             .OrderBy(x => x.Score)
                             .Take(5)
                             .ToList();
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
        public bool Enregistrer()
        {
            var j = LesJoueurs.FirstOrDefault(x => x.Nom == LeJoueur.Nom);
            if (j == null)
            {
                j = new Joueur { Nom = LeJoueur.Nom, NCoup = LeJoueur.NCoup };
                j.Scores.Add(LeJoueur.NCoup);
                LesJoueurs.Add(j);
            }
            else
            {
                j.Scores.Add(LeJoueur.NCoup);
            }
            if (ModeBDD)
            {
                if (!Donnees.EnregistrerDansBDD(j.Nom, j.NCoup))
                    return false;
            }
            else
                M_Deviner_DAL2.Donnees.EnregistrerDansFichier(LesJoueurs.ToArrayList(), "scores.xml");
            return true;
        }
    }
    public class Joueur
    {
        public string Nom = null;
        public List<int> Scores = new List<int>();
        public int Proposition = 0;
        public int NCoup = 0;
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
        }
    }
    enum EtatPartie { None, Gagne, Perdu, TropPetit, TropGrand }
    public class JoueurScore
    {
        public string Joueur;
        public int Score;
    }
}
