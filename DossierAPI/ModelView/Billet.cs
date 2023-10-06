using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DossierAPI.Models
{
    public class BilletView
    {
      
        [Required]
        public int  Quantite { get; set; }
        [Required]
        public decimal Prix { get; set; }
        public DateTime DateReservation { get; set; }
        public Guid IdReservation { get; set; }
        public Guid IdVol { get; set; }



    }
}
