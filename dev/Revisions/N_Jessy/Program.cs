using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Jessy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var g = new GrosseClasse())
            {
                g.Display();
            }
            var i = 1; // g doit être libéré ici
            GC.SuppressFinalize(i);

            // https://stacktraceback.com/difference-entre-dispose-et-finalize-en-c/#Finalize
        }
    }
    class GrosseClasse :IDisposable
    {
        private SqlConnection Cnx = new SqlConnection(); // Ressource de connexion de base de données 
        private FileStream Flux = null;
        public GrosseClasse()
        {
            Cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorks2017;Integrated Security=true";
            Cnx.Open();
            string data;
            Flux = new FileStream("D:\\csharpfile.txt", FileMode.OpenOrCreate, FileAccess.Read);
            using (StreamReader sr = new StreamReader(Flux))
            {
                data = sr.ReadToEnd();
            }
            Console.WriteLine(data);
        }
        public void Dispose()
        {
            Cnx.Close();
            Flux.Close();
        }
         ~GrosseClasse() { var i = 0; }

        //public void Finalize()
        //{
        //    Cnx.Close();
        //    Flux.Close();
        //}
        internal void Display()
        {
            Console.WriteLine("La grosse classe !");
        }
    }
}
