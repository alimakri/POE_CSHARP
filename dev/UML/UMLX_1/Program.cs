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
            var catTraiteur = new Categorie { Id = Guid.NewGuid(), Libelle = "Traiteur" };

            var camembert = new Produit { Id = Guid.NewGuid(), Libelle = "Président", Prix = 5.40M };
            var brie = new Produit { Id = Guid.NewGuid(), Libelle = "Brie", Prix = 4.40M };
            var pizza = new Produit { Id = Guid.NewGuid(), Libelle = "Vege", Prix = 7.70M };

            catFromage.Produits.Add(camembert);
            catFromage.Produits.Add(brie);
            catSurgele.Produits.Add(pizza);

            camembert.Categories.Add(catFromage);
            brie.Categories.Add(catFromage);
            pizza.Categories.Add(catSurgele);
            pizza.Categories.Add(catTraiteur);

            foreach (var p in catFromage.Produits)
            {
                Console.WriteLine(p.Libelle);
            }
            foreach (var c in pizza.Categories)
            {
                Console.WriteLine(c.Libelle);
            }

            Console.ReadLine();
        }
    }
    class Produit
    {
        public Guid Id;
        public string Libelle;
        public decimal Prix;
        public List<Categorie> Categories= new List<Categorie>();
    }
    class Categorie
    {
        public Guid Id;
        public string Libelle;
        public List<Produit> Produits = new List<Produit>();
    }

}
