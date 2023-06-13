using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z4_Dto;

namespace Z3_Donnees
{
    internal class Repository
    {
        private string MessageErreur = null;
        internal DataSet2 GetPersonnes()
        {
            var cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorks2017;Integrated Security=true";
            try
            {
                cnx.Open();
            }
            catch (Exception ex) { MessageErreur = ex.Message; return null; }
            var cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select top 100 BusinessEntityId Id, FirstName prenom, LastName nom from Person.Person order by BusinessEntityId";
            SqlDataReader rd = null;
            try
            {
                rd = cmd.ExecuteReader();
            }
            catch (Exception ex) { MessageErreur = ex.Message; return null; }

            var ds = new DataSet2();
            while (rd.Read())
            {
                var newRow = ds.Tables[0].NewRow();
                newRow["Id"] = rd["Id"];
                newRow["Nom"] = rd["Nom"];
                newRow["Prenom"] = rd["Prenom"];
                ds.Tables[0].Rows.Add(newRow);
            }
            rd.Close();
            return ds;
        }
    }
}
