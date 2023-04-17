using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_Bridge
{
    public interface IReduction
    {
        int Reduction { get; }
    }
    public class ReductionFaible : IReduction
    {
        public int Reduction => 1;
    }
    public class ReductionForte : IReduction
    {
        public int Reduction => 5;
    }
    public abstract class Abonnement
    {
        public readonly IReduction? Reduction;
        public Abonnement(IReduction? reduction)
        {
            Reduction = reduction;
        }
        public abstract decimal GetPrice();
    }
    public class AbonnementStandard : Abonnement
    {
        public AbonnementStandard(IReduction? reduction = null) : base(reduction)
        {
        }

        public override decimal GetPrice() => 50 - (Reduction is null ? 0 : Reduction.Reduction);
    }
    public class AbonnementPremium : Abonnement
    {
        public AbonnementPremium(IReduction reduction) : base(reduction)
        {
        }

        public override decimal GetPrice() => 150 - (Reduction is null ? 0 : Reduction.Reduction);
    }
}
