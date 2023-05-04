﻿using G_UILWpf.CommunViewModels;
using G_UILWpf.Dto;
using Piscine_BOL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace G_UILWpf.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Bindings
        public List<PiscineViewModel> Piscines
        {
            get { return piscines; }
            set { piscines = value; OnPropertyChanged("Piscines"); }
        }
        private List<PiscineViewModel> piscines;
        #endregion

        #region Propriétés
        private ClientWebApi Api = new ClientWebApi();
        #endregion

        public MainWindowViewModel()
        {
            Thread.Sleep(5000);
            if (Metier.IsInit())
            {
                //Metier.NouveauRegex("Capacite", @"<td class=""place-name"">[\n\t ]*(.*?)[\n\t ]*<\/td>(?:.*?)*(?:\s)*([0-9]*)(?:.*?)(?:\s)*<td(?:.*?)>(?:\s)*<div(?:.*?)>(?:[\s-])*<\/div>(?:\s)*<div(?:.*?)>(?:[A-zé\n\s-])*<\/div>(?:\s)*<div(?:.*?)>(?:\s*?)[\s]*Capacité totale :  [0-9]*");
                Metier.NouveauRegex("Occupation", @"<td class=""place-name"">([^<]+)[^<]+<[^<]+<[^<]+<[^>]+>([^<]+)<");
                Metier.NouveauRegex("Capacite", @"<td class=""place-name"">([^<]+)[^<]+<[^<]+<[^<]+<[^>]+>[^<]+<[^<]+<[^<]+<[^<]+<[^>]+>[^:]*:  ([0-9]*)");
                Metier.Init();
            }
            Metier.LoadConfigs();
            Piscines = Metier.GetPiscines(new ArrayList { 0 }).ToListPiscine();
            TempsReel();
        }

        private async void TempsReel()
        {
            while (true)
            {
                await Task.Delay(3000);
                var regex1 = Metier.GetRegex("Occupation");
                var regex2 = Metier.GetRegex("Capacite");
                var dicoOccupation = Api.GetPiscines(regex1);
                var dicoCapacite = Api.GetPiscines(regex2);
                ArrayList al = Metier.SaveConfigs(dicoOccupation, dicoCapacite);
                Piscines = al.ToListPiscine();
            }
        }

    }
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
            set { occupation = value; }
        }
        private int occupation;

    }
}
