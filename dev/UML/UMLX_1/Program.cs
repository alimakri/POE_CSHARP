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

            var camembert = new Produit { Id = Guid.NewGuid(), Libelle = "Président", Prix = 5.40M, Reduction = 0.8M };
            var brie = new Produit { Id = Guid.NewGuid(), Libelle = "Brie", Prix = 4.40M, Reduction = 0M };
            var pizza = new Produit { Id = Guid.NewGuid(), Libelle = "Vege", Prix = 7.70M, Reduction = 1.5M };
            var frombio = new ProduitBio { Id = Guid.NewGuid(), Libelle = "Au lait de chèvre", Prix = 27.70M, Label="Free pesticide" };

            catFromage.Produits.Add(camembert);
            catFromage.Produits.Add(brie);
            catFromage.Produits.Add(frombio);
            catSurgele.Produits.Add(pizza);

            camembert.Categories.Add(catFromage);
            brie.Categories.Add(catFromage);
            pizza.Categories.Add(catSurgele);
            pizza.Categories.Add(catTraiteur);

            foreach (Produit p in catFromage.Produits)
            {
                //var etoile = "";
                //if (p is ProduitBio) etoile = "*";
                var etoile = p is ProduitBio ? "*" : "";

                Console.WriteLine("{0}{1}", p.Libelle, etoile);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var c in pizza.Categories)
            {
                Console.WriteLine(c.Libelle);
            }

            var panier = new Panier();
            panier.Produits.Add(camembert);
            panier.Produits.Add(pizza);
            panier.Produits.Add(pizza);
            panier.BonsAchat.Add(5);
            panier.BonsAchat.Add(2);

            var montant = 0M;
            var montantBa = 0M;
            foreach (var p in panier.Produits)
            {
                montant += (p.Prix - p.Reduction);
            }
            foreach (var b in panier.BonsAchat)
            {
                montantBa += b;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(montant-montantBa);

            Console.ReadLine();
        }
    }
    class Produit
    {
        public Guid Id;
        public string Libelle;
        public decimal Prix;
        public List<Categorie> Categories = new List<Categorie>();
        public decimal Reduction;
    }
    class ProduitBio : Produit
    {
        public string Label;
    }
    class Categorie
    {
        public Guid Id;
        public string Libelle;
        public List<Produit> Produits = new List<Produit>();
    }
    class Panier
    {
        public List<Produit> Produits = new List<Produit>();
        public List<decimal> BonsAchat = new List<decimal>();
    }

}
