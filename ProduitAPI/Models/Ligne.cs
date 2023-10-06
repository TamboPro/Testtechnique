using System.ComponentModel.DataAnnotations;

namespace ProduitAPI.Models
{
    public class Ligne
    {
        [Key]
        public Guid IdLigne { get; set; }
        [Required]
        public int  Quantite { get; set; }
        [Required]
        public decimal Prix { get; set; }
        [Required]
        public DateTime DateReservation { get; set; }
        public Guid ProduitId { get; set; }
        //public Produit? Produit { get; set; }
        public Guid ReservationId { get; set; }
        //public Reservation? Reservation { get; set; }

    }
}
