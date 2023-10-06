using System.ComponentModel.DataAnnotations;

namespace DossierAPI.Models
{
    public class CompagnieView
    {
        
        public string? NomCompagnie { get; set; }
        public string? Pays { get; set; }
        public string? Ville { get; set; }
    }
}
