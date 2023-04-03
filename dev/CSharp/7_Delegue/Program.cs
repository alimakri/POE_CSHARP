using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Delegue
{
    //  Version 3
    public delegate void RefroidirDelegue(EventArgsCentrale args);
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
        //public ArrayList Pompes;
        public List<RefroidirDelegue> Delegues = new List<RefroidirDelegue>();
        public Centrale()
        {
            //Pompes = new ArrayList();
            //var p1 = new PompeHydraulique();
            //var p2 = new PompeHydraulique();
            //var p3 = new PompeElectrique();
            //var p4 = new PompeManuelle();
            //Pompes.Add(p1);
            //Pompes.Add(p2);
            //Pompes.Add(p3);
            //Pompes.Add(p4);

            var p1 = new PompeHydraulique();
            var p2 = new PompeHydraulique();
            var p3 = new PompeElectrique();
            var p4 = new PompeManuelle();
            Delegues.Add(p1.Refroidir);
            Delegues.Add(p2.Refroidir);
            Delegues.Add(p3.Refroidir);
            Delegues.Add(p4.Refroidir);
            //Delegues.Add(p1.Refroidir2);

        }
        public void RefroidirTout()
        {
            //foreach (object p in Pompes)
            //{
            //    if (p is PompeHydraulique)
            //    {
            //        ((PompeHydraulique)p).Refroidir();
            //    }
            //    else if (p is PompeElectrique)
            //    {
            //        ((PompeElectrique)p).Refroidir();
            //    }
            //    else throw new Exception("Grave Erreur");
            //}
            var args = new EventArgsCentrale { Temperature=3000, Pression=50 };
            foreach(var d in Delegues)
            {
                d.Invoke(args);
            }
        }
    }
    class PompeHydraulique
    {
        public void Refroidir(EventArgsCentrale args) { Console.WriteLine("La pompe hydraulique est lancée !"); }
        //public void Refroidir2(int t) { Console.WriteLine("La pompe hydraulique est lancée !"); }
    }
    class PompeElectrique
    {
        public void Refroidir(EventArgsCentrale args) { Console.WriteLine("La pompe electrique est lancée !"); }
    }
    class PompeManuelle
    {
        public void Refroidir(EventArgsCentrale args) { Console.WriteLine("La pompe manuelle est lancée !"); }
    }
    class EventArgsCentrale : EventArgs
    {
        public int Temperature;
        public int Pression;
    }
}
