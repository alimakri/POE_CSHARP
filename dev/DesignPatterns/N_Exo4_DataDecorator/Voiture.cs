using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Exo4_DataDecorator
{
    public sealed class Voiture
    {
        public int Id;
        public string Name;
        public int Vitesse => 90;
        public void Rouler()
        {
            Console.WriteLine($"Je roule à {Vitesse}");
        }
        public void Freiner()
        {
            Console.WriteLine("Je freine");
        }
    }
    public class VoitureSport
    {
        private Voiture VoitureSource = new Voiture();
        public int Id { get { return VoitureSource.Id; } set { VoitureSource.Id = value; } }
        public string Name { get { return VoitureSource.Name; } set { VoitureSource.Name = value; } }
        public int Vitesse { get { return vitesse; } set { vitesse = value; } }
        private int vitesse = 300;
        public void Accelerer()
        {
            Console.WriteLine($"J'accélère");
        }
        public void Rouler()
        {
            Console.WriteLine($"Je roule à {Vitesse}");
        }
        public void Freiner()
        {
            VoitureSource.Freiner();
        }
    }
}
