using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_ChessClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new ClientChess();// définir un client 
            client.GetNom();
            client.Sinscrire(); //supposant un nom unique pr chaque jouer
            if (client.AttenteAdversaire())// il retrouvera en prop Client si il est noir ou blanc
            {
                Console.WriteLine("Vous allez jouer contre {0}. Vous êtes les {1}", client.Adversaire, client.CouleurBlanc);// Adversaire & Couleur des prop de la classe Client



                while (client.Resultat == EtatPartieEnum.Continuer) // Résultat : blanc gangé /noir gagné /égaux /continuer == la partie n'a pas finie 
                {
                    client.Attente();
                    client.Jouer(); // couleur blanche au debut  ou C'EST SON TOUR 
                }
                Console.WriteLine("{0}", client.Resultat);
            }
            else
            {
                Console.WriteLine("Aucun Adversaire n'a été trouvé");




            }
            Console.ReadLine();
        }
    }
    internal class ClientChess
    {
        private ServiceApi service = new ServiceApi();

        public string Nom;
        internal ClientChess Adversaire;
        internal bool CouleurBlanc;
        internal EtatPartieEnum Etat;
        internal bool AMoiDeJouer = false;

        public void GetNom()
        {
            Console.Write("Nom :");
            Nom = Console.ReadLine();
        }
        public bool Sinscrire()
        {
            return service.Sinscrire(Nom);
        }
        public bool AttenteAdversaire()
        {
            Adversaire = null;
            int compteur = 0;
            while (Adversaire == null && compteur < 121)// 2 min
            {
                Adversaire = service.AttenteAdversaire();
                Thread.Sleep(1000);// pause
                compteur++;
            }
            return Adversaire != null;
        }

        internal void Jouer()
        {
            Console.Write("Déplacement : ");
            service.Jouer(Console.ReadLine().ToLower());
        }

        internal void Attente()
        {
            while (!AMoiDeJouer)
            {
                Adversaire = service.AttenteAdversaire(Adversaire);
                AMoiDeJouer = !Adversaire.AMoiDeJouer;
                Thread.Sleep(1000);// pause
            }
        }
    }

    internal class ClientServiceApi
    {
        private static WebClient ClientApi = new WebClient();
        private string BaseUrl = "http://localhost:52508/api/chess/";
        internal ClientChess AttenteAdversaire(ClientChess advAller)
        {
            //Recherche (Nom, Couleur)  - (AMoiDeJouer)
            ClientApi.Headers.Add("Content-Type", "application/json");
            var json = ClientApi.UploadString(BaseUrl, "POST", JsonConvert.SerializeObject(advAller));
            var advRetour = JsonConvert.DeserializeObject<ClientChess>(json);
            return advRetour;
        }



        internal bool Jouer(string coup)
        {
            var url = $"{BaseUrl}?coup={coup}";
            var json = ClientApi.DownloadString(url);
            return json == "true";
        }



        internal bool Sinscrire(string nom)
        {
            var url = $"{BaseUrl}?nom={nom}";
            var json = ClientApi.DownloadString(url);
            return json == "true";
        }
    }
    internal enum EtatPartieEnum
    {
        None,
        MatBlanc,
        MatNoir,
        Pat,
        Continuer,
    }
}
