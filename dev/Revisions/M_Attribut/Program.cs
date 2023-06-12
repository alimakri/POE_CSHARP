using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_Attribut
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client1 = new Client(); 
            client1.DisplayNiveau();
            Console.ReadLine();
        }
    }
    [Solde(1001)]
    [Categorie(Origine ="Particulier")]
    class Client
    {
        public void DisplayNiveau()
        {
             var attributes = typeof(Client).GetCustomAttributes(true);
            var attSolde = attributes.FirstOrDefault(x => x.GetType().ToString() == "M_Attribut.SoldeAttribute");
            var attCat = attributes.FirstOrDefault(x => x.GetType().ToString() == "M_Attribut.CategorieAttribute");
            if (attSolde != null && attCat!=null) Console.WriteLine("Vous avez le niveau {0} et la catégorie {1}",
                ((SoldeAttribute)attSolde).Classe,
                ((CategorieAttribute)attCat).Origine
                );
        }
    }
    [AttributeUsage(AttributeTargets.Class)]
    class SoldeAttribute : Attribute
    {
        public NiveauEnum Classe = NiveauEnum.None;
        public SoldeAttribute(double montant)
        {
            if (montant > 1000) Classe = NiveauEnum.Premium; else Classe = NiveauEnum.Standard;
        }
    }
    [AttributeUsage(AttributeTargets.Class)]
    class CategorieAttribute : Attribute
    {
        public string Origine;
    }
    public enum NiveauEnum { None, Standard, Premium }
}
