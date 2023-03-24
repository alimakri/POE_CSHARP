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
            var a1 = new A();
            a1.M1_1();
            a1.M1_2();

            //I1 i = new I1(); // INTERDIT
            I1 i = new A();
        }
    }
    public class A : I1
    {
        public void M1_1() { }

        public void M1_2() { }
    }
    public class B : I1
    {
        public void M1_1() { }

        public void M1_2() { }
    }
    public class C : I2
    {
        public void M2_1()
        {
            throw new NotImplementedException();
        }
    }
    public interface I1
    {
        void M1_1();
        void M1_2();
    }
    public interface I2
    {
        void M2_1();
    }
}
