using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace K_ADONET
{
    internal class Program
    {
        private static SqlCommand Cmd;
        static void Main(string[] args)
        {
            var cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorks2017;Integrated Security=True";
            cnx.Open();

            Cmd = new SqlCommand();
            Cmd.Connection = cnx;
            Cmd.CommandType = CommandType.Text;

            //ModeConnecte();
            // ModeDeconnecte();
            //ModeConnecteInsert("Marceau","Sophie","EM");

            ModeDeconnecteInsert("Henri", "Thierry", "EM");
            Console.ReadLine();
        }

        private static void ModeDeconnecteInsert(string nom, string prenom, string type)
        {
            // 1. Récupération de la première table
            Cmd.CommandText = "select BusinessEntityId, FirstName, LastName, PersonType, rowguid, ModifiedDate from Person.Person";
            var da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            var ds = new DataSet();
            da.Fill(ds, "Person.Person");
            da.TableMappings.Add("Person", "Person.Person");

            // 2. Récupération de la seconde table
            Cmd.CommandText = "select BusinessEntityID, rowguid, ModifiedDate from Person.BusinessEntity";
            da.Fill(ds, "Person.BusinessEntity");
            da.TableMappings.Add("BusinessEntity", "Person.BusinessEntity");

            // 3. Insertion dans la table Person.BusinessEntity (dans le dataset)
            var table2 = ds.Tables["Person.BusinessEntity"];

            var newRow = table2.NewRow();
            var id = (int)table2.AsEnumerable().Max(x => x["BusinessEntityID"]) + 1;
            newRow["BusinessEntityID"] = id;
            newRow["rowguid"] = Guid.NewGuid();
            newRow["ModifiedDate"] = DateTime.Now;
            table2.Rows.Add(newRow);

            // 4. Insertion dans la table Person.Person (dans le dataset)
            var table1 = ds.Tables["Person.Person"];
            var newRow2 = table1.NewRow();
            newRow2["BusinessEntityID"] = id;
            newRow2["FirstName"] = prenom;
            newRow2["LastName"] = nom;
            newRow2["PersonType"] = type;
            newRow2["rowguid"] = Guid.NewGuid();
            newRow2["ModifiedDate"] = DateTime.Now;
            table1.Rows.Add(newRow2);

            // SqlCommandBuilder
            var cb = new SqlCommandBuilder(da);
            var changes= ds.GetChanges();
            da.Update(ds, "Person.BusinessEntity");
            da.Update(ds, "Person.Person");
        }

        //private static int NewBusinessEntityId()
        //{
        //    Cmd.CommandText = "select Max(BusinessEntityId) n from Person.Person ";
        //    SqlDataReader rd = Cmd.ExecuteReader(); int n = 0;
        //    if (rd.Read())
        //    {
        //        n= rd.GetInt32(0);
        //    }
        //    rd.Close();
        //    return n + 1;
        //}

        private static void ModeConnecteInsert(string nom, string prenom, string typePersonne)
        {
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.CommandText = "InsertPersonne";
            Cmd.Parameters.Add(new SqlParameter("prenom", prenom));
            Cmd.Parameters.Add(new SqlParameter("nom", nom));
            Cmd.Parameters.Add(new SqlParameter("type", typePersonne));
            try
            {
                int n = Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        private static void ModeDeconnecte()
        {
            Cmd.CommandText = "select BusinessEntityId, FirstName, LastName from Person.Person";
            var da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            var ds = new DataSet();
            da.Fill(ds);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Console.WriteLine("{0}: {1} - {2}", row["BusinessEntityId"], row["FirstName"], row["LastName"]);
            }
        }

        private static void ModeConnecte()
        {
            Cmd.CommandText = "select BusinessEntityId, FirstName, LastName from Person.Person order by BusinessEntityId";
            SqlDataReader rd = Cmd.ExecuteReader();
            while (rd.Read())
            {
                Console.WriteLine("{0}: {1} - {2}", rd["BusinessEntityId"], rd["FirstName"], rd["LastName"]);
            }
            rd.Close();
        }
    }
}
