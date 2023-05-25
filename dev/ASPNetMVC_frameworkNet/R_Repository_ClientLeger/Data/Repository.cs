using Q_Repository.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Q_Repository.Data
{
    public class Repository
    {
        private SqlCommand Cmd = new SqlCommand();
        public Repository()
        {
            var cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorks2017;Integrated Security=True";
            cnx.Open();
            Cmd.Connection = cnx;
            Cmd.CommandType = CommandType.Text;
        }

        internal List<Categorie> GetAllCat()
        {
            Cmd.CommandText = "select ProductCategoryID, Name from Production.ProductCategory";
            var rd = Cmd.ExecuteReader();
            var liste = new List<Categorie>();
            while (rd.Read())
            {
                liste.Add(new Categorie { Id = (int)rd[0], Name = (string)rd[1] });
            }
            rd.Close();
            return liste;
        }

        internal byte[] GetImage(int idProduit)
        {
            Cmd.CommandText = $@"select LargePhoto
                                from Production.ProductProductPhoto ppp
                                inner join Production.ProductPhoto pp on ppp.ProductPhotoID = pp.ProductPhotoID
                                where ppp.ProductID={idProduit}";
            var rd = Cmd.ExecuteReader();
            var liste = new List<SousCategorie>();
            while (rd.Read())
            {
                liste.Add(new SousCategorie { Id = (int)rd[0], Name = (string)rd[1] });
            }
            rd.Close();
            return liste;
        }

        internal object GetSousCats(int id)
        {
            Cmd.CommandText = $"select ProductSubcategoryID, Name from Production.ProductSubcategory where ProductCategoryID={id} ";
            var rd = Cmd.ExecuteReader();
            var liste = new List<SousCategorie>();
            while (rd.Read())
            {
                liste.Add(new SousCategorie { Id = (int)rd[0], Name = (string)rd[1] });
            }
            rd.Close();
            return liste;
        }
        internal object GetProducts(object idSousCat)
        {
            Cmd.CommandText = $@"select p.ProductID, p.Name, p.ProductNumber, p.ListPrice, pp.LargePhoto
                                from Production.Product p
                                inner
                                join Production.ProductProductPhoto ppp on ppp.ProductID = p.ProductID
                                inner
                                join Production.ProductPhoto pp on ppp.ProductPhotoID = pp.ProductPhotoID
                                where ProductsubCategoryID = {idSousCat}";
            //Cmd.CommandText = $"select ProductID, Name, ProductNumber, ListPrice from Production.Product where ProductsubCategoryID={idSousCat}";
            var rd = Cmd.ExecuteReader();
            var liste = new List<Produit>();
            while (rd.Read())
            {
                liste.Add(new Produit
                {
                    Id = (int)rd[0],
                    Name = (string)rd[1],
                    Reference = (string)rd[2],
                    ListPrice = (decimal)rd[3]
                    //Image = (byte[])rd[4] // Retirer car client léger
                });
            }
            rd.Close();
            return liste;
        }

    }
}