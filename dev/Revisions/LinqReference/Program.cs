using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqReference
{
    class Program
    {
        static void Main(string[] args)
        {
            // Afficher ls produits Bikes > 2000 €
            var repo = new Repository();
            var produits = repo.GetProduits("Bikes");
            var liste = ...;
            foreach (var produit in liste)
            {
                Console.WriteLine(produit);
            }

        }
    }
}
