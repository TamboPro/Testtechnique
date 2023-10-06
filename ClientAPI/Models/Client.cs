using System.ComponentModel.DataAnnotations;

namespace ClientAPI.Models
{
    public class Client
    {
        [Key]
        public Guid IdClient { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Adresse { get; set; }
        public string Email { get; set; }
    }
}
