using Microsoft.VisualStudio.TestTools.UnitTesting;
using PiscineBOL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace D_Piscine_Tests
{
    [TestClass]
    public class MetierTests
    {
        [TestMethod]
        public void Acces_Piscines()
        {
            Metier.NouvellePiscine("PisCine 1", 250);
            Metier.NouvellePiscine("Piscine 2", 410);
            Metier.NouvellePiscine("Piscine 3", 210);
            Metier.NouvelAcces("Bus 45", new int[] { 1, 2 });

            var listeObtenu = Metier.TestAcces1("Bus 45");
            var s = string.Join(",", listeObtenu).ToUpper();
            Assert.IsTrue(s == "PISCINE 1,PISCINE 2" || s == "PISCINE 2,PISCINE 1");
        }
    }
    [TestClass]
    public class DonneesTests
    {
        [TestMethod]
        public void CreateDatabase()
        {
            DropDatabase("PiscineDBTest");
            Metier.NouvellePiscine("PisCine 1", 250);
            Metier.Enregistrer();
            Assert.IsTrue(CheckDatabase());
            DropDatabase("PiscineDBTest");
        }

        private bool CheckDatabase()
        {
            var cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=PiscineDBTest;Integrated Security=True";
            try
            {
                cnx.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void DropDatabase(string nom)
        {
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
            SqlDataReader rd = null;
            var cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"select Count(*) n from sys.sysdatabases where name='PiscineDBTest'";
            try
            {
                rd = cmd.ExecuteReader();
                if (rd.Read() && (int)rd[0] == 1)
                {
                    rd.Close();
                    cmd.CommandText = $"alter database PiscineDBTest set single_user with rollback immediate;DROP DATABASE PiscineDBTest";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception) { Assert.Fail("Erreur"); }
        }
    }
}
