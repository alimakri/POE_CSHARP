﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace T_Chifoumi_ClientLeger.Controllers
{
    public class ChifoumiController : ApiController
    {
        public string Get(string id, string joueur)
        {
            DataChifoumi data = new DataChifoumi(joueur);
            var choixMachine = data.ChoixMachineExecute();
            var choixUtilisateur = (Chifoumi)Enum.Parse(typeof(Chifoumi), id.ToUpper());
            data.ComparerChoix(choixUtilisateur, choixMachine);
            return JsonConvert.SerializeObject(data);
        }
    }
    public enum Chifoumi { PIERRE = 1, FEUILLE = 2, CISEAU = 3 }
    public class DataChifoumi
    {
        public string ChoixMachine;
        public string ChoixUtilisateur;
        public int Points;
        public int Etat;
        public string Message;
        public string MessageCouleur;
        public string Joueur;

        private Random Alea = new Random();
        private Dictionary<string, int> Dico = new Dictionary<string, int>();
        private string ScoreFile;
        public DataChifoumi(string joueur)
        {
            ScoreFile = HttpContext.Current.Server.MapPath("/score.txt");
            Joueur = joueur;
            GetPoints(joueur);
        }

        private void GetPoints(string joueur)
        {
            // File Exists
            if (!System.IO.File.Exists(ScoreFile)) return;

            // Lecture du fichier
            var lignes = System.IO.File.ReadAllLines(ScoreFile);
            foreach (var ligne in lignes)
            {
                var tab = ligne.Split('|');
                Dico.Add(tab[0], int.Parse(tab[1]));
            }

            // Set
            if (Dico.ContainsKey(joueur)) Points = Dico[joueur];
        }
        private void SetPoints()
        {
            // File Exists
            if (!System.IO.File.Exists(ScoreFile)) System.IO.File.WriteAllText(ScoreFile, "");

            // Modif ou ajoût
            if (Dico.ContainsKey(Joueur))
                Dico[Joueur] = Points;
            else
                Dico.Add(Joueur, Points);

            // Ecriture
            string s = "";
            foreach(var item in Dico)
            {
                s += item.Key + "|" + item.Value.ToString() + "\n";
            }
            System.IO.File.WriteAllText(ScoreFile, s);
        }

        public int ComparerChoix(Chifoumi choixU, Chifoumi choixM)
        {
            ChoixMachine = choixM.ToString();
            ChoixUtilisateur = choixU.ToString();
            if (choixM == choixU)
            {
                Points = 0;
                Message = "Egalité";
                MessageCouleur = "blue";
                Etat = 0;
            }
            else if (
                choixU == Chifoumi.PIERRE && choixM == Chifoumi.CISEAU ||
                choixU == Chifoumi.FEUILLE && choixM == Chifoumi.PIERRE ||
                choixU == Chifoumi.CISEAU && choixM == Chifoumi.FEUILLE
                )
            {
                Points++;
                Message = "Gagné";
                MessageCouleur = "blue";
                Etat = 1;
            }
            else
            {
                Points--;
                Message = "Perdu";
                MessageCouleur = "blue";
                Etat = -1;
            }
            SetPoints();
            return Points;
        }


        public Chifoumi ChoixMachineExecute()
        {
            var choixInt = Alea.Next(1, 4);
            return (Chifoumi)choixInt;
        }
    }
}
