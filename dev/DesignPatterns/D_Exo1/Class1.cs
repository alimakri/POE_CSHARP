using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Exo1
{
    public interface ISalarie
    {
        decimal GetSalaire();
        decimal Prime { get; }
    }
    public class Directeur : ISalarie
    {
        public Directeur(decimal prime)
        {

        }
        public decimal Prime => 1.2M;
        public decimal GetSalaire() => 5000 * Prime;

    }
    public class Employe : ISalarie
    {
        public Employe(decimal prime)
        {

        }
        public decimal Prime => 1;
        public decimal GetSalaire() => 2000 * Prime;
    }
    //  ChefdeProjet
}
