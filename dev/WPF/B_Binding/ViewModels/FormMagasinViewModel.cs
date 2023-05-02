using B_Binding.CommunViewModels;
using Installation.CommunViewModels;
using System.Collections.Generic;
using System.Windows.Input;

namespace B_Binding.MagasinViewModels
{
    public class FormMagasinViewModel : ViewModelBase
    {
        
        public MagasinViewModel CurrentMagasin { get; set; }
        public ICommand EnregistrerCommand{ get; set; }
        public FormMagasinViewModel()
        {
            EnregistrerCommand = new RelayCommand(EnregistrerCommandExecute, EnregistrerCommandCanExecute);
            CurrentMagasin = new MagasinViewModel();
        }

        private bool EnregistrerCommandCanExecute(object obj)
        {
            return CurrentMagasin != null && CurrentMagasin.Id != default && !string.IsNullOrEmpty(CurrentMagasin.Nom) && !string.IsNullOrEmpty(CurrentMagasin.Couleur);
        }

        private void EnregistrerCommandExecute(object obj)
        {
            
        }
    }
    public class MagasinViewModel : ViewModelBase
    {
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }
        private int id;
        public string Nom
        {
            get { return nom; }
            set { nom = value; OnPropertyChanged("Nom"); }
        }
        private string nom;
        public string Couleur
        {
            get { return couleur; }
            set { couleur = value; OnPropertyChanged("Couleur"); }
        }
        private string couleur;


    }
}
