using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Binding.ViewModels
{
    public class MainWindowViewModel
    {
        public Fleur Fleur1 { get; set; }
        public Fleur Fleur2 { get; set; }
        public MainWindowViewModel()
        {
            Fleur1 = new Fleur { Id = 1, Nom = "Rose du printemps", Couleur = "Red", Image = "/images/rose.png" };
            Fleur2 = new Fleur { Id = 2, Nom = "Lila de mai", Couleur = "Purple", Image = "/images/lila.png" };
        }
    }
    public class Fleur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Couleur { get; set; }
        public string Image { get; set; }
    }
}
