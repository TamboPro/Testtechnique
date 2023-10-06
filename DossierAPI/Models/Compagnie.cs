using System.ComponentModel.DataAnnotations;

namespace DossierAPI.Models
{
    public class Compagnie
    {
        [Key]
        public Guid IdCompagnie { get; set; }
        public string? NomCompagnie { get; set; }
        public string? Pays { get; set; }
        public string? Ville { get; set; }
        public List<Vol> Vols { get; } = new List<Vol>();
    }
}
