using System.ComponentModel.DataAnnotations;

namespace GraphqlAPI.Models
{
    public class Produit
    {
        public Guid IdProduit { get; set; }
        public int Numero { get; set; }
        public string Reference { get; set; }
        public decimal Prix { get; set; }
        public string? TypeProduit { get; set; }
        public Guid Hotelid { get; set; }
        public Guid CategorieId { get; set; }

    }
}
