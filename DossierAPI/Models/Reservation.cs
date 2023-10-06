using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DossierAPI.Models
{
    public class Reservation
    {
        [Key]
        public Guid IdReservation { get; set; }
        [Required]
        public string Numero { get; set; }
       
        public DateTime DateReservationVol { get; set; }
        public Guid ClientId { get; set; }
        //public Client client { get; set; } = null!;
        public ICollection<Billet> Billets { get; } = new List<Billet>();
    }
}
