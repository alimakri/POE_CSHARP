using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Factory_Method
{
    #region Avec interface
    //public interface IMutuelle
    //{
    //    decimal GetPourcentRbtMedecinTraitant();
    //}
    //public class LesOiseauxMutuelle : IMutuelle
    //{
    //    public decimal GetPourcentRbtMedecinTraitant() => 100;
    //}
    //public class LesChevauxMutuelle : IMutuelle
    //{
    //    public decimal GetPourcentRbtMedecinTraitant() => 150;

    //}
    //public class PasDeMutuelle : IMutuelle
    //{
    //    public decimal GetPourcentRbtMedecinTraitant() => 0;

    //}
    //public class MutuelleFactory
    //{
    //    public IMutuelle GetMutuelle(Patient p)
    //    {
    //        if (string.IsNullOrEmpty(p.NumeroMutuelle)) return new PasDeMutuelle();
    //        if (p.NumeroMutuelle.StartsWith("003")) return new LesOiseauxMutuelle();
    //        return new LesChevauxMutuelle();
    //    }
    //}
    #endregion

    #region Avec classe abstraite
    public abstract class Mutuelle
    {
        public abstract decimal GetPourcentRbtMedecinTraitant();
    }
    public class LesOiseauxMutuelle : Mutuelle
    {
        public override decimal GetPourcentRbtMedecinTraitant() => 100;
    }
    public class LesChevauxMutuelle : Mutuelle
    {
        public override decimal GetPourcentRbtMedecinTraitant() => 150;

    }
    public class PasDeMutuelle : Mutuelle
    {
        public override decimal GetPourcentRbtMedecinTraitant() => 0;

    }
    public class MutuelleFactory
    {
        public Mutuelle GetMutuelle(Patient p)
        {
            if (string.IsNullOrEmpty(p.NumeroMutuelle)) return new PasDeMutuelle();
            if (p.NumeroMutuelle.StartsWith("003")) return new LesOiseauxMutuelle();
            return new LesChevauxMutuelle();
        }
    }
    #endregion

    public class Patient
    {
        public string? NumeroMutuelle { get; set; }
    }
}
