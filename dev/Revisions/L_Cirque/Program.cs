using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_Cirque
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ISpectacle seance1 = new SeanceCinema();
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
        public void VoirAcrobaties() { Console.WriteLine("Je vois des acrobaties au cirque"); }
        public void VoirAnimaux() { Console.WriteLine("Je vois des animaux au cirque"); }
        public void ParticiperAvecLesClowns() { Console.WriteLine("Je participe avec les clowns"); }

    }
    public class SeanceCinema : ISpectacle
    {
        public void VoirAcrobaties() { Console.WriteLine("Je vois des acrobaties au cinéma"); }
        public void VoirAnimaux() { Console.WriteLine("Je vois des animaux au cinéma"); }
    }
}
