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
}
