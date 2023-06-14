using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2_Metier;
using Z4_Dto;

namespace Z6_Bureau
{
    public class MainWindowViewModel : ViewModelBase
    {
        private List<DetailsViewModel> ListeComplete;
        public MainWindowViewModel()
        {
            // Init ListePersonne
            var ds1 = Personnes.GetPersonnes(SourceEnum.Real);

            ListePersonne = new List<PersonneViewModel>();
            ListeDetails = new List<DetailsViewModel>();
            ListeMagasins = new List<MagasinViewModel>();
            foreach (DataRow row in ds1.Tables["Personne"].Rows)
            {
                ListePersonne.Add(new PersonneViewModel { Id = (int)row["Id"], NomComplet = (string)row["NomComplet"] });
            }

        }
        // Personne
        public List<PersonneViewModel> ListePersonne { get; set; }

        public MagasinViewModel CurrentMagasin
        {
            get { return currentMagasin; }
            set
            {
                ListeDetails.Clear();
                OnPropertyChanged("ListeDetails");
                if (value == null) return;
                currentMagasin = value; OnPropertyChanged("CurrentMagasin");
                ListeDetails = ListeComplete.Where(x => x.Magasin == currentMagasin.Nom).ToList();
            }
        }
        private MagasinViewModel currentMagasin;


        public PersonneViewModel CurrentPersonne
        {
            get
            {
                return currentPersonne;
            }
            set
            {
                currentPersonne = value;
                var ds1 = Personnes.GetDetails(SourceEnum.Real, currentPersonne.Id);



                ListeComplete = new List<DetailsViewModel>();
                foreach (DataRow row in ds1.Tables["Detail"].Rows)
                {
                    ListeComplete.Add(new DetailsViewModel
                    {
                        Magasin = (string)row["Magasin"],
                        RefCommande = (string)row["RefCommande"]
                    });
                }
                ListeMagasins.Clear();
                ListeMagasins = ListeComplete.Distinct(new MagasinComparer()).Select(x => new MagasinViewModel { Nom = x.Magasin }).ToList();
                CurrentMagasin = ListeMagasins.FirstOrDefault();
            }
        }
        private PersonneViewModel currentPersonne;
        public class MagasinComparer : IEqualityComparer<DetailsViewModel>
        {
            public bool Equals(DetailsViewModel x, DetailsViewModel y)
            {
                return x.Magasin == y.Magasin;
            }

            public int GetHashCode(DetailsViewModel obj)
            {
                return 0;
            }
        }
        // ListeDetails
        public List<DetailsViewModel> ListeDetails
        {
            get
            {
                return listeDetails;
            }
            set
            {
                listeDetails = value;
                OnPropertyChanged("ListeDetails");
            }
        }
        private List<DetailsViewModel> listeDetails;
        public List<MagasinViewModel> ListeMagasins
        {
            get
            {
                return listeMagasins;
            }
            set
            {
                listeMagasins = value;
                OnPropertyChanged("ListeMagasins");
            }
        }
        private List<MagasinViewModel> listeMagasins;

    }
    public class MagasinViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
    }
    public class PersonneViewModel
    {
        public int Id { get; set; }
        public string NomComplet { get; set; }
    }
    public class DetailsViewModel : ViewModelBase
    {

        public string Magasin
        {
            get { return magasin; }
            set { magasin = value; OnPropertyChanged("Magasin"); }
        }
        private string magasin;
        public string RefCommande
        {
            get { return refCommande; }
            set { refCommande = value; OnPropertyChanged("Magasin"); }
        }
        private string refCommande;

    }
}
