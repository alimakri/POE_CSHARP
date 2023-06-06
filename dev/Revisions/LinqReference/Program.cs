using ADONET;
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
            // Afficher les produits Bikes > 2000 €
            var repo = new Repository();
            var produits = repo.GetProduits("Bikes");
            IEnumerable<ProduitV2> liste = produits
                .Where(x => x.Prix > 2000)
                .Select(x => new ProduitV2 { Id = x.Id, Nom = x.Nom, Prix = x.Prix });
            foreach (var produit in liste)
            {
                Console.WriteLine(produit);
            }
            Console.ReadLine();
        }
    }
    public class ProduitV2
    {
        public int Id;
        public string Nom;
        public decimal Prix;
        public override string ToString()
        {
            return $"{Id}\t{Nom}\t{Prix}";
        }
    }
}
