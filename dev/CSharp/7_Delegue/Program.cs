using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Delegue
{
    //  Version 4
    public delegate void RefroidirDelegue(EventArgsCentrale args);
    public class Program
    {
        static void Main(string[] args)
        {
            var c = new Centrale();
            c.RefroidirTout();
            Console.ReadLine();
        }
    }
    public class Centrale
    {

        //public ArrayList Pompes;
        //public List<RefroidirDelegue> Delegues = new List<RefroidirDelegue>();
        public event RefroidirDelegue FaitChaud;

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

            //var d1 = new RefroidirDelegue(p1.Refroidir);
            //var d2 = new RefroidirDelegue(p2.Refroidir);
            //var d3 = new RefroidirDelegue(p3.Refroidir);
            //var d4 = new RefroidirDelegue(p4.Refroidir);

            //Delegues.Add(d1);
            //Delegues.Add(d2);
            //Delegues.Add(d3);
            //Delegues.Add(d4);

            //Delegues.Add(p1.Refroidir2);

            FaitChaud += p1.Refroidir;
            FaitChaud += p2.Refroidir;
            FaitChaud += p3.Refroidir;
            FaitChaud += p4.Refroidir;
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
            //foreach (var d in Delegues)
            //{
            //    d.Invoke(args);
            //}
            FaitChaud(args);
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
    public class EventArgsCentrale : EventArgs
    {
        public int Temperature;
        public int Pression;
    }
}
