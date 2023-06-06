using System;

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
            var catChoisi = FaireUnChoix();
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
    }
}
