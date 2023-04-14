using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Exo1
{
    #region Avec interface
    //public interface ISalarie
    //{
    //    decimal GetSalaire();
    //    decimal Prime { get; }
    //}
    //public class Directeur : ISalarie
    //{
    //    public Directeur(decimal prime)
    //    {
    //        Prime = prime;
    //    }

    //    public decimal Prime { get; set; }

    //    public decimal GetSalaire() => 5000 * Prime;

    //}
    //public class Employe : ISalarie
    //{
    //    public Employe(decimal prime)
    //    {
    //        Prime = prime;
    //    }
    //    public decimal Prime { get; set; }
    //    public decimal GetSalaire() => 2000 * Prime;
    //}
    ////  ChefdeProjet
    //public class ChefdeProjet : ISalarie
    //{
    //    public decimal Prime { get; set; }

    //    public decimal GetSalaire() => 3000 * Prime;
    //}
    #endregion

    #region Suite 
    public abstract class Salarie
    {
        public abstract decimal GetSalaire();
        public virtual decimal Prime { get; set; }
        protected Salarie(decimal prime)
        {

        }
    }
    public class Directeur : Salarie
    {
        public Directeur(decimal prime) : base(prime)
        {
            Prime = prime;
        }

        public override decimal Prime { get; set; }

        public override decimal GetSalaire() => 5000 * Prime;

    }
    public class Employe : Salarie
    {
        public Employe(decimal prime) : base(prime)
        {
            Prime = prime;
        }
        public override decimal Prime { get; set; }
        public override decimal GetSalaire() => 2000 * Prime;
    }
    //  ChefdeProjet
    public class ChefdeProjet : Salarie
    {
        public ChefdeProjet(decimal prime) : base(prime)
        {
            Prime = prime;
        }

        public override decimal Prime { get; set; }

        public override decimal GetSalaire() => 3000 * Prime;
    }
    #endregion
}
