using System.ComponentModel.DataAnnotations;

namespace ProduitAPI.Models
{
    public class Reservation
    {
        [Key]
        public Guid IdReservation { get; set; }
        [Required]
        public string? Numero { get; set; }
        [Required]
        public DateTime DateReservation { get; set; }
        public Guid ClientId { get; set; }
        //public Client? client { get; set; }
        public ICollection<Ligne>? Lignes { get; } = new List<Ligne>();


    }
}
