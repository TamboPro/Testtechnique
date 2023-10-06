using System.ComponentModel.DataAnnotations;

namespace GraphqlAPI.Models
{
    public class Hotel
    {
        public Guid IdHotel { get; set; }
        public string? NomHotel { get; set; }
        public string? Pays { get; set; }
        public string? Ville { get; set; }
        public int Classe { get; set; }
    }
}
