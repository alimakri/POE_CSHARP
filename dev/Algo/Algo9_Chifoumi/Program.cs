using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo9_Chifoumi
{
    enum Chifoumi { Pierre=1, Feuille=2, Ciseau=3}

    internal class Program
    {
        static Random alea = new Random();
        static void Main(string[] args)
        {
            var compteur = 0; int choixInt = 0; Chifoumi choixM, choixU; string choixStr = "";
            while (compteur < 4)
            {
                // Choix Machine
                choixInt = alea.Next(1, 4);
                choixM = (Chifoumi)choixInt;


                // Choix Utilisateur
                choixStr = "";
                while (choixStr != "1" && choixStr != "2" && choixStr != "3")
                {
                    Console.WriteLine("Choisissez (1-3) :");
                    Console.WriteLine("1. Pierre");
                    Console.WriteLine("2. Feuille");
                    Console.WriteLine("3. Ciseau");
                    choixStr = Console.ReadLine();
                }
                choixU = (Chifoumi)int.Parse(choixStr);

                if (choixM == choixU)
                {
                    compteur = 0;
                    Console.WriteLine("Egalité ! (score:0)");
                }
                else if (
                    choixU == Chifoumi.Pierre && choixM == Chifoumi.Ciseau ||
                    choixU == Chifoumi.Feuille && choixM == Chifoumi.Pierre ||
                    choixU == Chifoumi.Ciseau && choixM == Chifoumi.Feuille
                    )
                {
                    compteur++;
                    Console.WriteLine("Vous Gagnez ! (score:{0})", compteur);
                }
                else
                {
                    compteur = 0;
                    Console.WriteLine("Perdu ! (score:0)" );
                }
            }
            Console.ReadLine();
        }
    }
}
