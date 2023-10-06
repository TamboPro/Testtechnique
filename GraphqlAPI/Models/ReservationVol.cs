using DossierAPI.Models;

namespace GraphqlAPI.Models
{
    public class ReservationVol
    {
        public Guid IdReservation { get; set; }
        public string Numero { get; set; }

        public DateTime DateReservationVol { get; set; }
        public Guid ClientId { get; set; }
        //public Client client { get; set; } = null!;
        public ICollection<Billet> Billets { get; } = new List<Billet>();
    }
}
