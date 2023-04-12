using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_CodeFirst1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new HabitantContext();
            //var p1 = context.Personnes.FirstOrDefault();

            //insert Personne(Nom) values('Albert')
            //insert Personne(Nom) values('Béatrice')
            //insert Ville(Nom) values('Bordeaux')
            //insert Ville(Nom) values('Agen')
            //insert PersonneVille(Personne, Ville) values(1, 1)
            //insert PersonneVille(Personne, Ville) values(1, 2)
            //insert PersonneVille(Personne, Ville) values(2, 2)

            var albert = new Personne { Cle = Guid.NewGuid(), Prenom = "Albert", Nom = "Dupontel" };
            var beatrice = new Personne { Cle = Guid.NewGuid(), Prenom = "Béatrice", Nom = "Dalle" };
            context.Personnes.Add(albert);
            context.Personnes.Add(beatrice);
            context.Villes.Add(
                new Ville
                {
                    Id = Guid.NewGuid(),
                    Nom = "Bordeaux",
                    Personnes = new List<Personne> { albert }
                });
            context.Villes.Add(
                new Ville
                {
                    Id = Guid.NewGuid(),
                    Nom = "Agen",
                    Personnes = new List<Personne> { albert, beatrice }
                });
            context.SaveChanges();

            Console.WriteLine("Ok");
            Console.ReadLine();

            // Insert personne
        }
    }
}
