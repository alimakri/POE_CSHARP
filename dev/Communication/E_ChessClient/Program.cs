using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_ChessClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new ClientChess();
            var nom = client.GetNom();
            client.Sinscrire(nom);
            client.AttenteAdversaire();
            Console.WriteLine("Vous allez jouer contre {0}. Vous êtes les {1}", client.Adversaire, client.Couleur);
            while(client.Resultat == continuer)
            { 
                client.Attente();
                client.Jouer("E2E4");
            }
            Console.WriteLine("{0}", client.Resultat);
        }
    }
}
