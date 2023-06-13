using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L_Cirque
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choisissez une langue :");
            Console.WriteLine("1. Français");
            Console.WriteLine("2. Anglais");
            Console.WriteLine("3. Espagnol");
            Console.WriteLine("4. Arabe");
            var lang = Console.ReadLine();
            switch (lang)
            {
                case "2": Thread.CurrentThread.CurrentUICulture = new CultureInfo("en"); break;
                case "3": Thread.CurrentThread.CurrentUICulture = new CultureInfo("es"); break;
                case "4": Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar"); break;
            }
            ISpectacle seance1 = new Cirque();
            seance1.VoirAcrobaties();
            seance1.VoirAnimaux();
            Console.ReadLine();
        }
    }

    public interface ISpectacle
    {
        void VoirAcrobaties();
        void VoirAnimaux();
    }

    public class Cirque : ISpectacle
    {
        public void VoirAcrobaties() { Console.WriteLine(Properties.Resources.Phrase1); }
        public void VoirAnimaux() { Console.WriteLine("Je vois des animaux au cirque"); }
        public void ParticiperAvecLesClowns() { Console.WriteLine("Je participe avec les clowns"); }

    }
    public class SeanceCinema : ISpectacle
    {
        public void VoirAcrobaties() { Console.WriteLine("Je vois des acrobaties au cinéma"); }
        public void VoirAnimaux() { Console.WriteLine("Je vois des animaux au cinéma"); }
    }
}
