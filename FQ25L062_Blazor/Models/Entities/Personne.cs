namespace FQ25L062_Blazor.Models.Entities
{
    public class Personne
    {
        public int Id { get; }
        public string Nom { get; }
        public string Prenom { get; }
        public string Email { get; }
        public string Tel { get; }
        public Personne(int id, string nom, string prenom, string email, string tel)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Tel = tel;
        }
    }
}
