using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Q_Chifoumi
{
    enum Chifoumi { Pierre = 1, Feuille = 2, Ciseau = 3 }
    public class MainWindowViewModel : ViewModelBase
    {
        #region Constructor
        public MainWindowViewModel()
        {
            PfcCommand = new RelayCommand(PfcCommandExecute);

            NouvellePartieCommand = new RelayCommand(NouvellePartieCommandExecute);
            FermerCommand = new RelayCommand(FermerCommandExecute);
        }
        #endregion

        #region Propriétés
        private Random Alea = new Random();
        #endregion

        #region Command
        private void NouvellePartieCommandExecute(object obj)
        {
            Points = 0;
            PfcEnabled = true;
            Message = "Nouvelle partie";
            MessageCouleur = "blue";
        }
        private void FermerCommandExecute(object obj)
        {
            Application.Current.Shutdown();
        }
        private void PfcCommandExecute(object obj)
        {
            Chifoumi choix = (Chifoumi)Enum.Parse(typeof(Chifoumi), (string)obj);
            ChoixUtilisateurExecute(choix);
        }

        private void ChoixUtilisateurExecute(Chifoumi choixUtilisateur)
        {
            var choixMachine = ChoixMachineExecute();
            ChoixMachine = new ChoixViewModel
            {
                Image = $"/images/{choixMachine.ToString()}.png",
                Texte = choixMachine.ToString()
            };
            switch (ComparerChoix(choixUtilisateur, choixMachine))
            {
                case 3:
                    Message = "Vous avez gagné !";
                    MessageCouleur = "green";
                    PfcEnabled = false;
                    break;
                case -3:
                    Message = "Vous avez perdu !";
                    MessageCouleur = "red";
                    PfcEnabled = false;
                    break;
            }
        }

        private int ComparerChoix(Chifoumi choixU, Chifoumi choixM)
        {
            if (choixM == choixU)
            {
                Points = 0;
                Message = "Egalité";
                MessageCouleur = "blue";
            }
            else if (
                choixU == Chifoumi.Pierre && choixM == Chifoumi.Ciseau ||
                choixU == Chifoumi.Feuille && choixM == Chifoumi.Pierre ||
                choixU == Chifoumi.Ciseau && choixM == Chifoumi.Feuille
                )
            {
                Points++;
                Message = "Gagné";
                MessageCouleur = "blue";
            }
            else
            {
                Points--;
                Message = "Perdu";
                MessageCouleur = "blue";
            }
            return Points;
        }

        private Chifoumi ChoixMachineExecute()
        {
            var choixInt = Alea.Next(1, 4);
            return (Chifoumi)choixInt;
        }
        #endregion

        #region Bindings
        public ICommand PfcCommand { get; set; }
        public ICommand FermerCommand { get; set; }
        public ICommand NouvellePartieCommand { get; set; }
        public int Points
        {
            get { return points; }
            set { points = value; OnPropertyChanged("Points"); }
        }
        private int points;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }
        private string message;
        public string MessageCouleur
        {
            get { return messageCouleur; }
            set { messageCouleur = value; OnPropertyChanged("MessageCouleur"); }
        }
        private string messageCouleur;

        public ChoixViewModel ChoixMachine
        {
            get { return choixMachine; }
            set { choixMachine = value; OnPropertyChanged("ChoixMachine"); }
        }
        private ChoixViewModel choixMachine;

        public bool PfcEnabled
        {
            get { return pfcEnabled; }
            set { pfcEnabled = value; OnPropertyChanged("PfcEnabled"); }
        }
        private bool pfcEnabled = true;

        #endregion
    }
    public class ChoixViewModel 
    {
        public string Image { get; set; }
        public string Texte { get; set; }
    }
}
