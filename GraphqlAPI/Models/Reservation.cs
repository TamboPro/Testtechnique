using System.ComponentModel.DataAnnotations;

namespace GraphqlAPI.Models
{
    public class Reservation
    {
       
        public Guid IdReservation { get; set; }
        public string? Numero { get; set; }
        public DateTime DateReservation { get; set; }
        public Guid ClientId { get; set; }
        //public Client? client { get; set; }
        //public ICollection<Ligne>? Lignes { get; } = new List<Ligne>();


    }
}
