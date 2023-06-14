using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z4_Dto;


//select st.Name, h.SalesOrderNumber from Sales.SalesOrderHeader h
//inner join Sales.SalesPerson sp on h.SalesPersonID = sp.BusinessEntityID
//inner join Sales.Store st on st.SalesPersonID = sp.BusinessEntityID
//inner join HumanResources.Employee e on e.BusinessEntityID = sp.BusinessEntityID
//inner join Person.Person p on p.BusinessEntityID = e.BusinessEntityID
//where p.BusinessEntityID= 279

namespace Z3_Donnees
{
    internal class Repository
    {
        private string MessageErreur = null;

        internal DataSet2 GetDetails(int idPersonne)
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
            cmd.CommandText = $@"select st.Name Magasin, h.SalesOrderNumber refCommande from Sales.SalesOrderHeader h 
                                inner join Sales.SalesPerson sp on h.SalesPersonID = sp.BusinessEntityID
                                inner join Sales.Store st on st.SalesPersonID = sp.BusinessEntityID
                                inner join HumanResources.Employee e on e.BusinessEntityID = sp.BusinessEntityID
                                inner join Person.Person p on p.BusinessEntityID = e.BusinessEntityID
                                where p.BusinessEntityID={idPersonne}";
            SqlDataReader rd = null;
            try
            {
                rd = cmd.ExecuteReader();
            }
            catch (Exception ex) { MessageErreur = ex.Message; return null; }

            var ds = new DataSet2();
            while (rd.Read())
            {
                var newRow = ds.Tables["Detail"].NewRow();
                newRow["Magasin"] = rd["Magasin"];
                newRow["RefCommande"] = rd["RefCommande"];
                ds.Tables["Detail"].Rows.Add(newRow);
            }
            rd.Close();
            return ds;
        }

        internal DataSet2 GetEmployes()
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
            cmd.CommandText = @"select p.BusinessEntityID id, p.FirstName prenom, p.LastName nom  
                                from HumanResources.Employee e inner join Person.Person p on p.BusinessEntityID = e.BusinessEntityID
                                order by p.BusinessEntityID";
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
