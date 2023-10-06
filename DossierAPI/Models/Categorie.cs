using System.ComponentModel.DataAnnotations;

namespace DossierAPI.Models
{
    public class Categorie
    {
        [Key]
        public Guid IdCategorie { get; set; }
        public string? TypeCategorie { get; set; }
        //public List<Vol> Vols { get; } = new List<Vol>();

    }
}
