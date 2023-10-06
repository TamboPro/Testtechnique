using DossierAPI.Models;

namespace GraphqlAPI.Models
{
    public class DossierVoyage
    {

        public Reservation ReservationHotel { get; set; }
        public Client Client { get; set; }
        public ReservationVol ReservationVol { get; set; }
        public Ligne Ligne { get; set; }
        public Produit Produit { get; set; }
        public Hotel Hotel { get; set; }

        //public Guid ClientId { get; set; }
        /// <summary>
        /// Model Produit
        /// </summary>
        //public ProduitAPI.Models.Hotel Hotel { get; set; }
        //public ProduitAPI.Models.Ligne Ligne { get; set; }
        //public ProduitAPI.Models.Produit Produit { get; set; }
        //public ProduitAPI.Models.Reservation ReservationHotel { get; set; }
        //public ProduitAPI.Models.Categorie Categorie { get; set; }
        /// <summary>
        /// Model dossier Voyage
        /// </summary>
        //public DossierAPI.Models.Billet Billet { get; set; }
        //public DossierAPI.Models.Vol Vols { get; set; }
        // public DossierAPI.Models.Reservation ReservationVol { get; set; }
        //public DossierAPI.Models.Compagnie Compagnie { get; set; }
    }
}
