using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random alea = new Random();
            string nom = "";
            int proposition = 0;
            int nombreADeviner;
            int nCoup = 0;
            bool partieFinie;
            string[] scores = new string[10];
            int index = 0;

            // Pour tester ----------
            scores[0] = "André|5";
            scores[1] = "Monique|4";
            index = 2;
            // ----------------------

            while (true)
            {
                Console.Write("Votre nom : ");
                nom = Console.ReadLine();

                Console.WriteLine("{0}, deviner un nombre compris entre 1 et 99", nom);
                nombreADeviner = alea.Next(1, 100);
                //Console.WriteLine(nombreADeviner);
                nCoup = 0; partieFinie = false;
                while (!partieFinie)
                {
                    nCoup++;
                    if (nCoup == 8)
                    {
                        Console.WriteLine("Perdu");
                        partieFinie = true;
                    }
                    else
                    {
                        Console.Write("Proposition {0} : ", nCoup);
                        var propositionStr = Console.ReadLine();
                        if (int.TryParse(propositionStr, out proposition))
                        {
                            if (proposition < nombreADeviner)
                                Console.WriteLine("Trop petit");
                            else if (proposition > nombreADeviner)
                                Console.WriteLine("Trop grand");
                            else
                            {
                                Console.WriteLine("Gagné");
                                partieFinie = true;
                                scores[index] = nom + "|" + nCoup;
                                index++;
                                if (index == scores.Length) index = 0;
                                AffichageScore(scores);
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                        }
                        else
                            Console.WriteLine("Saisie incorrecte");
                    }
                }
                Console.ReadLine();
            }

        }
        static void AffichageScore(string[] scores)
        {
            scores = Trier(scores);

            for (int i = 0; i < scores.Length; i++)
            {
                if (scores[i] != null)
                {
                    var tab = scores[i].Split('|');
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("{0}\t{1}", tab[0], tab[1]);
                }
            }
        }

        static string[] Trier(string[] scores)
        {
            var fin = false; var index = 0; var a = 0; var b = 0;
            while (!fin)
            {
                string tampon;
                var tab1 = scores[index].Split('|');
                a = int.Parse(tab1[1]);
                if (scores[index + 1] == null || index +1 == scores.Length)
                {
                    fin = true;
                }
                else
                {
                    var tab2 = scores[index + 1].Split('|');
                    b = int.Parse(tab2[1]);
                    if (a > b)
                    {
                        // Inversion
                        tampon = scores[index + 1];
                        scores[index + 1] = scores[index];
                        scores[index] = tampon;
                        index = 0;
                    }
                    else
                    {
                        index++;
                    }
                }
            }
            return scores;
        }
    }
}
