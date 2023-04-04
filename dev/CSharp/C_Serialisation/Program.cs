using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace C_Serialisation
{
    class Program
    {
        static void Main(string[] args)
        {
            //SerialisationXML();
            var liste = DeserialisationXML();
        }

        private static List<Animal> DeserialisationXML()
        {
            var serialiser = new XmlSerializer(typeof(List<Animal>));
            var crayon = new StreamReader(@"d:\mesAnimaux.txt");
            return (List<Animal>) serialiser.Deserialize(crayon);
        }

        private static void SerialisationXML()
        {
            var liste = new List<Animal>
            {
                new Animal{Nom="Chien", Espece="Canidé", EsperanceDeVie=15, DateNaissance=new DateTime(2023, 1,25) },
                new Animal{Nom="Chat", Espece="Félidé", EsperanceDeVie=10, DateNaissance=new DateTime(2023, 2,25) },
                new Animal{Nom="Poisson rouge", Espece="Poisson", EsperanceDeVie=1, DateNaissance=new DateTime(2023, 3,25) },
            };
            var serialiser = new XmlSerializer(typeof(List<Animal>));
            var crayon = new StreamWriter(@"d:\mesAnimaux.txt");
            serialiser.Serialize(crayon, liste);
            crayon.Close();
        }
    }
    public class Animal
    {
        public string Nom;
        public string Espece;
        public int EsperanceDeVie;
        public DateTime DateNaissance;
    }
}
