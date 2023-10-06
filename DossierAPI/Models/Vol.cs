using System.ComponentModel.DataAnnotations;

namespace DossierAPI.Models
{
    public class Vol
    {
        [Key]
        public Guid IdVol { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public string Reference { get; set;}
        [Required]
        public decimal Prix { get; set; }

        public Guid CompanieId { get; set; }
        //public Compagnie Compagnie { get; set; } = null!;

        //public Guid CategorieId { get; set; }
        //public Categorie Categorie { get; set; } = null!;
        //public ICollection<Billet> Billets { get; } = new List<Billet>();
    }
}


/*
 
{
  "idVol": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "numero": 1234,
  "reference": "TUI125",
  "prix": 400,
  "companieId": "076c2f7a-29c1-41e8-acbe-036b82169968",
  "compagnie": {
    "idCompagnie": "076c2f7a-29c1-41e8-acbe-036b82169968",
    "nomCompagnie": "Tuifly",
    "pays": "Belgique",
    "ville": "Brussels"
  },
  "categorieId": "261628c3-802b-494f-bd25-ab268dd062fd",
  "categorie": {
    "idCategorie": "261628c3-802b-494f-bd25-ab268dd062fd",
    "typeCategorie": "International"
  }
}
 
 */