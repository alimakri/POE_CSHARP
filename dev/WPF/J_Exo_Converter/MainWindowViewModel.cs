using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_Exo_Converter
{
    public class MainWindowViewModel
    {
        public PersonneViewModel P { get; set; }
        public MainWindowViewModel()
        {
            P = new PersonneViewModel { Id = 1, Nom = "Thorez", DateNaissance = new DateTime(1900, 4,28), Photo="thorez.png" };
        }
    }
    public class PersonneViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Photo { get; set; }
    }
}
