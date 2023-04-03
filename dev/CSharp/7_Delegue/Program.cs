using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Delegue
{
    //  Version 1
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Centrale();
            c.RefroidirTout();
            Console.ReadLine();
        }
    }
    class Centrale
    {
        public ArrayList Pompes;
        public Centrale()
        {
            Pompes = new ArrayList();
            var p1 = new PompeHydraulique();
            var p2 = new PompeHydraulique();
            var p3 = new PompeElectrique();
            var p4 = new PompeManuelle();
            Pompes.Add(p1);
            Pompes.Add(p2);
            Pompes.Add(p3);
            Pompes.Add(p4);
        }
        public void RefroidirTout()
        {
            foreach (object p in Pompes)
            {
                if (p is PompeHydraulique)
                {
                    ((PompeHydraulique)p).Refroidir();
                }
                else if (p is PompeElectrique)
                {
                    ((PompeElectrique)p).Refroidir();
                }
                else throw new Exception("Grave Erreur");
            }
        }
    }
    class PompeHydraulique
    {
        public void Refroidir() { Console.WriteLine("La pompe hydraulique est lancée !"); }
    }
    class PompeElectrique
    {
        public void Refroidir() { Console.WriteLine("La pompe electrique est lancée !"); }
    }
    class PompeManuelle
    {
        public void Refroidir() { Console.WriteLine("La pompe manuelle est lancée !"); }
    }
}
