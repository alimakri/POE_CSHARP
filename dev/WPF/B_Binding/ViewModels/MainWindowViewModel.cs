using B_Binding.CommunViewModels;
using Installation.CommunViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace B_Binding.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Bindings
        public Fleur Fleur1 { get; set; }
        public Fleur Fleur2 { get; set; }
        public List<Magasin> Magasins { get; set; }
        public Magasin CurrentMagasin { get; set; }
        #endregion

        #region Command
        public ICommand AjouterCommand { get; set; }
        public ICommand UnselectCommand { get; set; }
        #endregion
        public MainWindowViewModel()
        {
            // Bindings
            Fleur1 = new Fleur { Id = 1, Nom = "Rose du printemps", Couleur = "Red", Image = "/images/rose.png" };
            Fleur2 = new Fleur { Id = 2, Nom = "Lila de mai", Couleur = "Purple", Image = "/images/lila.png" };

            // Command
            AjouterCommand = new RelayCommand(AjouterCommandExecute, null);
            UnselectCommand = new RelayCommand(UnselectCommandExecute);
            Magasins = new List<Magasin>
            {
                new Magasin{Id=1, Nom= "Rosier rose tendre", Couleur="Orange"},
                new Magasin{Id=2, Nom= "Rythme bonzaï", Couleur="Orange"},
                new Magasin{Id=2, Nom= "Histoire de fleur", Couleur="cyan"},
                new Magasin{Id=2, Nom= "Aero fleur", Couleur="lightcyan"},
                new Magasin{Id=1, Nom= "Ambiance rose", Couleur="Yellow"}
            };
        }

        private void UnselectCommandExecute(object obj)
        {
            CurrentMagasin = null;
        }

        private void AjouterCommandExecute(object obj)
        {
            
        }


    }
    public class Fleur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Couleur { get; set; }
        public string Image { get; set; }
    }
    public class Magasin 
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Couleur { get; set; }
    }
}
