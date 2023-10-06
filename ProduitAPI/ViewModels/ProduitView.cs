using ProduitAPI.Models;

namespace ProduitAPI.ViewModels
{
    public class ProduitView
    {
        public int Numero { get; set; }
        public string? Reference { get; set; }
        public string? TypeProduit { get; set; }
        public decimal Prix { get; set; }
    }
}
