using S_Repository_Ioc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S_Repository_Ioc.Data
{
    public class FakeRepository : IRepository
    {
        public List<Categorie> GetAllCat()
        {
            return new List<Categorie> {
            new Categorie{Id=1, Name="Ordinateur" } ,
            new Categorie{Id=2, Name="Cable" } ,
            };
        }

        public byte[] GetImage(int idProduit)
        {
            return null;
        }

        public List<Produit> GetProducts(object idSousCat)
        {
            return new List<Produit> {
            new Produit{Id=1, Name="Dell Precision", Reference="M4800" } ,
            new Produit{Id=2, Name="HP Pavillon", Reference="HP404" }
            };
        }

        public List<SousCategorie> GetSousCats(int id)
        {
            return new List<SousCategorie> {
            new SousCategorie{Id=1, Name="Portable" } ,
            new SousCategorie{Id=2, Name="Bureau" } 
            };
        }
    }
}