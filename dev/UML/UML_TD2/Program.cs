using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_TD2
{
    public class Program
    {
        static void Main(string[] args)
        {
            var johny = new Interprete();
            johny.Chanter();
            johny.SeProduire();

            //I1 i = new I1(); // INTERDIT
            IPersonne i = new Interprete();
            IPersonne j = new Compositeur();
        }
    }
    public class Interprete : IPersonne
    {
        public void Chanter() { }

        public void SeProduire() { }
    }
    public class Compositeur : IPersonne
    {
        public void Chanter() { }

        public void SeProduire() { }
    }
    public class Auto : IVehicule
    {
        public void Rouler()
        {
            throw new NotImplementedException();
        }
    }
    public interface IPersonne
    {
        void Chanter();
        void SeProduire();
    }
    public interface IVehicule
    {
        void Rouler();
    }
}
