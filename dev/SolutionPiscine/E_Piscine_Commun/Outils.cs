using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piscine_Commun
{
    public enum FormatDateEnum
    {
        yyyyMMdd, dd_MM_yyyy, dd_MM_yyyy_HH_mm
    }
    public static class Outils
    {
        /// <summary>
        /// ConvertToDateTime permet de convertir un string en Datetime selon un format fourni
        /// </summary>
        /// <param name="format">voir FormatDateEnum</param>
        /// <param name="valeur">la chaîne de caractères à convertir</param>
        /// <returns></returns>
        public static DateTime ConvertToDateTime(FormatDateEnum format, string dateString)
        {
            switch (format)
            {
                case FormatDateEnum.yyyyMMdd: return DateTime.ParseExact(dateString, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                case FormatDateEnum.dd_MM_yyyy: return DateTime.ParseExact(dateString, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                case FormatDateEnum.dd_MM_yyyy_HH_mm: return DateTime.ParseExact(dateString, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            }
            return default;
        }
    }
}
