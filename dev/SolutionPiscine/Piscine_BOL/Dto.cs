﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piscine_BOL
{
    public static class DataTransferObject
    {
        public static ArrayList ToArrayList(this List<Piscine> liste)
        {
            var resultat = new ArrayList();
            liste.ForEach(x => { resultat.Add(x.Id); resultat.Add(x.Nom); resultat.Add(x.Capacite); });
            return resultat;
        }
        public static ArrayList ToArrayList(this List<Acces> liste)
        {
            var resultat = new ArrayList();
            liste.ForEach(x =>
            {
                resultat.Add(x.Id); 
                resultat.Add(x.Nom);
                resultat.Add(x.Piscines.Select(y => y.Id).ToArray());
            });
            return resultat;
        }

    }
}