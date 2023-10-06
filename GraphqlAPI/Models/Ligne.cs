using System.ComponentModel.DataAnnotations;

namespace GraphqlAPI.Models
{
    public class Ligne
    {
        public Guid IdLigne { get; set; }
        public int Quantite { get; set; }
        public decimal Prix { get; set; }
        public DateTime DateReservation { get; set; }
        public Guid ProduitId { get; set; }
        //public Produit? Produit { get; set; }
        public Guid ReservationId { get; set; }


    }
}
