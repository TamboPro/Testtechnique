using System.ComponentModel.DataAnnotations;

namespace DossierAPI.Models
{
    public class VolView
    {
        
        [Required]
        public int Numero { get; set; }
        [Required]
        public string? Reference { get; set;}
        [Required]
        public decimal Prix { get; set; }
        public Guid IdCategorie { get; set; }
        public Guid IdCompagnie { get; set; }
    }
}
