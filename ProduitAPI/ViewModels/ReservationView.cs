using ProduitAPI.Models;

namespace ProduitAPI.ViewModels
{
    public class ReservationView
    {
        public string? Numero { get; set; }
        public DateTime DateReservation { get; set; }
        public Client? IdClient { get; set; }
    }
}
