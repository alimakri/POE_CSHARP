using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H_UILWeb.ViewModels
{
    public class PiscineViewModel
    {
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int id;
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        private string nom;
        public string Adresse1
        {
            get { return adresse1; }
            set { adresse1 = value; }
        }
        private string adresse1;
        public string Adresse2
        {
            get { return adresse2; }
            set { adresse2 = value;  }
        }
        private string adresse2;
        public string Telephone
        {
            get { return telephone; }
            set { telephone = value;  }
        }
        private string telephone;


        public int Capacite
        {
            get { return capacite; }
            set { capacite = value; }
        }
        private int capacite;

        public string OccupationStr
        {
            get { return occupation == -1 ? "-" : occupation.ToString(); }
        }
        public string CapaciteStr
        {
            get { var s = capacite > 1 ? "s" : ""; return capacite == -1 ? "" : $"{capacite.ToString()} place{s}"; }
        }
        public string ColorOccupation
        {
            get
            {

                if (occupation == -1) return "Silver";
                if (capacite == 0) return "Red";
                if ((double)occupation / capacite > Properties.Settings.Default.SeuilOccupation) return "DarkOrange";
                return "Green";
            }
        }
        public int Occupation
        {
            get { return occupation; }
            set { occupation = value;  }
        }
        private int occupation;


        public List<DateTime> Horaires
        {
            get { return horaires; }
            set { horaires = value; }
        }
        private List<DateTime> horaires;
        public List<string> HorairesStr
        {
            get { return horairesStr; }
            set { horairesStr = value; }
        }


        private List<string> horairesStr;
    }
}