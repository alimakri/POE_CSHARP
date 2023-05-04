﻿using G_UILWpf.Dto;
using Piscine_BOL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace G_UILWpf.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            //Thread.Sleep(5000);
            if (Metier.IsInit())
            {
                //Metier.NouveauRegex("Capacite", @"<td class=""place-name"">[\n\t ]*(.*?)[\n\t ]*<\/td>(?:.*?)*(?:\s)*([0-9]*)(?:.*?)(?:\s)*<td(?:.*?)>(?:\s)*<div(?:.*?)>(?:[\s-])*<\/div>(?:\s)*<div(?:.*?)>(?:[A-zé\n\s-])*<\/div>(?:\s)*<div(?:.*?)>(?:\s*?)[\s]*Capacité totale :  [0-9]*");
                Metier.NouveauRegex("Occupation", @"<td class=""place-name"">([^<]+)[^<]+<[^<]+<[^<]+<[^>]+>([^<]+)<");
                Metier.NouveauRegex("Capacite", @"<td class=""place-name"">([^<]+)[^<]+<[^<]+<[^<]+<[^>]+>[^<]+<[^<]+<[^<]+<[^<]+<[^>]+>[^:]*:  ([0-9]*)");
                Metier.Init();
            }
            Piscines = Metier.GetPiscines(new ArrayList { 0 }).ToListPiscine();
        }
        public List<PiscineViewModel> Piscines { get; set; }
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
            get { return occupation == -1 ? "Silver" : "Green"; }
        }
       public int Occupation
        {
            get { return occupation; }
            set { occupation = value; }
        }
        private int occupation;

    }
}
