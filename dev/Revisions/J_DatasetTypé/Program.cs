using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_DatasetTypé
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context2 = new AdvContext();

            var items = from p in context2.Products
                        join s in context2.ProductSubcategories on p.ProductSubcategoryID equals s.ProductSubcategoryID
                        join c in context2.ProductCategories on s.ProductCategoryID equals c.ProductCategoryID
                        group new { c, s } by new { Cat = c.Name, SousCat = s.Name } into g
                        orderby g.Count() descending
                        select new { Cat = g.Key.Cat, SousCat = g.Key.SousCat, N = g.Count() };

            // Remplir le dataset DataProduits
            var ds = new DataProduits();
            var table = ds.Tables["Produit"];

            DataRow row;
            foreach(var item in items)
            {
                row = table.NewRow();
                row["Id"] = Guid.NewGuid();
                row["Categorie"] = item.Cat;
                row["SousCategorie"] = item.SousCat;
                row["NombreProduit"] = item.N;
                table.Rows.Add(row);
            }

            foreach (DataRow item in ds.Tables["Produit"].Rows) 
                Console.WriteLine("{0}. {1}\t{2}\t{3}", 
                    item["Id"], 
                    item["Categorie"], 
                    item["SousCategorie"], 
                    item["NombreProduit"]);

            Console.ReadLine();
        }
    }
}
