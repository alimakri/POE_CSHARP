using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DatabaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new AdvContext();

            // Tous les produits > 3000 €
            var produits = context.Products.Where(p=>p.ListPrice > 200);

            // Tous les produits de la categorie 'Bikes'
            produits = context.Products.Where(x => x.ProductSubcategory.ProductCategory.Name == "Clothing");

            foreach(var produit in produits)
            {
                Console.WriteLine(produit.Name);
            }
            Console.ReadLine();

        }
    }
}
