using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace M_Deviner_BOL
{
    class Partie
    {
        public EtatPartie Etat = EtatPartie.None;
        public Joueur LeJoueur = new Joueur();
        public NombreADeviner LeNombre;
        public int NCoupMax = 0;
        public bool ModeBDD = false;
        public bool Triche = false;
        public List<Joueur> LesJoueurs = new List<Joueur>();
        public string MessageErreur = null;
        public Partie()
        {
            if (ModeBDD)
            {
                LesJoueurs = LireDansBDD();
                if (LesJoueurs == null)
                {
                    MessageErreur="Pas de Sql Server";
                    LesJoueurs = new List<Joueur>();
                }
            }
            else
                LesJoueurs = LireDansFichier("scores.xml");
            LeJoueur.NCoup = 0;
        }


        public IEnumerable<JoueurScore> AfficherMeilleursScores()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Affichage des scores");
            return LesJoueurs.SelectMany(j => j.Scores.Select(s => new JoueurScore { Joueur = j.Nom, Score = s }))
                             .OrderBy(x => x.Score)
                             .Take(5);
        }
        public void Comparer()
        {
            if (LeJoueur.NCoup >= NCoupMax) Etat = EtatPartie.Perdu;
            else if (LeJoueur.Proposition == LeNombre.Valeur) Etat = EtatPartie.Gagne;
            else if (LeJoueur.Proposition < LeNombre.Valeur) Etat = EtatPartie.TropPetit;
            else Etat = EtatPartie.TropGrand;
        }

        public void Enregistrer()
        {
            var j = LesJoueurs.FirstOrDefault(x => x.Nom == LeJoueur.Nom);
            if (j == null)
            {
                j = new Joueur { Nom = LeJoueur.Nom, NCoup = LeJoueur.NCoup };
                j.Scores.Add(LeJoueur.NCoup);
                LesJoueurs.Add(j);
            }
            else
            {
                j.Scores.Add(LeJoueur.NCoup);
            }
            if (ModeBDD)
            {
                if (!EnregistrerDansBDD(j))
                    Console.WriteLine("Enregistrement en BD impossible !");
            }
            else
                EnregistrerDansFichier("scores.xml");
        }

        private bool EnregistrerDansBDD(Joueur j)
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
            cmd.CommandText = $"insert into Score (Joueur, Score) values('{j.Nom}', {j.NCoup})";
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception) { return false; }
            return true;
        }

        private void EnregistrerDansFichier(string fichier)
        {
            var serialiser = new XmlSerializer(typeof(List<Joueur>));
            var stream = new StreamWriter(fichier);
            serialiser.Serialize(stream, LesJoueurs);
            stream.Close();
        }
        private List<Joueur> LireDansBDD()
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
            var liste = new List<Joueur>();
            while (rd.Read())
            {
                var j = liste.FirstOrDefault(x => x.Nom == (string)rd["Joueur"]);
                if (j == null)
                {
                    j = new Joueur { Nom = (string)rd["Joueur"], Scores = new List<int>() };
                    liste.Add(j);
                }
                j.Scores.Add((int)(byte)rd["Score"]);
            }
            rd.Close();
            return liste;
        }
        private List<Joueur> LireDansFichier(string fichier)
        {
            if (File.Exists("scores.xml"))
            {
                var serialiser = new XmlSerializer(typeof(List<Joueur>));
                var stream = new StreamReader(fichier);
                var liste = (List<Joueur>)serialiser.Deserialize(stream);
                stream.Close();
                return liste;
            }
            else
                return new List<Joueur>();
        }

        public bool PasFinie
        {
            get
            {
                return Etat == EtatPartie.None || (Etat != EtatPartie.Gagne && Etat != EtatPartie.Perdu);
            }
        }
    }
    public class Joueur
    {
        public string Nom = null;
        public List<int> Scores = new List<int>();
        public int Proposition = 0;
        public int NCoup = 0;
           }
    class NombreADeviner
    {
        public int Valeur = -1;
        public int Min = -1;
        public int Max = -1;
        public Random Alea = new Random();
        public NombreADeviner(int min, int max)
        {
            Min = min;
            Max = max;
        }
        public void Generer()
        {
            Valeur = Alea.Next(Min, Max + 1);
        }
    }
    enum EtatPartie { None, Gagne, Perdu, TropPetit, TropGrand }
    public class JoueurScore
    {
        public string Joueur;
        public int Score;
    }
}
