using System.ComponentModel.DataAnnotations;

namespace Graph.Models
{
    public class Produit
    {
            [Key]
            public Guid IdProduit { get; set; }
            public int Numero { get; set; }
            public string? Reference { get; set; }
            public string? TypeProduit { get; set; }
            public decimal Prix { get; set; }
            public Hotel? Hotel { get; set; }
            public Categorie? Categorie { get; set; }
            public ICollection<Ligne>? Lignes { get; set; }
        
    }
}
