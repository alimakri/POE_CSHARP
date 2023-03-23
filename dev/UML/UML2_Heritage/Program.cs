using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Drawing;

namespace Heritage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bois cerisier = new Bois { Couleur = Colors.Red, Densite = 3, Volume = 52, Espece = "Santal" };
            Materiau santal = new Bois { Couleur = Colors.Red, Densite = 3, Volume = 52, Espece = "Santal" };
            Materiau granite = new Materiau { Couleur = Colors.Red, Densite = 3, Volume = 52 };

            //var d = santal.Densite;
            //var coef = ((Bois)santal).Coef;
            //var poids = santal.CalculerPoids();

            //d = granite.Densite;
            //if (granite is Bois) coef = ((Bois)granite).Coef;
            //var poids2 = granite.CalculerPoids();

            ((Bois)santal).CalculerPoids(2);
            cerisier.CalculerPoids(2);
            granite.CalculerPoids();
        }
    }
    class Materiau
    {
        public Color Couleur;
        public int Densite;
        public int Volume;
        public int CalculerPoids()
        {
            return Densite * Volume;
        }
    }
    class Bois : Materiau
    {
        public string Espece;
        public int CalculerPoids(int coef)
        {
            return Densite * Volume * coef;
        }
    }
}
