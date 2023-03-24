using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLTD4
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            var liste = new Personnes();
            liste.Add(new Personne { Nom = "Albert" });
            liste.Add(new Personne { Nom = "Xavier" });
            for (int i = 0; i < liste.Count; i++)
            {
                Console.WriteLine(liste.DonneMoi(i).Nom);
            }
        }
    }
    class Personne
    {
        public string Nom;
    }
    class Personnes
    {
        private List<Personne> ListeInterne = new List<Personne>();
        public void Add(Personne p)
        {
            ListeInterne.Add(p);
        }
        //public int Count()
        //{
        //    return ListeInterne.Count;
        //}
        public int Count
        {
            get { return ListeInterne.Count; }
        }
        public Personne DonneMoi(int index)
        {
            return ListeInterne[index];
        }
    }
}
