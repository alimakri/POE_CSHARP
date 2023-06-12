using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y_AdvCommandes.ViewModels;

namespace Y_AdvCommandes.Data
{
    public class Repository
    {
        private AdvContext Context = new AdvContext();

        internal IEnumerable<int> GetAnnees()
        {
            return Context.SalesOrderHeaders.Select(x => x.OrderDate.Year).Distinct();
        }

        internal IEnumerable<CommandeViewModel> GetCommandes(int currentAnnee, MoisViewModel currentMois)
        {
            return Context.SalesOrderHeaders
                .Where(x => x.OrderDate.Year == currentAnnee && x.OrderDate.Month == currentMois.Numero)
                .Select(x => new CommandeViewModel
            {
                Reference = x.SalesOrderNumber,
                Total = x.SalesOrderDetails.Sum(y => y.OrderQty * y.UnitPrice)
            });
        }

        internal IEnumerable<DetailCommandeViewModel> GetDetailCommandes(string reference)
        {
            return Context.SalesOrderDetails.Where(x => x.SalesOrderHeader.SalesOrderNumber == reference)
                .Select(x => new DetailCommandeViewModel { Article = "x.Product.Name", Prix = x.UnitPrice, Quantite = x.OrderQty });
        }
    }
}
