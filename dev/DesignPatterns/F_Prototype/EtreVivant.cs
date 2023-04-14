using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_Prototype
{
    public abstract class EtreVivant
    {
        public string Nom { get; set; } = "";
        public abstract EtreVivant Clone(bool deepClone = false);
    }
    public class Personne : EtreVivant
    {
        public Personne(string nom)
        {
            Nom = nom;
        }
        public override EtreVivant Clone(bool deepClone = false)
        {
            return (EtreVivant)MemberwiseClone();
        }
    }
    public class Chien : EtreVivant
    {
        public Personne Proprietaire { get; set; }
        public Chien(string nom, Personne proprio)
        {
            Nom = nom;
            Proprietaire = proprio;
        }
        public override EtreVivant Clone(bool deepClone = false)
        {
            if (deepClone)
            {
                var chien = (Chien)MemberwiseClone();
                chien.Proprietaire = (Personne) Proprietaire.Clone(true);
                return chien;
            }
            return (EtreVivant)MemberwiseClone(); // Le problème est que MemberwiseClone fait une shallow copy
        }
    }
}
