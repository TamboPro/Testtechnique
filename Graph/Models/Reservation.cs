using System.ComponentModel.DataAnnotations;

namespace Graph.Models
{
    public class Reservation
    {
        [Key]
        public Guid IdReservation { get; set; }
        public string? Numero { get; set; }
        public DateTime DateReservation { get; set; }
        public Client? client { get; set; }
        public ICollection<Ligne>? Lignes { get; set; }
    }
}
