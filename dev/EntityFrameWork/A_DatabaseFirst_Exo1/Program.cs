using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DatabaseFirst_Exo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ca = ChiffreAffaire(2012); 
        }
        static decimal ChiffreAffaire(int annee)
        {
            var context = new AdventureWorks2017Entities();
            return context
                        .SalesOrderDetails
                        .Where(x => x.SalesOrderHeader.OrderDate.Year == annee)
                        .Sum(x => x.UnitPrice * x.OrderQty);
        }
    }
}
