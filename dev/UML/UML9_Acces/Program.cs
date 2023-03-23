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
        public string P1;
        private string P2;
        protected string P3;
        internal string P4;
        internal protected string P5;
    }
    public class B : A
    {

    }
    public class C
    {

    }
}
