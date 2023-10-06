using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DossierAPI.Models
{
    public class ReservationView
    {
        
        [Required]
        public string Numero { get; set; }
        [Required]
        public DateTime DateReservationVol { get; set; }
        public Guid IdClient { get; set; }
    }
}
