using System.ComponentModel.DataAnnotations;

namespace DossierAPI.Models
{
    public class CategorieView
    {
        
        public string? TypeCategorie { get; set; }
        public Guid IdVol { get; set; }

    }
}
