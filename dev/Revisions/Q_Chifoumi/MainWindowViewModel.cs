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
            PierreCommand = new RelayCommand(PierreCommandExecute);
            FeuilleCommand = new RelayCommand(FeuilleCommandExecute);
            CiseauCommand = new RelayCommand(CiseauCommandExecute);

            NouvellePartieCommand = new RelayCommand(NouvellePartieCommandExecute);
            FermerCommand = new RelayCommand(FermerCommandExecute);
        }
        #endregion

        #region Propriétés
        private Random alea = new Random();
        #endregion

        #region Command
        private void NouvellePartieCommandExecute(object obj)
        {
            Points = 0;
            PierreEnabled = true;
            FeuilleEnabled = true;
            CiseauEnabled = true;
            Message = "Nouvelle partie";
            MessageCouleur = "blue";
        }
        private void FermerCommandExecute(object obj)
        {
            Application.Current.Shutdown();
        }
        private void PierreCommandExecute(object obj)
        {
            ChoixUtilisateurExecute(Chifoumi.Pierre);
        }
        private void FeuilleCommandExecute(object obj)
        {
            ChoixUtilisateurExecute(Chifoumi.Feuille);
        }
        private void CiseauCommandExecute(object obj)
        {
            ChoixUtilisateurExecute(Chifoumi.Ciseau);
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
                    CiseauEnabled = FeuilleEnabled = PierreEnabled = false;
                    break;
                case -3:
                    Message = "Vous avez perdu !";
                    MessageCouleur = "red";
                    CiseauEnabled = FeuilleEnabled = PierreEnabled = false;
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
            var choixInt = alea.Next(1, 4);
            return (Chifoumi)choixInt;
        }
        #endregion

        #region Bindings
        public ICommand PierreCommand { get; set; }
        public ICommand FeuilleCommand { get; set; }
        public ICommand CiseauCommand { get; set; }
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

        public bool PierreEnabled
        {
            get { return pierreEnabled; }
            set { pierreEnabled = value; OnPropertyChanged("PierreEnabled"); }
        }
        private bool pierreEnabled = true;
        public bool FeuilleEnabled
        {
            get { return feuilleEnabled; }
            set { feuilleEnabled = value; OnPropertyChanged("FeuilleEnabled"); }
        }
        private bool feuilleEnabled =true;
        public bool CiseauEnabled
        {
            get { return ciseauEnabled; }
            set { ciseauEnabled = value; OnPropertyChanged("CiseauEnabled"); }
        }
        private bool ciseauEnabled = true;

        #endregion
    }
    public class ChoixViewModel 
    {
        public string Image { get; set; }
        public string Texte { get; set; }
    }
}
