using Microsoft.VisualStudio.TestTools.UnitTesting;
using Piscine_BOL;
using System;
using System.Collections.Generic;

namespace D_Piscine_Tests
{
    [TestClass]
    public class MetierTests
    {
        [TestMethod]
        public void Acces_Piscines()
        {
            Metier.NouvellePiscine(1, "PisCine 1", 250);
            Metier.NouvellePiscine(2, "Piscine 2", 410);
            Metier.NouvellePiscine(3, "Piscine 3", 210);
            Metier.NouvelAcces(1, "Bus 45", new int[] { 1, 2 });

            var listeObtenu = Metier.TestAcces1("Bus 45");
            var s = string.Join(",", listeObtenu).ToUpper();
            Assert.IsTrue(s== "PISCINE 1,PISCINE 2" || s== "PISCINE 2,PISCINE 1");
        }
    }
}
