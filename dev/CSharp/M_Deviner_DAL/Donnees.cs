using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace M_Deviner_DAL
{
    public static class Donnees
    {
        public static ArrayList LireDansBDD()
        {
            // Check SQL Server
            var cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
            try
            {
                cnx.Open();
            }
            catch (Exception) { return null; }

            // Check BD JeuBD
            var dbExists = false; SqlDataReader rd = null;
            var cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Joueur, Score from JeuBD.dbo.Score order by Joueur";
            try
            {
                rd = cmd.ExecuteReader();
                dbExists = true;
            }
            catch (Exception) { }

            // Create database 
            if (!dbExists)
            {
                cmd.CommandText = @"
                            CREATE DATABASE [JeuBD]  ON  PRIMARY 
                            ( 
	                            NAME = N'JeuBD', 
	                            FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\JeuBD.mdf' , 
                                SIZE = 8192KB , FILEGROWTH = 65536KB 
                            )
                            LOG ON 
                            ( 
	                            NAME = N'JeuBD_log', 
	                            FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\JeuBD_log.ldf' , 
                                SIZE = 8192KB , FILEGROWTH = 65536KB 
                            );";
                try
                {
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"USE [JeuBD];
                            CREATE TABLE Score
                            (
	                            [Id] [bigint] IDENTITY(1,1) NOT NULL,
	                            [Joueur] [nvarchar](50) NOT NULL,
	                            [Score] [tinyint] NOT NULL,
	                            CONSTRAINT [PK_Score] PRIMARY KEY CLUSTERED ([Id] ASC)
                            );
                            select Joueur, Score from JeuBD.dbo.Score order by Joueur";
                    rd = cmd.ExecuteReader();
                }
                catch (Exception) { return null; }
            }

            // Construire la liste
            //var liste = new List<Joueur>();
            var liste = new ArrayList();
            while (rd.Read())
            {
                //var j = liste.FirstOrDefault(x => x.Nom == (string)rd["Joueur"]);
                string j = null; int i = 0;
                for(i =0; i < liste.Count; i += 2)
                {
                    if ((string)liste[i] == (string)rd["Joueur"])
                    {
                        j = (string)liste[i];
                        break;
                    }
                }
                if (j == null)
                {
                    //j = new Joueur { Nom = (string)rd["Joueur"], Scores = new List<int>() };
                    //liste.Add(j);
                    liste.Add((string)rd["Joueur"]);
                    liste.Add(new List<int>());
                }
                ((List<int>)liste[i+1]).Add((int)(byte)rd["Score"]);
            }
            rd.Close();
            return liste;
        }

        public static bool EnregistrerDansBDD(string nom, int nCoup)
        {
            var cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=jeuBD;Integrated Security=True";
            try
            {
                cnx.Open();
            }
            catch (Exception) { return false; }

            var cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"insert into Score (Joueur, Score) values('{nom}', {nCoup})";
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception) { return false; }
            return true;
        }

        public static void EnregistrerDansFichier(ArrayList lesJoueurs, string fichier)
        {
            var serialiser = new XmlSerializer(typeof(ArrayList));
            var stream = new StreamWriter(fichier);
            serialiser.Serialize(stream, lesJoueurs);
            stream.Close();
        }
        public static ArrayList LireDansFichier(string fichier)
        {
            if (File.Exists("scores.xml"))
            {
                var serialiser = new XmlSerializer(typeof(ArrayList));
                var stream = new StreamReader(fichier);
                var liste = (ArrayList)serialiser.Deserialize(stream);
                stream.Close();
                return liste;
            }
            else
                return new ArrayList();
        }
    }
}
