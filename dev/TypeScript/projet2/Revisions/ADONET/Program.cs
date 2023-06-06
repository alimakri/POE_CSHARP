﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ADONET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repo = new Repository();
            // Avec les classes de bases en mode connecté
            var i = 1; var cats = repo.GetCat();
            foreach (var cat in cats)
            {
                Console.WriteLine($"{i}. {cat}");
                i++;
            }
            var catChoisi = FaireUnChoix(cats.ToList());
            foreach (var produit in repo.GetProduits(catChoisi))
            {
                Console.WriteLine(produit);
            }
            // id nomDuProduit Prix 
            // id nomDuProduit Prix 
            // id nomDuProduit Prix 
            // id nomDuProduit Prix 
            Console.ReadLine();
        }

        private static string FaireUnChoix(List<string> cats)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Choisissez une catégorie (1-4): ");
            
            var saisieStr = Console.ReadLine();
            int saisie = 0;
            while (!int.TryParse(saisieStr, out saisie) || saisie < 1 || saisie > 4)
            {
                saisieStr = Console.ReadLine();
                Console.Write("Choisissez une catégorie (1-4): ");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            return cats[saisie-1];
        }
    }
}
