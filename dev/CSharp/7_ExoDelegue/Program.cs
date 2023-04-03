using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _7_ExoDelegue
{
    public delegate void AfficherDelegue();
    class Program
    {
        static void Main(string[] args)
        {
            var c1 = new Compteur { Nom="C1", Depart = 1, Arrivee = 9, Couleur = ConsoleColor.Green, Pause = 1000, Pas=1 };
            var c2 = new Compteur { Nom = "C2", Depart = 10, Arrivee = 200, Couleur = ConsoleColor.Red, Pause = 500, Pas = 10 };
            var c3 = new Compteur { Nom = "C3", Depart = 1000, Arrivee = 2000, Couleur = ConsoleColor.Yellow, Pause = 100, Pas = 100 };
            var d1 = new AfficherDelegue(c1.Afficher);
            var d2 = new AfficherDelegue(c2.Afficher);
            var d3 = new AfficherDelegue(c3.Afficher);
            d1.BeginInvoke(new AsyncCallback(c1.FinExec), ConsoleColor.Cyan);
            d2.BeginInvoke(new AsyncCallback(c2.FinExec), ConsoleColor.Magenta);
            d3.Invoke();
            //c.Afficher();
            Console.WriteLine("Fin du programme");
            Console.ReadLine();
        }
    }
    class Compteur
    {
        public string Nom;
        public int Depart;
        public int Arrivee;
        public ConsoleColor Couleur;
        public int Pause;
        public int Pas;

        internal void Afficher()
        {
            for (int i = Depart; i <= Arrivee; i+=Pas)
            {
                Console.ForegroundColor = Couleur;
                Console.WriteLine(i);
                Thread.Sleep(Pause);
            }
        }
        public void FinExec(IAsyncResult r)
        {
            Console.ForegroundColor = (ConsoleColor)r.AsyncState;
            Console.WriteLine("Fin du compteur {0}", Nom);
        }
    }
}
