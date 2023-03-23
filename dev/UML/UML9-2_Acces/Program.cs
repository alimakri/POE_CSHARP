using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UML9_Acces;

namespace UML9_2_Acces
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class D : A
    {
        public void M()
        {
            var x = P1;
            var x3 = P3;
            var x5 = P5;
            var x11 = P11;
        }
    }
    public class E
    {
        public void M()
        {
            var a1 = new A();
            var x = a1.P1;
            var x11 = A.P11;
        }
    }
}
