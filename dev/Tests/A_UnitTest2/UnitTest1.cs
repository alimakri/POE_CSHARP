using A_UnitTest1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace A_UnitTest2
{
    [TestClass]
    public class UnitTest1
    {
        private Calculatrice C;

        [TestInitialize]
        public void Init()
        {
            C = new Calculatrice();
        }
        [TestMethod]
        public void TroisFoisSept()
        {
            var resultatAttendu = 21;
            var resultatObtenu = C.Multiplication(3, 7);
            Assert.IsTrue(resultatObtenu == resultatAttendu);
        }
        [TestMethod]
        public void FoisZero()
        {
            var alea = new Random();
            decimal resultatAttendu = 0;
            decimal resultatObtenu = 0; int n = 0;
            for (int i = 0; i < 100000; i++)
            {
                n = alea.Next(1, 1000000);
                resultatObtenu = C.Multiplication(n, 0);
                Assert.IsTrue(resultatObtenu == resultatAttendu);
            }
        }
        [TestMethod]
        public void DivSimple()
        {
            int op1 = 18;
            int op2 = 2;
            decimal resultatAttendu = 9; decimal resultatObtenu = 0;
            var b = C.TryDivision(op1, op2, out resultatObtenu);

            Assert.IsTrue(b && resultatObtenu == resultatAttendu);
        }
        [TestMethod]
        public void DivZero()
        {
            int op1 = 18;
            int op2 = 0;
            decimal resultatAttendu = 0; decimal resultatObtenu = 0;
            var b = C.TryDivision(op1, op2, out resultatObtenu);

            Assert.IsTrue(!b);
        }
    }
}
