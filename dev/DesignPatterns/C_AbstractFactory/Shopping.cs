using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_AbstractFactory
{
    public class Customer
    {
        public int[] Orders { get; set; } = Array.Empty<int>();
    }
    public class ShoppingCart
    {
        public readonly IVIPShoppingFactory Factory;
    }
    public interface IPourCentReduction { decimal Pourcentage { get; } }
    public interface IPrioriteCommande { int Priorite { get; } }
    public class StandardPourCentReduction : IPourCentReduction
    {
        public decimal Pourcentage => 1M;
    }
    public class VIPPourCentReduction : IPourCentReduction
    {
        public decimal Pourcentage => 15M;
        //public decimal Pourcentage() { return 15M; }
    }
    public class StandardPrioriteCommande : IPrioriteCommande
    {
        public int Priorite => 0;
    }
    public class VIPPrioriteCommande : IPrioriteCommande
    {
        public int Priorite => 1;
    }
    public interface IVIPShoppingFactory
    {
        IPourCentReduction GetReduction();
        IPrioriteCommande GetPriorite();
    }
    public class VIPShoppingFactory : IVIPShoppingFactory
    {
        public IPrioriteCommande GetPriorite() => new VIPPrioriteCommande();

        public IPourCentReduction GetReduction() => new VIPPourCentReduction();
    }
    public class StandardShoppingFactory : IVIPShoppingFactory
    {
        public IPrioriteCommande GetPriorite() => new StandardPrioriteCommande();

        public IPourCentReduction GetReduction() => new StandardPourCentReduction();
    }
}
