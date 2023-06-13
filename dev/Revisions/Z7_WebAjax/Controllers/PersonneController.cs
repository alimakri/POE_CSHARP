using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Z2_Metier;

namespace Z7_WebAjax.Controllers
{
    public class PersonneController : ApiController
    {
        public string Get()
        {
            var data = Personnes.Get("5");
            if (data == null) return null;
            return JsonConvert.SerializeObject(data.Tables[0].AsEnumerable().Select(x => new
            {
                Id = (int)x["Id"],
                NomComplet = (string)x["NomComplet"]
            }));
        }
    }

}
