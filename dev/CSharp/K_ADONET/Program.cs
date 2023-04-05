using System;
using System.Data;
using System.Data.SqlClient;

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

            ModeConnecte();
            // ModeDeconnecte();
            //ModeConnecteInsert();
            Console.ReadLine();
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

        private static void ModeConnecteInsert()
        {
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.CommandText = "InsertPersonne";
            Cmd.Parameters.Add(new SqlParameter("prenom", "Brigitte"));
            Cmd.Parameters.Add(new SqlParameter("nom", "Macron"));
            Cmd.Parameters.Add(new SqlParameter("type", "EM"));
            try
            {
                int n = Cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
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

            foreach(DataRow row in ds.Tables[0].Rows)
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
