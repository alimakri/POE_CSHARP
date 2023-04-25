using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Serialization;

namespace E_ChessService.Controllers
{
    public class ChessController : ApiController
    {
        private List<Joueur> ListeJoueur;
        private Random Alea = new Random();
        public ChessController()
        {
            ListeJoueur = DeserialisationXML();
        }
        [HttpPost]
        public Joueur AttenteAdversaire(Joueur demandeur)
        {

            //return ListeJoueur.FirstOrDefault(x => x.Nom != demandeur.Nom && x.AMoiDeJouer == AMoiDeJouerEnum.JouePas);
        }
        [HttpGet]
        public bool Jouer(string nom, string coup)
        {
            var joueur = ListeJoueur.FirstOrDefault(x => x.Nom == nom);
            if (joueur == null) return false;
            var etat = Alea.Next(1, 15);
            switch (etat)
            {
                case 1: // Coup interdit
                    return false;
                case 2:
                    // je gagne
                    joueur.Adversaire.Etat = joueur.Etat = joueur.CouleurBlanc ? EtatPartieEnum.MatBlanc : EtatPartieEnum.MatNoir;
                    joueur.Adversaire.AMoiDeJouer = joueur.AMoiDeJouer = AMoiDeJouerEnum.JouePas;
                    joueur.Adversaire.Etat = joueur.Etat;
                    break;
                case 3:
                    // je perds
                    joueur.Adversaire.Etat = joueur.Etat = !joueur.CouleurBlanc ? EtatPartieEnum.MatBlanc : EtatPartieEnum.MatNoir;
                    joueur.Adversaire.AMoiDeJouer = joueur.AMoiDeJouer = AMoiDeJouerEnum.JouePas;
                    break;
                case 4:
                    // Pat
                    joueur.Adversaire.Etat = joueur.Etat = EtatPartieEnum.Pat;
                    joueur.Adversaire.AMoiDeJouer = joueur.AMoiDeJouer = AMoiDeJouerEnum.JouePas;
                    break;
                default:
                    // Continue
                    joueur.Adversaire.Etat = joueur.Etat = EtatPartieEnum.Continuer;
                    joueur.AMoiDeJouer = AMoiDeJouerEnum.Lautre;
                    joueur.Adversaire.AMoiDeJouer = AMoiDeJouerEnum.Moi;
                    break;
            }
            return true;
        }
        [HttpGet]
        public bool Sinscrire(string nom)
        {
            var joueur = new Joueur { Nom = nom, AMoiDeJouer = AMoiDeJouerEnum.JouePas };
            var j = ListeJoueur.FirstOrDefault(x => x.Nom == nom);
            if (j != null) return false;
            ListeJoueur.Add(joueur);
            SerialisationXML();
            return true;
        }
        private void SerialisationXML()
        {
            var serialiser = new XmlSerializer(typeof(List<Joueur>));
            var flux = new StreamWriter(@"d:\lesJoueurs.txt");
            serialiser.Serialize(flux, ListeJoueur);
            flux.Close();
        }
        private List<Joueur> DeserialisationXML()
        {
            var serialiser = new XmlSerializer(typeof(List<Joueur>));
            var flux = new StreamReader(@"d:\lesJoueurs.txt");
            var liste = (List<Joueur>)serialiser.Deserialize(flux);
            flux.Close();
            return liste;
        }
    }
    public class Joueur
    {
        public string Nom;
        internal Joueur Adversaire;
        internal bool CouleurBlanc;
        internal EtatPartieEnum Etat;
        internal AMoiDeJouerEnum AMoiDeJouer = AMoiDeJouerEnum.JouePas;

    }
    internal enum AMoiDeJouerEnum { None, Moi, Lautre, JouePas }
    internal enum EtatPartieEnum
    {
        None,
        MatBlanc,
        MatNoir,
        Pat,
        Continuer,
    }
}
