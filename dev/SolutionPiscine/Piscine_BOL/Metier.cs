﻿using Piscine_Commun;
using Piscine_DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Piscine_BOL
{
    public static class Metier
    {
        #region Propriétés
        private static Piscines LesPiscines = new Piscines();
        private static List<Acces> LesAcces = new List<Acces>();
        private static List<Activite> LesActivites = new List<Activite>();
        #endregion

        #region Piscine

        public static int NouvellePiscine(string nom, int capacite)
        {
            return LesPiscines.Add(nom, capacite);
        }
        public static ArrayList GetPiscines(ArrayList recherche)
        {
            return LesPiscines.GetPiscines(recherche);
        }


        #endregion

        #region Acces

        public static int NouvelAcces(string nom, int[] piscines)
        {
            var a = new Acces { Nom = nom };
            a.Piscines = LesPiscines.Where(x => piscines.Contains(x.Id));
            LesAcces.Add(a);
            return EnregistrerAcces(a);
        }
        private static int EnregistrerAcces(Acces a)
        {
            return Repository.EnregistrerAcces(a.ToArrayList());
        }
        #endregion

        #region Activite
        public static int NouvelleActivite(string d1, string d2, string nom, int idPiscine)
        {
            var c = new Activite
            {
                DateDebut = Outils.ConvertToDateTime(FormatDateEnum.yyyyMMdd, d1),
                DateFin = Outils.ConvertToDateTime(FormatDateEnum.yyyyMMdd, d2),
                Nom = nom,
                Piscine = LesPiscines.FirstOrDefault(x => x.Id == idPiscine),
                LesDetails = new List<DetailActivite>()
            };
            LesActivites.Add(c);
            c.Id = EnregistrerActivite(c);
            return c.Id;
        }

        private static int EnregistrerActivite(Activite c)
        {
            return Repository.EnregistrerActivite(c.ToArrayList());
        }
        public static void NouveauDetailActivite(string d1, string d2, int n, int idActivite)
        {
            var c = LesActivites.FirstOrDefault(x => x.Id == idActivite);
            var d = new DetailActivite
            {
                DateDebut = Outils.ConvertToDateTime(FormatDateEnum.dd_MM_yyyy_HH_mm, d1),
                DateFin = Outils.ConvertToDateTime(FormatDateEnum.dd_MM_yyyy_HH_mm, d2),
                NombrePersonne = n,
                LActivite = c
            };
            c.LesDetails.Add(d);
            EnregistrerDetailActivite(c, d);
        }

        private static void EnregistrerDetailActivite(Activite c, DetailActivite d)
        {
            Repository.EnregistrerDetailActivite(c.Id, d.ToArrayList());
        }

        #endregion

        #region Test
        public static void Enregistrer()
        {
            Repository.Enregistrer(LesPiscines.ToArrayList(), LesAcces.ToArrayList());
        }
        #endregion

        #region Tests unitaires
        public static IEnumerable<string> TestAcces1(string nomAcces)
        {
            var a = LesAcces.FirstOrDefault(x => x.Nom == nomAcces);
            if (a == null) return new List<string>();
            return a.Piscines.Select(x => x.Nom);
        }
        #endregion
    }

    #region Classes de base
    public class Piscine
    {
        public int Id;
        public string Nom;
        public int Capacite;
    }
    public class Acces
    {
        public int Id;
        public string Nom;
        public IEnumerable<Piscine> Piscines;
    }
    public class Activite
    {
        public int Id;
        public DateTime DateDebut;
        public DateTime DateFin;
        public string Nom;

        public Piscine Piscine;
        public List<DetailActivite> LesDetails; 
    }
    public class DetailActivite
    {
        public int Id;
        public DateTime DateDebut;
        public DateTime DateFin;
        public int NombrePersonne;

        public Activite LActivite;
    }
    #endregion

    #region Piscine
    internal class Piscines : List<Piscine>
    {
        internal int Add(string nom, int capacite)
        {
            var p = new Piscine { Nom = nom, Capacite = capacite };
            Add(p);
            p.Id = EnregistrerPiscine(p); 
            return p.Id;
        }
        public int EnregistrerPiscine(Piscine p)
        {
            return Repository.EnregistrerPiscine(p.ToArrayList());
        }
        public ArrayList GetPiscines(ArrayList recherche)
        {
            return Repository.GetPiscines((int)recherche[0]);
        }
    }
    #endregion

}
