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

            // A faire avec procédure stockée
            Repo.NouvellePersonne(1, "Jean", "Jaurès");
            Repo.NouvellePersonne(2, "Pierre", "Dupont");
            Repo.NouvellePersonne(3, "Emile", "Zola");

            Repo.NouvelleAdresse(1, "Paris");
            Repo.NouvelleAdresse(2, "Reims");

            Repo.Habite(1, 1);
            Repo.Habite(2, 1);
            Repo.Habite(3, 2);

            Repo.QuiHabite(1);
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
            cmd.CommandText = @"use master;
                                CREATE DATABASE [V_ProcStoc_DB] CONTAINMENT = NONE
                                 ON  PRIMARY 
                                ( NAME = N'V_ProcStoc_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\V_ProcStoc_DB.mdf' , SIZE = 8192KB , FILEGROWTH = 65536KB )
                                 LOG ON 
                                ( NAME = N'V_ProcStoc_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\V_ProcStoc_DB_log.ldf' , SIZE = 8192KB , FILEGROWTH = 65536KB );";
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            cmd.CommandText = @"use master;
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
                                ALTER TABLE [dbo].[PersonneVille] CHECK CONSTRAINT [FK_PersonneVille_Ville];";
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        internal void Habite(int v1, int v2)
        {
        }

        internal void NouvelleAdresse(int v1, string v2)
        {
        }

        internal void NouvellePersonne(int v1, string v2, string v3)
        {
        }

        internal void QuiHabite(int v)
        {
        }
    }
}
