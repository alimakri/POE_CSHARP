using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Builder
{
    public class Pizza
    {
        public string Nom { get; set; }
        public Pizza(string nom)
        {
            Nom = nom;
        }
        public List<string> Ingredients { get; set; } = new List<string>();
        public void AjouterIngredients(string ingredient)
        {
            Ingredients.Add(ingredient);
        }
        public override string ToString()
        {
            return $"Pizza {Nom} - Ingrédients {string.Join(", ", Ingredients)}";
        } 
    }
    public abstract class PizzaBuilder
    {
        public Pizza Pizza { get; set; }
        public PizzaBuilder(string nom)
        {
            Pizza = new Pizza(nom);
        }
        public abstract void AjouterIngredients();
        public abstract void AjouterBase();
    }
    public class ChevreMielBuilder : PizzaBuilder
    {
        public ChevreMielBuilder(string nom) : base(nom)
        {
        }

        public override void AjouterBase()
        {
            Pizza.AjouterIngredients("Crème fraiche");
        }

        public override void AjouterIngredients()
        {
            Pizza.AjouterIngredients("Formage de chèvre");
            Pizza.AjouterIngredients("Miel");
            Pizza.AjouterIngredients("Olives");
        }
    }
    public class ReineBuilder : PizzaBuilder
    {
        public ReineBuilder(string nom) : base(nom)
        {
        }

        public override void AjouterBase()
        {
            Pizza.AjouterIngredients("Sauce tomate");
        }

        public override void AjouterIngredients()
        {
            Pizza.AjouterIngredients("Champignons");
            Pizza.AjouterIngredients("Mozzarela");
            Pizza.AjouterIngredients("Olives");
        }
    }
    public class BorneDeVente
    {
        public void PreparerPizza(PizzaBuilder builder)
        {
            builder.AjouterBase();
            builder.AjouterIngredients();
        }
    }
}
