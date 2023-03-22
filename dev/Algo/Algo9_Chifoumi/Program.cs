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
            // Choix Utilisateur
            string choixStr = "";
            while (choixStr != "1" && choixStr != "2" && choixStr != "3")
            {
                Console.WriteLine("Choisissez (1-3) :");
                Console.WriteLine("1. Pierre");
                Console.WriteLine("2. Feuille");
                Console.WriteLine("3. Ciseau");
                choixStr = Console.ReadLine();
            }
            var choixU = (Chifoumi)int.Parse(choixStr);

            // Choix Machine
            var choixInt = alea.Next(1, 4);
            var choixM = (Chifoumi)choixInt;

            if ( choixM == choixU) 
                Console.WriteLine("Egalité !");
            else if (
                choixU == Chifoumi.Pierre && choixM == Chifoumi.Ciseau ||
                choixU == Chifoumi.Feuille && choixM == Chifoumi.Pierre ||
                choixU == Chifoumi.Ciseau && choixM == Chifoumi.Feuille
                )
                Console.WriteLine("Vous Gagnez !");
            else
                Console.WriteLine("Je gagne !");

            Console.ReadLine();
        }
    }
}
