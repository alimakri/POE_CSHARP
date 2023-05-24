using Q_Repository.Models;
using System;
using System.Collections.Generic;
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
        }
    }
}