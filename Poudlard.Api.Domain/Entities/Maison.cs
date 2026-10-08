namespace Poudlard.Api.Domain.Entities
{
    public class Maison
    {
        internal Maison(Guid id, string nom, string fondateur, string couleur, string embleme)
        {
            Id = id;
            Nom = nom;
            Fondateur = fondateur;
            Couleur = couleur;
            Embleme = embleme;
        }

        public Guid Id { get; }
        public string Nom { get; }
        public string Fondateur { get; }
        public string Couleur { get; }
        public string Embleme { get; }
    }
}
