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
            var context = new AdvContext();

            var ca = context.SalesOrderDetails.Where(x=>x.SalesOrderHeader.OrderDate.Year==2013).Sum(item => item.UnitPrice * item.OrderQty);


            Console.WriteLine(ca);
            Console.ReadLine();
        }
    }
}
