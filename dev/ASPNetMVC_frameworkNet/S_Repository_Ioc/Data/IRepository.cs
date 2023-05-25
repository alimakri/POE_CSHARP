using S_Repository_Ioc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S_Repository_Ioc.Data
{
    public interface IRepository
    {
        List<Categorie> GetAllCat();
        byte[] GetImage(int idProduit);
        List<SousCategorie> GetSousCats(int id);
        List<Produit> GetProducts(object idSousCat);
    }
}