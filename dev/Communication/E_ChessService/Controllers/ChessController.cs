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
            var adv = ListeJoueur.FirstOrDefault(x => x.Nom != demandeur.Nom && x.AMoiDeJouer == AMoiDeJouerEnum.JouePas);
            if (adv == null) return null;

            demandeur.CouleurBlanc = true;
            adv.CouleurBlanc = false;
            demandeur.AMoiDeJouer = AMoiDeJouerEnum.Moi;
            adv.AMoiDeJouer = AMoiDeJouerEnum.Lautre;
            adv.EtatPartie = demandeur.EtatPartie = EtatPartieEnum.Continuer;
            SerialisationXML();
            demandeur.Adversaire = adv;
            return demandeur;
        }
        [HttpGet]
        public bool Jouer(string nom, string coup, string nomAdv)
        {
            var joueur = ListeJoueur.FirstOrDefault(x => x.Nom == nom);
            joueur.Adversaire = ListeJoueur.FirstOrDefault(x => x.Nom == nomAdv);

            if (joueur == null) return false;
            var etat = Alea.Next(1, 15);
            switch (etat)
            {
                case 1: // Coup interdit
                    return false;
                case 2:
                    // je gagne
                    joueur.Adversaire.EtatPartie = joueur.EtatPartie = joueur.CouleurBlanc ? EtatPartieEnum.MatBlanc : EtatPartieEnum.MatNoir;
                    joueur.Adversaire.AMoiDeJouer = joueur.AMoiDeJouer = AMoiDeJouerEnum.JouePas;
                    joueur.Adversaire.EtatPartie = joueur.EtatPartie;
                    break;
                case 3:
                    // je perds
                    joueur.Adversaire.EtatPartie = joueur.EtatPartie = !joueur.CouleurBlanc ? EtatPartieEnum.MatBlanc : EtatPartieEnum.MatNoir;
                    joueur.Adversaire.AMoiDeJouer = joueur.AMoiDeJouer = AMoiDeJouerEnum.JouePas;
                    break;
                case 4:
                    // Pat
                    joueur.Adversaire.EtatPartie = joueur.EtatPartie = EtatPartieEnum.Pat;
                    joueur.Adversaire.AMoiDeJouer = joueur.AMoiDeJouer = AMoiDeJouerEnum.JouePas;
                    break;
                default:
                    // Continue
                    joueur.Adversaire.EtatPartie = joueur.EtatPartie = EtatPartieEnum.Continuer;
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
            if (j != null) return true;
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
            List<Joueur> liste = new List<Joueur>();
            if (File.Exists(@"d:\lesJoueurs.txt"))
            {
                var serialiser = new XmlSerializer(typeof(List<Joueur>));
                var flux = new StreamReader(@"d:\lesJoueurs.txt");
                liste = (List<Joueur>)serialiser.Deserialize(flux);
                flux.Close();
            }
            return liste;
        }
    }
    public class Joueur
    {
        public string Nom { get; set; }
        public Joueur Adversaire { get; set; }
        public bool CouleurBlanc { get; set; }
        public EtatPartieEnum EtatPartie { get; set; }
        public AMoiDeJouerEnum AMoiDeJouer { get; set; } = AMoiDeJouerEnum.JouePas;

    }
    public enum AMoiDeJouerEnum { None, Moi, Lautre, JouePas }
    public enum EtatPartieEnum
    {
        None,
        MatBlanc,
        MatNoir,
        Pat,
        Continuer,
    }
}
