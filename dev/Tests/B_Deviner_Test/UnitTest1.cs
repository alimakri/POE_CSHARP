using M_Deviner_BOL;
using M_Deviner_DAL;
using M_DevinerVersionWindows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Data.SqlClient;

namespace B_Deviner_Test
{
    [TestClass]
    public class TestDal
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
            cmd.CommandText = $"select Count(*) n from sys.sysdatabases where name='JeuBDTest'";
            try
            {
                rd = cmd.ExecuteReader();
                if (rd.Read()) dbExists = (int)rd[0] == 1;
                rd.Close();
            }
            catch (Exception) { }

            if (dbExists)
            {
                cmd.CommandText = $"alter database JeuBDTest set single_user with rollback immediate;DROP DATABASE JeuBDTest";
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
    [TestClass]
    public class TestUil
    {
        [TestMethod]
        public void TropGrand()
        {
            var form = new Form1();
            Metier.MaPartie.LeNombre.Valeur = 50;
            form.TxtPropo.Text = "80";
            form.BtnOk_Click(default, default);
            Assert.IsTrue(form.LblReponse.Text == "Trop grand");
            form.Close();
        }
        [TestMethod]
        public void Perdu()
        {
            var form = new Form1();
            Metier.MaPartie.LeNombre.Valeur = 50;
            form.TxtPropo.Text = "80";
            form.BtnOk_Click(default, default);
            form.TxtPropo.Text = "80";
            form.BtnOk_Click(default, default);
            form.TxtPropo.Text = "80";
            form.BtnOk_Click(default, default);
            form.TxtPropo.Text = "80";
            form.BtnOk_Click(default, default);
            form.TxtPropo.Text = "80";
            form.BtnOk_Click(default, default);
            form.TxtPropo.Text = "80";
            form.BtnOk_Click(default, default);
            form.TxtPropo.Text = "80";
            form.BtnOk_Click(default, default);
            Assert.IsTrue(form.LblReponse.Text == "Perdu");
            form.Close();
        }
        [TestMethod]
        public void Gagne()
        {
            var form = new Form1();
            Metier.MaPartie.LeNombre.Valeur = 50;
            form.TxtPropo.Text = "80";
            form.BtnOk_Click(default, default);
            form.TxtPropo.Text = "80";
            form.BtnOk_Click(default, default);
            form.TxtPropo.Text = "80";
            form.BtnOk_Click(default, default);
            form.TxtPropo.Text = "80";
            form.BtnOk_Click(default, default);
            form.TxtPropo.Text = "80";
            form.BtnOk_Click(default, default);
            form.TxtPropo.Text = "80";
            form.BtnOk_Click(default, default);
            form.TxtPropo.Text = "50";
            form.BtnOk_Click(default, default);
            Assert.IsTrue(form.LblReponse.Text == "Gagné");
            form.Close();
        }
    }
}
