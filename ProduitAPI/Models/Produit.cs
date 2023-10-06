using System.ComponentModel.DataAnnotations;

namespace ProduitAPI.Models
{
    public class Produit
    {
        [Key]
        public Guid IdProduit { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public string Reference { get; set; }
        [Required]
        public decimal Prix { get; set; }
        public string? TypeProduit { get; set; }
        public Guid Hotelid { get; set; }
        //public Hotel? Hotel { get; set; }
        public Guid CategorieId { get; set; }
        //public Categorie? Categorie { get; set; }
        //public ICollection<Ligne>? Lignes { get; }

        
    }
}
