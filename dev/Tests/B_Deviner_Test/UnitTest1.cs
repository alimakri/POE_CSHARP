using M_Deviner_DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Data.SqlClient;

namespace B_Deviner_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LireDansBDD_AvecNoDB()
        {
            // Check SQL Server
            var cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
            try
            {
                cnx.Open();
            }
            catch (Exception)
            {
                Assert.Fail("SQL Server non installé ou non fonctionnel");
                return;
            }

            // Check BD 
            var dbExists = false; SqlDataReader rd = null;
            var cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"select Joueur, Score from JeuBDTest.dbo.Score order by Joueur";
            try
            {
                rd = cmd.ExecuteReader();
                rd.Close();
                dbExists = true;
            }
            catch (Exception) { }

            if (dbExists)
            {
                cmd.CommandText = $"DROP DATABASE JeuBDTest";
                cmd.ExecuteNonQuery();
            }
            Donnees.LireDansBDD("JeuBdTest");
            dbExists = false;
            cmd.CommandText = $"select Joueur, Score from JeuBDTest.dbo.Score";
            try
            {
                rd = cmd.ExecuteReader();
                dbExists = true;
                rd.Close();
            }
            catch (Exception) { }
            Assert.IsTrue(dbExists);
            cmd.CommandText = $"alter database JeuBDTest set single_user with rollback immediate;DROP DATABASE JeuBDTest";
            cmd.ExecuteNonQuery();
        }
    }
}
