﻿using System;
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
        public List<PersonneViewModel> ListePersonne { get; set; }
        public MainWindowViewModel()
        {
            var ds1 = Personnes.Get("5");
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
}