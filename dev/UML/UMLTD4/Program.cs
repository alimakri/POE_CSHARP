using System;
using System.Collections;
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
            //for (int i = 0; i < liste.Count; i++)
            //{
            //    Console.WriteLine(liste[i].Nom);
            //}
            foreach (var p in liste)
            {
                Console.WriteLine(p.Nom);
            }
            Console.ReadLine(); 
        }
    }
    class Personne
    {
        public string Nom;
    }
    class PersonneEnumerator : IEnumerator<Personne>
    {
        private List<Personne> Liste;
        public PersonneEnumerator(List<Personne> liste)
        {
            Liste = liste;
        }
        private int Index = -1;
        public Personne Current
        {
            get { return Liste[Index]; }
        }

        object IEnumerator.Current
        {
            get { return Liste[Index]; }
        }

        public void Dispose() { }

        public bool MoveNext()
        {
            Index++;
            return Index < Liste.Count;
        }

        public void Reset()
        {
            Index = -1;
        }
    }
    class Personnes : IEnumerable<Personne>
    {
        private List<Personne> ListeInterne = new List<Personne>();
        public void Add(Personne p)
        {
            ListeInterne.Add(p);
        }

        public IEnumerator<Personne> GetEnumerator()
        {
            return new PersonneEnumerator(ListeInterne);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new PersonneEnumerator(ListeInterne);
        }


        //public int Count()
        //{
        //    return ListeInterne.Count;
        //}
        public int Count
        {
            get { return ListeInterne.Count; }
        }
        // Indexeur
        public Personne this[int index]
        {
            get
            {
                return ListeInterne[index];
            }
        }
    }
}
