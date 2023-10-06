using System.ComponentModel.DataAnnotations;

namespace Graph.Models
{
    public class Ligne
    {
        [Key]
        public Guid IdLigne { get; set; }
        public int  Quantite { get; set; }
        public decimal Prix { get; set; }
        public Produit? Produit { get; set; }
        public Reservation? Reservation { get; set; }
        

    }
}
