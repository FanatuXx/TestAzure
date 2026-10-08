namespace FQ25L062_Blazor.Models.Entities
{
    public class Dino
    {
        public Dino(int id, string espece, int poids, int taille)
        {
            Id = id;
            Espece = espece;
            Poids = poids;
            Taille = taille;
        }

        public int Id { get; }
        public string Espece { get; }
        public int Poids { get; }
        public int Taille { get; }
    }
}
