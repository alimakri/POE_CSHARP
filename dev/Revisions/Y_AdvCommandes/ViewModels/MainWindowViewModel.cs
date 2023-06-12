using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y_AdvCommandes.CommunViewModels;
using Y_AdvCommandes.Data;

namespace Y_AdvCommandes.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Repository Repo = new Repository();
        // Année
        public List<int> ListeAnnee { get; set; }
        public int CurrentAnnee
        {
            get { return currentAnnee; }
            set
            {
                currentAnnee = value;
                FillCommands();
            }
        }
        private int currentAnnee;

        // Mois
        public List<MoisViewModel> ListeMois { get; set; }
        public MoisViewModel CurrentMois
        {
            get { return currentMois; }
            set
            {
                currentMois = value;
                FillCommands();
            }
        }
        private MoisViewModel currentMois;

        // Commandes

        public List<CommandeViewModel> ListeCommande
        {
            get { return listeCommande; }
            set { listeCommande = value; OnPropertyChanged("ListeCommande"); }
        }
        private List<CommandeViewModel> listeCommande;
        public List<DetailCommandeViewModel> ListeDetailCommande
        {
            get { return listeDetailCommande; }
            set { listeDetailCommande = value; OnPropertyChanged("ListeCommande"); }
        }
        private List<DetailCommandeViewModel> listeDetailCommande;

        private void FillCommands()
        {
            if (currentMois == null) return;
            ListeCommande = Repo.GetCommandes(currentAnnee, currentMois).ToList();
        }

        public CommandeViewModel CurrentCommande
        {
            get { return currentCommande; }
            set
            {
                currentCommande = value;
                OnPropertyChanged("ListeCommande");
                ListeDetailCommande = Repo.GetDetailCommandes(currentCommande.Reference).ToList();
            }
        }
        private CommandeViewModel currentCommande;



        public MainWindowViewModel()
        {
            ListeAnnee = Repo.GetAnnees().ToList();
            ListeMois = new List<MoisViewModel> {
            new MoisViewModel{ Numero=1, Nom="Janvier" },
            new MoisViewModel{ Numero=2, Nom="Février" },
            new MoisViewModel{ Numero=3, Nom="Mars" },
            new MoisViewModel{ Numero=4, Nom="Avril" },
            new MoisViewModel{ Numero=5, Nom="Mai" },
            new MoisViewModel{ Numero=6, Nom="Juin" },
            new MoisViewModel{ Numero=7, Nom="Juillet" },
            new MoisViewModel{ Numero=8, Nom="Août" },
            new MoisViewModel{ Numero=9, Nom="Septembre" },
            new MoisViewModel{ Numero=10, Nom="Octobre" },
            new MoisViewModel{ Numero=11, Nom="Novembre" },
            new MoisViewModel{ Numero=12, Nom="Décembre" },
            };
           
        }
    }
    public class MoisViewModel
    {
        public int Numero { get; set; }
        public string Nom { get; set; }
    }
    public class CommandeViewModel : ViewModelBase
    {

        public string Reference
        {
            get { return reference; }
            set { reference = value; OnPropertyChanged("Reference"); }
        }
        private string reference;
        public decimal Total
        {
            get { return total; }
            set { total = value; OnPropertyChanged("Total"); }
        }
        private decimal total;

    }
    public class DetailCommandeViewModel : ViewModelBase
    {
        public string Article
        {
            get { return article; }
            set { article = value; OnPropertyChanged("Reference"); }
        }
        private string article;
        public int Quantite
        {
            get { return quantite; }
            set { quantite = value; OnPropertyChanged("Quantite"); }
        }
        private int quantite;
        public decimal Prix
        {
            get { return prix; }
            set { prix = value; OnPropertyChanged("Prix"); }
        }
        private decimal prix;

    }
}
