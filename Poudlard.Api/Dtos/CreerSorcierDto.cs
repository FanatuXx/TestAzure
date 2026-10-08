using System.ComponentModel.DataAnnotations;

namespace Poudlard.Api.Dtos
{
    public class CreerSorcierDto
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Nom { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]        
        public string Prenom { get; set; }
        public Guid MaisonId { get; set; }
    }
}
