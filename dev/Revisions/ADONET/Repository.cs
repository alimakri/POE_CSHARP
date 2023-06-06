using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET
{
    // Réponse ici uniquement
    public class Repository
    {
        private SqlConnection Cnx = null;
        private SqlCommand Cmd = null;
        private bool CnxIsOpen = false;
        public Repository()
        {
            Cnx = new SqlConnection();
            Cnx.ConnectionString = Properties.Settings.Default.AdvCnx;
            try
            {
                Cnx.Open();
                CnxIsOpen = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Cmd = new SqlCommand();
            Cmd.Connection = Cnx;
            Cmd.CommandType = CommandType.Text;
        }
        internal IEnumerable<string> GetCat()
        {
            if (!CnxIsOpen) return null;
            SqlDataReader dr = null;
            Cmd.CommandText = "select Name from Production.ProductCategory";
            try
            {
                dr = Cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            // Transformation du dr en liste de produits
            var cats = new List<string>();
            while (dr.Read())
            {
                cats.Add((string)dr["Name"]);
            }
            dr.Close();
            return cats;
        }

        public IEnumerable<Produit> GetProduits(string nomCategorie)
        {
            if (!CnxIsOpen) return null;

            SqlDataReader dr = null;
            Cmd.CommandText = $@"select 
	                                p.ProductID id, p.Name nom, p.ListPrice prix
                                from 
	                                Production.Product p
	                                inner join Production.ProductSubcategory sc on p.ProductSubcategoryID = sc.ProductSubcategoryID
	                                inner join Production.ProductCategory c on c.ProductCategoryID = sc.ProductCategoryID
                                Where c.Name='{nomCategorie}'
                                order by p.Name";
            try
            {
                dr = Cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            // Transformation du dr en liste de produits
            var produits = new List<Produit>();
            while (dr.Read())
            {
                var id = (int)dr["id"];
                var nom = (string)dr["nom"];
                var prix = (decimal)dr["prix"];
                produits.Add(new Produit { Id = id, Nom = nom, Prix = prix });
            }
            dr.Close();
            return produits;
        }
    }
    public class Produit
    {
        public int Id;
        public string Nom;
        public decimal Prix;
        public override string ToString()
        {
            return $"{Id}\t{Nom}\t{Prix}";
        }
    }
}
