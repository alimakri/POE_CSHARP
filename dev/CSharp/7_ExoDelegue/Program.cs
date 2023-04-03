using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _7_ExoDelegue
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Compteur { Depart = 1, Arrivee = 10, Couleur = ConsoleColor.Green, Pause = 1000 };
            c.Afficher();
            Console.ReadLine();
        }
    }
    class Compteur
    {
        public int Depart;
        public int Arrivee;
        public ConsoleColor Couleur;
        public int Pause;

        internal void Afficher()
        {
            for (int i = Depart; i <= Arrivee; i++)
            {
                Console.ForegroundColor = Couleur;
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
        }
    }
}
