using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DossierAPI.Models
{
    public class Billet
    {
        [Key]
        public Guid IdBillet { get; set; }
        [Required]
        public int  Quantite { get; set; }
        [Required]
        public decimal Prix { get; set; }
        public DateTime DateReservation { get; set; }

        public Guid VolId { get; set; }
        //public Vol Vol { get; set; } = null!;

        public Guid ReservationId { get; set; }
        //public Reservation Reservation { get; set; } = null!;
        
        
        

    }
}


/*
 
  "idBillet": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "quantite": 1,
  "prix": 400,
  "dateReservation": "2023-10-05T20:33:50.792Z",
  "volId": "4a1212ef-1d3c-4e75-97f9-c5ea0b16b063",
  "reservationId": "8cea3465-58ac-4501-8917-b9b7b414ca16"


 * {
  "idBillet": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "quantite": 1,
  "prix": 400,
  "dateReservation": "2023-10-05T20:33:50.792Z",
  "volId": "4a1212ef-1d3c-4e75-97f9-c5ea0b16b063",
  "vol": {
    "idVol": "4a1212ef-1d3c-4e75-97f9-c5ea0b16b063",
    "numero": 1234,
    "reference": "TUI125",
    "prix": 400,
    "companieId": "076c2f7a-29c1-41e8-acbe-036b82169968"
  },
  "reservationId": "8cea3465-58ac-4501-8917-b9b7b414ca16",
  "reservation": {
    "idReservation": "8cea3465-58ac-4501-8917-b9b7b414ca16",
    "numero": "1234",
    "dateReservationVol": "2023-10-05T20:33:05.176",
    "clientId": "800e8c07-cbab-4e73-9535-9c0df16fdde0"
  }
}
*/