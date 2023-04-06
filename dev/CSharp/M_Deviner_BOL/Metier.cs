using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_Deviner_BOL
{
    public static class Metier
    {
        private static Partie MaPartie;
        public static int Proposer(int proposition)
        {
            MaPartie.LeJoueur.Proposition = proposition;
            MaPartie.Comparer();
            return (int) MaPartie.Etat;
        }

        public static void SetParametres(int nCoupMax, int min, int max, bool modeBdd, bool triche)
        {
            MaPartie = new Partie();
            MaPartie.NCoupMax = nCoupMax;
            MaPartie.ModeBDD = modeBdd;
            MaPartie.Triche = triche;
            MaPartie.LeNombre = new NombreADeviner(min, max);
            MaPartie.LeNombre.Generer();

        }

        public static void SetJoueur(string nom)
        {
            MaPartie.LeJoueur = new Joueur { Nom = nom, Scores = new List<int>() };
        }
    }
}
