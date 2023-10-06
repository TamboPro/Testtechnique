using System.ComponentModel.DataAnnotations;

namespace DossierAPI.Models
{
    public class Client
    {
        [Key]
        public Guid IdClient { get; set; }
        //public ICollection<Reservation> reservations { get; } = new List<Reservation>();
    }
}
