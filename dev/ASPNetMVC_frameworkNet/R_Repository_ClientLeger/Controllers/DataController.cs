using Newtonsoft.Json;
using Q_Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Q_Repository.Controllers
{
    public class DataController : ApiController
    {
        private Repository Repo = new Repository();
        public string GetSousCat(int id)
        {
            var sousCats = Repo.GetSousCats(id);
            return JsonConvert.SerializeObject(sousCats);
        }
        public string GetProduct(int souscat)
        {
            var products = Repo.GetProducts(souscat);
            return JsonConvert.SerializeObject(products);
        }
        public byte[] GetImage(int idProduit)
        {
            return Repo.GetImage(idProduit);
        }
    }
}
