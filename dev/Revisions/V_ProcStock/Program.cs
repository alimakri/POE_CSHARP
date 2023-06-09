using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V_ProcStock
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository Repo = new Repository();

            // A faire en SQL
            Repo.ConstruireBD();
            Console.WriteLine("Base de données construite");

            // A faire avec procédure stockée
            Repo.NouvellePersonne(1, "Jean", "Jaurès");
            Repo.NouvellePersonne(2, "Pierre", "Dupont");
            Repo.NouvellePersonne(3, "Emile", "Zola");
            Console.WriteLine("3 personnes enregistrées");

            Repo.NouvelleVille(1, "Paris");
            Repo.NouvelleVille(2, "Reims");
            Console.WriteLine("2 adresses enregistrées");

            Repo.Habite(1, 1);
            Repo.Habite(2, 1);
            Repo.Habite(3, 2);
            Console.WriteLine("3 affectations enregistrées");

            Repo.QuiHabite(1);
            Console.ReadLine();
        }
    }
    class Repository
    {
        internal void ConstruireBD()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=master; Integrated Security=true";
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            ExecuteCmd(cmd, @"use master;
                                CREATE DATABASE [V_ProcStoc_DB] CONTAINMENT = NONE
                                 ON  PRIMARY 
                                ( NAME = N'V_ProcStoc_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\V_ProcStoc_DB.mdf' , SIZE = 8192KB , FILEGROWTH = 65536KB )
                                 LOG ON 
                                ( NAME = N'V_ProcStoc_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\V_ProcStoc_DB_log.ldf' , SIZE = 8192KB , FILEGROWTH = 65536KB );");

            ExecuteCmd(cmd, @"use master;
                                use [V_ProcStoc_DB];
                                CREATE TABLE [dbo].[Personne](
	                                [Id] [int] IDENTITY(1,1) NOT NULL,
	                                [Nom] [nvarchar](max) NOT NULL,
	                                [Prenom] [nvarchar](max) NOT NULL,
	                                CONSTRAINT [PK_Personne] PRIMARY KEY CLUSTERED([Id] ASC)
                                );
                                CREATE TABLE [dbo].Ville(
	                                [Id] [int] IDENTITY(1,1) NOT NULL,
	                                [Nom] [nvarchar](max) NOT NULL,
	                                CONSTRAINT [PK_Ville] PRIMARY KEY CLUSTERED([Id] ASC)
                                );
                                CREATE TABLE [dbo].[PersonneVille](
	                                [Personne] [int] NOT NULL,
	                                [Ville] [int] NOT NULL
                                ) ON [PRIMARY];
                                ALTER TABLE [dbo].[PersonneVille]  WITH CHECK ADD  CONSTRAINT [FK_PersonneVille_Personne] FOREIGN KEY([Personne]) REFERENCES [dbo].[Personne] ([Id]);
                                ALTER TABLE [dbo].[PersonneVille] CHECK CONSTRAINT [FK_PersonneVille_Personne];

                                ALTER TABLE [dbo].[PersonneVille]  WITH CHECK ADD  CONSTRAINT [FK_PersonneVille_Ville] FOREIGN KEY([Ville]) REFERENCES [dbo].[Ville] ([Id]);
                                ALTER TABLE [dbo].[PersonneVille] CHECK CONSTRAINT [FK_PersonneVille_Ville];");

            ExecuteCmd(cmd, @"CREATE PROC [dbo].[New_Personne](@id int, @prenom nvarchar(MAX), @nom nvarchar(MAX))
                                AS
                                SET IDENTITY_INSERT Personne ON
                                insert Personne (id, nom, Prenom) values(@id, @nom, @prenom)
                                SET IDENTITY_INSERT Personne OFF");
            ExecuteCmd(cmd, @"CREATE PROC [dbo].[New_Ville](@id int, @nom nvarchar(MAX))
                                AS
                                SET IDENTITY_INSERT Ville ON
                                insert Ville (id, nom) values(@id, @nom)
                                SET IDENTITY_INSERT Ville OFF");
            ExecuteCmd(cmd, @"CREATE PROC [dbo].[Habite](@personne int, @ville int)
                                AS
                                insert PersonneVille (personne, ville) values(@personne, @ville)");

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ExecuteCmd(SqlCommand cmd, string requete)
        {
            cmd.CommandText = requete;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        internal void Habite(int personne, int ville)
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=V_ProcStoc_DB; Integrated Security=true";
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Habite";
            cmd.Parameters.Add(new SqlParameter("personne", personne));
            cmd.Parameters.Add(new SqlParameter("ville", ville));
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        internal void NouvelleVille(int id, string nom)
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=V_ProcStoc_DB; Integrated Security=true";
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "New_Ville";
            cmd.Parameters.Add(new SqlParameter("id", id));
            cmd.Parameters.Add(new SqlParameter("nom", nom));
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        internal void NouvellePersonne(int id, string prenom, string nom)
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=V_ProcStoc_DB; Integrated Security=true";
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "New_Personne";
            cmd.Parameters.Add(new SqlParameter("id", id));
            cmd.Parameters.Add(new SqlParameter("prenom", prenom));
            cmd.Parameters.Add(new SqlParameter("nom", nom));
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        internal void QuiHabite(int v)
        {
        }
    }
}
