using System.ComponentModel.DataAnnotations;

namespace ProduitAPI.Models
{
    public class Client
    {
        [Key]
        public Guid IdClient { get; set; }
        //public ICollection<Reservation> reservations { get; } = new List<Reservation>();
    }
}
