﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Piscine_DAL
{
    public static class Repository
    {
        private static OccupationContext Context = new OccupationContext();

        #region Test
        public static void Enregistrer(ArrayList alPiscines, ArrayList alAccess)
        {
            Context.LesPiscines.AddRange(alPiscines.ToListPiscine());
            Context.SaveChanges();
            Context.LesAcces.AddRange(alAccess.ToListAcces());
            Context.SaveChanges();
        }
        #endregion

        #region Piscine
        internal static List<Piscine> GetAllPiscines()
        {
            return Context.LesPiscines.ToList();
        }
        public static ArrayList GetPiscines(int idAcces)
        {
            return Context.GetPiscines(idAcces);
        }
        public static int EnregistrerPiscine(ArrayList alPiscine)
        {
            return Context.EnregistrerPiscine(alPiscine);
        }
        #endregion

        #region Acces
        public static int EnregistrerAcces(ArrayList alAcces)
        {
            return Context.EnregistrerAcces(alAcces);
        }
        #endregion

        #region Activite
        internal static Activite GetActivite(int idActivite)
        {
            return Context.LesActivites.FirstOrDefault(x => x.Id == idActivite);
        }
        internal static List<DetailActivite> GetDetailsActivites(int idActivite)
        {
            return Context.LesActivites.FirstOrDefault(x => x.Id == idActivite).LesDetails;
        }
        public static int EnregistrerActivite(ArrayList alActivite)
        {
            return Context.EnregistrerActivite(alActivite);
        }
        public static void EnregistrerDetailActivite(int idActivite, ArrayList alActivite)
        {
            Context.EnregistrerDetailActivite(idActivite, alActivite);
        }

        #endregion
        #region Config
        public static int EnregistrerConfig(ArrayList alConfig)
        {
            return Context.EnregistrerConfig(alConfig);
        }

        public static string GetRegex(string nom)
        {
            return Context.LesConfigs.FirstOrDefault(x => x.Nom == nom).Regex;
        }

        public static bool IsInit()
        {
            try
            {
                return Context.LesConfigs.Count() == 0;
            }
            catch (Exception) { return true; }
        }

        public static ArrayList GetConfigs()
        {
            return Context.LesConfigs.ToList().ToArrayList();
        }

        public static void EnregistrerStat(int id, int occupation, DateTime d)
        {
            var p = Context.LesPiscines.FirstOrDefault(x => x.Id == id);
            var stat = new Stat { Piscine = p, Occupation=occupation, DateStat = d };
            Context.LesStats.Add(stat);
            Context.SaveChanges();
        }
        #endregion
    }
}
