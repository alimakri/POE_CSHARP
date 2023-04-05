using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_RevisionDelegue
{
    class Delegue1
    {
        public void M() { }
    }
    class Delegue2
    {
        public void N() { }
    }
    delegate void Delegue3();

    class Program
    {
        static void Main(string[] args)
        {
            var objet = new Delegue1();
            objet.M();
            var p1 = new P();
            var objet2 = new Delegue3(p1.R);

            var objet3 = new Delegue3(S.U);
            var objet4 = new Delegue3(X);
        }
        public static void X() { }
    }
    class P
    {
        public void R() { }
    }
    static class S
    {
        public static void U() { }
    }
}
