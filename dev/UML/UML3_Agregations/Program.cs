using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML3_Agregations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Agrégation
            int i = 0;
            DateTime auj = DateTime.Now;
            decimal pi = 3.14M;
            Personne p1 = new Personne { Nom = "Raymond" };
            Personne p2 = new Interprete { Nom = "Johnny" };

            List<Object> liste = new List<object>();
            liste.Add(i);
            liste.Add(auj);
            liste.Add(pi);
            liste.Add(p1);
            liste.Add(p2);

            foreach (var objet in liste)
            {
                Console.WriteLine(objet);
            }
            Console.ReadLine();
        }
    }
    class Personne
    {
        public string Nom;
        public override string ToString()
        {
            return "Personne --->" + Nom;
        }
    }
    class Interprete : Personne
    {
        public override string ToString()
        {
            return "Interprete --->" + Nom;
        }
    }
}
