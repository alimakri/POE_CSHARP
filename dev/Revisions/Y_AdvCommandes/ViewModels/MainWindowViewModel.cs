using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y_AdvCommandes.Data;

namespace Y_AdvCommandes.ViewModels
{
    public class MainWindowViewModel
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
        List<CommandeViewModel> ListeCommande{ get; set; }
        private void FillCommands()
        {
            if (currentMois == null) return;
            ListeCommande = Repo.GetCommandes(currentAnnee, currentMois).ToList();
        }



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
            CurrentAnnee = ListeAnnee[0];
            CurrentMois = ListeMois[0];
        }
    }
    public class MoisViewModel
    {
        public int Numero { get; set; }
        public string Nom { get; set; }
    }
    public class CommandeViewModel
    {
        public string Reference { get; set; }
        public decimal Total { get; set; }
    }
}
