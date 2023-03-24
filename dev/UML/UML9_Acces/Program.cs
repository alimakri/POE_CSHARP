using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML9_Acces
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class A
    {
        public string P1 = "Propriété P1";
        private string P2;
        protected string P3;
        internal string P4;
        internal protected string P5;
        public static string P11;
        public void M()
        {
            var x1 = P1;
            var x2 = P2;
            var x3 = P3;
            var x4 = P4;
            var x5 = P5;
        }
    }
    public class B : A
    {
        public void M()
        {
            var x1 = P1;
            var x3 = P3;
            var x4 = P4;
            var x5 = P5;
            var x11 = P11;
        }
    }
    public class C
    {
        public void M()
        {
            var a1 = new A();
            var x1 = a1.P1;
            var x4 = a1.P4;
            var x11 = A.P11;
        }
    }
}
