using Newtonsoft.Json;
using S_Repository_Ioc.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace S_Repository_Ioc.Controllers
{
    public class DataController : ApiController
    {
        private IRepository Repo = null;
        public DataController()
        {
            if (Q_Repository.Properties.Settings.Default.RepoConfig == 1)
                Repo = new FakeRepository();
            else
                Repo = new Repository();
        }
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
