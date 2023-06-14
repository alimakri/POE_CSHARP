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
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            // Init ListePersonne
            var ds1 = Personnes.GetPersonnes(SourceEnum.Real);

            ListePersonne = new List<PersonneViewModel>();
            ListeDetails = new List<DetailsViewModel>();
            foreach (DataRow row in ds1.Tables["Personne"].Rows)
            {
                ListePersonne.Add(new PersonneViewModel { Id = (int)row["Id"], NomComplet = (string)row["NomComplet"] });
            }

        }
        // Personne
        public List<PersonneViewModel> ListePersonne { get; set; }
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
                foreach (DataRow row in ds1.Tables["Detail"].Rows)
                {
                    ListeDetails.Add(new DetailsViewModel { Magasin = (string)row["Magasin"] });
                }
            }
        }
        private PersonneViewModel currentPersonne;

        // ListeDetails
        public List<DetailsViewModel> ListeDetails { get; set; } 

    }
    public class PersonneViewModel
    {
        public int Id { get; set; }
        public string NomComplet { get; set; }
    }
    public class DetailsViewModel
    {
        public string Magasin { get; set; }
    }
}
