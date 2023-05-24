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
        internal List<Categorie> GetAllCat()
        {
            var cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorks2017;Integrated Security=True";
            cnx.Open();
            var cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select ProductCategoryID, Name from Production.ProductCategory ";
            var rd = cmd.ExecuteReader();
            var liste = new List<Categorie>();
            while (rd.Read())
            {
                liste.Add(new Categorie { Id = (int)rd[0], Name = (string)rd[1] });
            }
            rd.Close();
            return liste;
        }

        internal object GetSousCats(int id)
        {
            var cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorks2017;Integrated Security=True";
            cnx.Open();
            var cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"select ProductSubcategoryID, Name from Production.ProductSubcategory where ProductCategoryID={id} ";
            var rd = cmd.ExecuteReader();
            var liste = new List<SousCategorie>();
            while (rd.Read())
            {
                liste.Add(new SousCategorie { Id = (int)rd[0], Name = (string)rd[1] });
            }
            rd.Close();
            return liste;
        }
    }
}