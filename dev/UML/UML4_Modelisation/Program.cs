using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML4_Modelisation
{
    class Program
    {
        static void Main(string[] args)
        {
            var pierre = new Client(1, "Kiroul", "Pierre");
            var paul = new Client(2, "Ochon", "Paul");
            var comptePierre = new CompteBancaire(150);
            comptePierre.Titulaire = pierre;
            var comptePaul = new CompteBancaire(500);
            comptePaul.Titulaire = paul;

            Transferer(20, comptePaul, comptePierre);

            comptePierre.Decrire();
            comptePaul.Decrire();

            Console.ReadLine();
        }

        private static void Transferer(int valeur, CompteBancaire a, CompteBancaire b)
        {
            a.Debiter(valeur);
            b.Crediter(valeur);
        }
    }
    class Client
    {
        public int Numero;
        public string Nom;
        public string Prenom;
        public Client(int numero, string nom, string prenom)
        {
            Numero = numero;
            Nom = nom;
            Prenom = prenom;
        }
    }
    class CompteBancaire
    {
        public string Devise;
        public decimal Solde;
        public Client Titulaire;
        public CompteBancaire(decimal montant)
        {
            Solde = montant;
        }
        public bool Crediter(decimal montant)
        {
            Solde += montant;
            return true;
        }
        public bool Debiter(decimal montant)
        {
            if (Solde - montant >= 0)
            {
                Solde -= montant;
                return true;
            }
            return false;
        }
        public void Decrire()
        {
            Console.WriteLine("Le compte de {0} présente un solde de {1} {2}", Titulaire.Nom, Solde, Devise);
        }
    }
}
