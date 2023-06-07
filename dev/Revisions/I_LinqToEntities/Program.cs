using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_LinqToEntities
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ca Réalisé par année
            // ---------------------
            // SELECT SUM(d.OrderQty* d.UnitPrice) AS ca, YEAR(h.OrderDate) AS Annee
            // FROM Sales.SalesOrderDetail AS d INNER JOIN
            //                  Sales.SalesOrderHeader AS h ON d.SalesOrderID = h.SalesOrderID
            // GROUP BY YEAR(h.OrderDate)
            // order by YEAR(h.OrderDate)
            // ---------------------
            // 12 646 112,1607   2011
            // 33 710 896,9379   2012
            // 43 922 050,7113   2013
            // 20 094 829,5035   2014

            var context = new AdvContext();

            //var ca = context.SalesOrderDetails
            //    .Where(x=>x.SalesOrderHeader.OrderDate.Year==2013)
            //    .Sum(item => item.UnitPrice * item.OrderQty);

            //var cas = context.SalesOrderDetails
            //    .GroupBy(x => x.SalesOrderHeader.OrderDate.Year)
            //    .Select(x => new { Annee = x.Key, Somme = x.Sum(y => y.UnitPrice * y.OrderQty) });

            var cas = from d in context.SalesOrderDetails
                       group d by d.SalesOrderHeader.OrderDate.Year into g
                       select new { Annee = g.Key, Somme = g.Sum(y => y.UnitPrice * y.OrderQty) };


            foreach (var ca in cas) Console.WriteLine(ca);
            Console.WriteLine();

            // Nombre de produits par cat, sous cat
            // ---------------------
            // SELECT
            //     c.Name Cat,
            //     s.Name SousCat,
            //     COUNT(c.ProductCategoryID) N
            // FROM
            //     Production.Product p
            //     INNER JOIN Production.ProductSubcategory s ON p.ProductSubcategoryID = s.ProductSubcategoryID
            //     INNER JOIN Production.ProductCategory c ON s.ProductCategoryID = c.ProductCategoryID
            // GROUP BY
            //    s.Name, c.Name
            // ORDER by
            //    N desc
            // ---------------------
            // Bikes Road Bikes  43
            // Components Road Frames 33
            // Bikes Mountain Bikes  32
            // Components Mountain Frames 28
            // Bikes Touring Bikes   22
            // Components Touring Frames  18
            // Components Wheels  14
            // Accessories Tires and Tubes 11
            // Components Saddles 9
            // Components Handlebars  8
            // Clothing Jerseys 8
            // .....
            var context2 = new AdvContext2();

            var produits = context2.Products;
            var items = from p in context2.Products
                        join s in context2.ProductSubcategories on p.ProductSubcategoryID equals s.ProductSubcategoryID
                        join c in context2.ProductCategories on s.ProductCategoryID equals c.ProductCategoryID
                        group new { c, s } by new { Cat = c.Name, SousCat = s.Name } into g
                        orderby g.Count() descending
                        select new { Cat = g.Key.Cat, SousCat = g.Key.SousCat, N = g.Count() };

            foreach (var item in items) Console.WriteLine(item);

            Console.ReadLine();

        }
    }

}
