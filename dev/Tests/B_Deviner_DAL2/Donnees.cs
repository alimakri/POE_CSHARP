using System.Collections;
using System.IO;
using System.Xml.Serialization;

namespace M_Deviner_DAL2
{
    public static class Donnees
    {

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
