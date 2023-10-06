using System.ComponentModel.DataAnnotations;

namespace ProduitAPI.Models
{
    public class Hotel
    {
        [Key]
        public Guid IdHotel { get; set; }
        [Required]
        public string? NomHotel { get; set; }
        [Required]
        public string? Pays { get; set; }
        [Required]
        public string? Ville { get; set; }
        [Required]
        public int Classe { get; set; }
        public ICollection<Produit>? produits { get; } = new List<Produit>();

    }
}
