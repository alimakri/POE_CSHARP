using Newtonsoft.Json;
using Piscine_Commun;
using Piscine_DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Piscine_BOL
{
    #region Entête
    public static class Metier
    {
        #region Propriétés
        private static Piscines LesPiscines = new Piscines();
        private static Access LesAcces = new Access();
        private static Activites LesActivites = new Activites();
        private static Configurations LesConfigurations = new Configurations();
        private static Stats LesStats = new Stats();


        public static void Init()
        {
            LesPiscines.Init();

        }
        #endregion

        #region Config
        public static void NouveauRegex(string nom, string regex)
        {
            LesConfigurations.Add(nom, regex);
        }
        public static ArrayList UpdatePiscines(Dictionary<string, object> dicoOccupation, Dictionary<string, object> dicoCapacite)
        {
            return LesPiscines.UpdatePiscines(dicoOccupation, dicoCapacite);
        }
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

        public static void LoadConfigs()
        {
            LesConfigurations.LoadConfigs();
        }


        #endregion

        #region Acces

        public static int NouvelAcces(string nom, int[] piscines)
        {
            return LesAcces.NouvelAcces(LesPiscines, nom, piscines);

        }
        #endregion

        #region Activite
        public static int NouvelleActivite(string d1, string d2, string nom, int idPiscine)
        {
            return LesActivites.NouvelleActivite(LesPiscines, LesActivites, d1, d2, nom, idPiscine);
        }


        public static string GetRegex(string nom)
        {
            var config = LesConfigurations.FirstOrDefault(x => x.Nom == nom);
            if (config == null) return null;
            return config.Regex;
        }

        public static void UpdateStats()
        {
            LesStats.UpdateStats();
        }

        public static void NouveauDetailActivite(string d1, string d2, int n, int idActivite)
        {
            LesActivites.NouveauDetailActivite(d1, d2, n, idActivite);
        }


        #endregion

        #region Test
        public static void Enregistrer()
        {
            LesActivites.Enregistrer(LesPiscines, LesAcces);
        }
        public static IEnumerable<string> TestAcces1(string nomAcces)
        {
            return LesAcces.TestAcces1(nomAcces);
        }

        public static bool IsInit()
        {
            return LesConfigurations.IsInit();
        }
        #endregion
    }
    #endregion

    #region Classes Métier de base
    public class Piscine
    {
        public int Id;
        public string Nom;
        public int Capacite;
        public int Occupation;
    }
    public class Acces
    {
        public int Id;
        public string Nom;
        public IEnumerable<Piscine> Piscines;
    }
    public class Configuration
    {
        public int Id;
        public string Nom;
        public string Regex;
    }
    public class Stat
    {
        public int Id;
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

    #region Body
    #region Piscine
    internal class Piscines : List<Piscine>
    {
        private static ServiceApi Api = new ServiceApi();

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

        internal void Init()
        {
            int capacite, occupation;
            var dicoOccupation = Api.GetPiscines(Repository.GetRegex("Occupation"));
            var dicoCapacite = Api.GetPiscines(Repository.GetRegex("Capacite"));

            foreach (var item in dicoCapacite)
            {
                if (!int.TryParse(item.Value.ToString(), out capacite)) capacite = -1;
                if (!int.TryParse(dicoOccupation[item.Key].ToString(), out occupation)) occupation = -1;

                var p = new Piscine { Nom = item.Key, Capacite = capacite, Occupation = occupation };
                Add(p);
                EnregistrerPiscine(p);
            }
        }

        /// <summary>
        // 2 actions : 1. Mettre à jour la liste des piscines dans cette couche métier
        //             2. Enregitrer (ou mettre à jour) dans la bdd.
        /// </summary>
        /// <param name="dicoOccupation"> infos temps réel des occupations</param>
        /// <param name="dicoCapacite">infos temps réel des capacités</param>
        /// <returns></returns>
        internal ArrayList UpdatePiscines(Dictionary<string, object> dicoOccupation, Dictionary<string, object> dicoCapacite)
        {
            var al = new ArrayList();
            int i = 0, j = 0; Piscine p; bool b1, b2;
            foreach (var item in dicoOccupation)
            {
                p = this.FirstOrDefault(x => x.Nom == item.Key);
                b1 = int.TryParse(item.Value.ToString(), out i);
                b2 = int.TryParse(dicoCapacite[item.Key].ToString(), out j);
                if (p == null)
                {
                    p = new Piscine { Nom = item.Key, Occupation = b1 ? i : -1, Capacite = b2 ? j : -1 };
                    Add(p);
                }
                else
                {
                    p.Occupation = b1 ? i : -1;
                    p.Capacite = b2 ? j : -1;
                }
                al.AddRange(p.ToArrayList());
                EnregistrerPiscine(p);
            }
            return al;
        }
    }
    #endregion

    #region Acces
    internal class Access : List<Acces>
    {
        internal int NouvelAcces(Piscines lesPiscines, string nom, int[] piscines)
        {
            var a = new Acces { Nom = nom };
            a.Piscines = lesPiscines.Where(x => piscines.Contains(x.Id));
            Add(a);
            return EnregistrerAcces(a);
        }
        private static int EnregistrerAcces(Acces a)
        {
            return Repository.EnregistrerAcces(a.ToArrayList());
        }

        internal IEnumerable<string> TestAcces1(string nomAcces)
        {
            var a = this.FirstOrDefault(x => x.Nom == nomAcces);
            if (a == null) return new List<string>();
            return a.Piscines.Select(x => x.Nom);
        }
    }
    #endregion

    #region Configurations
    internal class Configurations : List<Configuration>
    {
        internal int Add(string nom, string regex)
        {
            var p = new Configuration { Nom = nom, Regex = regex };
            Add(p);
            p.Id = EnregistrerConfig(p);
            return p.Id;
        }

        internal bool IsInit()
        {
            return Repository.IsInit();
        }

        internal void LoadConfigs()
        {
            Clear();
            foreach (var config in Repository.GetConfigs().ToConfig()) Add(config);
        }

        private int EnregistrerConfig(Configuration p)
        {
            return Repository.EnregistrerConfig(p.ToArrayList());
        }
    }
    #endregion

    #region Stats
    internal class Stats : List<Stat>
    {
        internal void UpdateStats()
        {
            Repository.UpdateStats();
        }
    }
    #endregion

    #region Activites
    internal class Activites : List<Activite>
    {
        internal void Enregistrer(Piscines lesPiscines, Access lesAcces)
        {
            Repository.Enregistrer(lesPiscines.ToArrayList(), lesAcces.ToArrayList());
        }

        internal void NouveauDetailActivite(string d1, string d2, int n, int idActivite)
        {
            var c = this.FirstOrDefault(x => x.Id == idActivite);
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

        internal int NouvelleActivite(Piscines lesPiscines, Activites lesActivites, string d1, string d2, string nom, int idPiscine)
        {
            var c = new Activite
            {
                DateDebut = Outils.ConvertToDateTime(FormatDateEnum.yyyyMMdd, d1),
                DateFin = Outils.ConvertToDateTime(FormatDateEnum.yyyyMMdd, d2),
                Nom = nom,
                Piscine = lesPiscines.FirstOrDefault(x => x.Id == idPiscine),
                LesDetails = new List<DetailActivite>()
            };
            lesActivites.Add(c);
            c.Id = EnregistrerActivite(c);
            return c.Id;
        }
        private static int EnregistrerActivite(Activite c)
        {
            return Repository.EnregistrerActivite(c.ToArrayList());
        }
    }
    #endregion

    #endregion

    #region WebAPi
    internal class ServiceApi
    {
        private WebClient Client = new WebClient();
        internal Dictionary<string, object> GetPiscines(string regex)
        {
            Client.Headers.Add("Content-Type", "application/json");
            var s = Client.UploadString($"http://localhost:57974/api/piscine/", "POST", "\"" + regex.Replace("\"", @"\""") + "\"");
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(s);
        }
    }
    #endregion
}
