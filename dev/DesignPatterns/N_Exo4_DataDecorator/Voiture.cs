using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Exo4_DataDecorator
{
    public sealed class Voiture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Vitesse  => 90;
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
        public void Accelerer()
        {
            Console.WriteLine($"J'accélère");
        }
    }
}
