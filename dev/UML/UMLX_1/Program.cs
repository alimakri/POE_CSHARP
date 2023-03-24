using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLX_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var catFromage = new Categorie { Id = Guid.NewGuid(), Libelle = "Fromage" };
            var catSurgele = new Categorie { Id = Guid.NewGuid(), Libelle = "Surgelé" };

            var camembert = new Produit { Id = Guid.NewGuid(), Libelle = "Président", Prix = 5.40M, Cat = catFromage };
            var brie = new Produit { Id = Guid.NewGuid(), Libelle = "Brie", Prix = 4.40M, Cat = catFromage };
            var pizza = new Produit { Id = Guid.NewGuid(), Libelle = "Vege", Prix = 7.70M, Cat = catSurgele };

            catFromage.Produits.Add(camembert);
            catFromage.Produits.Add(brie);
            catSurgele.Produits.Add(pizza);

            //List<Produit> produits = new List<Produit>();
            //produits.Add(camembert);
            //produits.Add(brie);
            //produits.Add(pizza);
            //var cat1 = "Fromage";
            foreach (var p in catFromage.Produits)
            {
                Console.WriteLine(p.Libelle);
            }

            Console.ReadLine();
        }
    }
    class Produit
    {
        public Guid Id;
        public string Libelle;
        public decimal Prix;
        public Categorie Cat;
    }
    class Categorie
    {
        public Guid Id;
        public string Libelle;
        public List<Produit> Produits = new List<Produit>();
    }

}
