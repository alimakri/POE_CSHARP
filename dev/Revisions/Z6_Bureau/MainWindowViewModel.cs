using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2_Metier;

namespace Z6_Bureau
{
    public class MainWindowViewModel
    {
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

            }
        }
        private PersonneViewModel currentPersonne;

        // ListeDetails
        public List<DetailsViewModel> ListeDetails { get; set; }

        public MainWindowViewModel()
        {
            var ds1 = Personnes.Get(SourceEnum.Fake);
            ListePersonne = new List<PersonneViewModel>();
            foreach (DataRow row in ds1.Tables[0].Rows)
            {
                ListePersonne.Add(new PersonneViewModel { Id = (int)row["Id"], NomComplet = (string)row["NomComplet"] });
            }
        }
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
