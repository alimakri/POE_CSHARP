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

            //comptePaul.SetSolde(100000);
            comptePaul.Solde = 100000;

            //Console.WriteLine(comptePaul.GetSolde());
            Console.WriteLine(comptePaul.Solde);

            Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine(comptePierre.GetSolde());
            Console.WriteLine(comptePierre.Solde);
            Console.WriteLine(comptePaul.Solde);
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

        public string Devise = "euros";
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

        //private decimal Solde = 0;
        //internal void SetSolde(int valeur)
        //{
        //    if (valeur > 3000) return;
        //    Solde = valeur;
        //}

        //internal decimal GetSolde()
        //{
        //    if (Titulaire.Prenom == "Paul") return 0;
        //    return Solde;
        //}

        public decimal Solde
        {
            get
            {
                if (Titulaire.Prenom == "Paul") return 0;
                return solde;
            }
            set
            {
                if (value > 3000) return;
                solde = value;
            }
        }
        private decimal solde;

    }
}
