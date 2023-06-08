using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_WpfConverter
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            LesFleurs = new List<FleurViewModel>
            {
                new FleurViewModel{ Nom="Tulipe", Couleur="Rouge" },
                new FleurViewModel{ Nom="Oeillet", Couleur="Jaune" },
                new FleurViewModel{ Nom="Geranium", Couleur="Blanc" }
            };
        }
        public List<FleurViewModel> LesFleurs { get; set; }
    }
    public class FleurViewModel
    {
        public string Nom { get; set; }
        public string Couleur { get; set; }
        public override string ToString()
        {
            return Nom;
        }
    }
}
