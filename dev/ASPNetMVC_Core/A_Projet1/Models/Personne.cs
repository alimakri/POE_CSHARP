namespace A_ProjetComplet.Models
{
    public class Personne
    {
        public int Id;
        public string Nom;
        public string Ville;

        internal static Personne GetOne()
        {
            // Etape 3
            return new Personne { Id = 1, Nom = "Leroy", Ville = "Paris" };

        }
    }
}
