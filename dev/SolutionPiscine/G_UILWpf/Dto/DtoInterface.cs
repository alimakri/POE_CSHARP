using G_UILWpf.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_UILWpf.Dto
{
    internal static class DtoInterface
    {
        #region Entrant
        internal static List<PiscineViewModel> ToListPiscine(this ArrayList al)
        {
            List<PiscineViewModel> resultat = new List<PiscineViewModel>();
            for (int i = 0; i < al.Count; i += 4)
            {
                resultat.Add(new PiscineViewModel
                {
                    Id = (int)al[i],
                    Nom = (string)al[i + 1],
                    Capacite = (int)al[i + 2],
                    Occupation = (int)al[i + 3]
                });
            }
            return resultat;
        }
        #endregion
    }
}