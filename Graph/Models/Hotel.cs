using System.ComponentModel.DataAnnotations;

namespace Graph.Models
{
    public class Hotel
    {
        [Key]
        public Guid IdHotel { get; set; }
        public string? NomHotel { get; set; }
        public string? Pays { get; set; }
        public string? Ville { get; set; }
        public int Classe { get; set; }
        public ICollection<Produit>? produits {get;}
    }
}
