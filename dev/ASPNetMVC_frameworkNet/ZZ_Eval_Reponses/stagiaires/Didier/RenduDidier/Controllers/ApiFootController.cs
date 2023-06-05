using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ZZ_Eval.Controllers
{
    public class ApiFootController : ApiController
    {
        // FAIRE APPEL AU WEB API = AJAX
        public string Put(string equipe)
        {
            if (equipe.ToUpper() == "AMSTERDAM")
                return JsonConvert.SerializeObject(new
                {
                    Nom = "Amsterdamsche Football Club Ajax",
                    Pays = "Pays-Bas",
                    AnneeFondation = "1900",
                    President = "Frank Eijken",
                    Entraineur = "Johnny HEITINGA",
                });
            return null;
        }
    }
}
